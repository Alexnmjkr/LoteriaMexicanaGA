using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoteriaMexicana.Network
{
    public class ClienteLoteria
    {
        private TcpClient _cliente;
        private StreamWriter _writer;
        private bool _conectado;
        private bool _desconexionManual;

        public event Action<string> MensajeRecibido;
        public event Action Desconectado;
        public event Action<string> Error;

        public void Conectar(string ip, int puerto)
        {
            if (_conectado) return;

            _cliente = new TcpClient();
            _cliente.Connect(ip, puerto);

            _writer = new StreamWriter(_cliente.GetStream());
            _writer.AutoFlush = true;

            _conectado = true;
            _desconexionManual = false;
            Task.Run(() => EscucharServidor());
        }

        public void Enviar(string mensaje)
        {
            if (!_conectado || _writer == null) return;

            try
            {
                _writer.WriteLine(mensaje);
            }
            catch (Exception ex)
            {
                _conectado = false;
                Error?.Invoke(ex.Message);
                Desconectar();
            }
        }

        public void Desconectar()
        {
            _desconexionManual = true;
            _conectado = false;

            try { _writer?.Close(); } catch { }
            try { _cliente?.Close(); } catch { }

            _writer = null;
            _cliente = null;
        }

        private void EscucharServidor()
        {
            try
            {
                StreamReader reader = new StreamReader(_cliente.GetStream());

                while (_conectado)
                {
                    string mensaje = reader.ReadLine();

                    if (mensaje == null)
                        break;

                    MensajeRecibido?.Invoke(mensaje);
                }
            }
            catch (Exception ex)
            {
                if (_conectado)
                    Error?.Invoke(ex.Message);
            }
            finally
            {
                _conectado = false;

                if (!_desconexionManual)
                    Desconectado?.Invoke();
            }
        }
    }
}
