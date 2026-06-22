using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoteriaMexicana.Network
{
    public class ServidorLoteria
    {
        private TcpListener _listener;
        private readonly List<TcpClient> _clientes = new List<TcpClient>();
        private readonly Dictionary<TcpClient, StreamWriter> _writers = new Dictionary<TcpClient, StreamWriter>();
        private bool _activo;

        public event Action<string> MensajeRecibido;
        public event Action<string> ClienteConectado;
        public event Action<string> Error;

        public void Iniciar(int puerto)
        {
            if (_activo) return;

            _listener = new TcpListener(IPAddress.Any, puerto);
            _listener.Start();
            _activo = true;

            Task.Run(() => AceptarClientes());
        }

        public void Transmitir(string mensaje)
        {
            if (!_activo)
                return;

            List<TcpClient> desconectados = new List<TcpClient>();

            lock (_clientes)
            {
                foreach (TcpClient cliente in _clientes)
                {
                    if (!EnviarACliente(cliente, mensaje))
                        desconectados.Add(cliente);
                }

                foreach (TcpClient cliente in desconectados)
                {
                    _clientes.Remove(cliente);
                    _writers.Remove(cliente);
                    cliente.Close();
                }
            }
        }

        public void Detener()
        {
            _activo = false;

            try { _listener?.Stop(); } catch { }

            lock (_clientes)
            {
                foreach (TcpClient cliente in _clientes)
                {
                    StreamWriter writer;

                    if (_writers.TryGetValue(cliente, out writer))
                    {
                        try { writer.Close(); } catch { }
                    }

                    cliente.Close();
                }

                _clientes.Clear();
                _writers.Clear();
            }
        }

        private void AceptarClientes()
        {
            while (_activo)
            {
                try
                {
                    TcpClient cliente = _listener.AcceptTcpClient();
                    cliente.NoDelay = true;

                    StreamWriter writer = new StreamWriter(cliente.GetStream());
                    writer.AutoFlush = true;

                    lock (_clientes)
                    {
                        _clientes.Add(cliente);
                        _writers[cliente] = writer;
                    }

                    string ip = ((IPEndPoint)cliente.Client.RemoteEndPoint).Address.ToString();
                    ClienteConectado?.Invoke(ip);

                    Task.Run(() => EscucharCliente(cliente));
                }
                catch (Exception ex)
                {
                    if (_activo)
                        Error?.Invoke(ex.Message);
                }
            }
        }

        private void EscucharCliente(TcpClient cliente)
        {
            try
            {
                StreamReader reader = new StreamReader(cliente.GetStream());

                while (_activo && cliente.Connected)
                {
                    string mensaje = reader.ReadLine();

                    if (mensaje == null)
                        break;

                    MensajeRecibido?.Invoke(mensaje);
                    Transmitir(mensaje);
                }
            }
            catch (Exception ex)
            {
                if (_activo)
                    Error?.Invoke(ex.Message);
            }
            finally
            {
                lock (_clientes)
                {
                    _clientes.Remove(cliente);
                    _writers.Remove(cliente);
                }

                try { cliente.Close(); } catch { }
            }
        }

        private bool EnviarACliente(TcpClient cliente, string mensaje)
        {
            try
            {
                StreamWriter writer;

                if (!_writers.TryGetValue(cliente, out writer))
                    return false;

                writer.WriteLine(mensaje);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
