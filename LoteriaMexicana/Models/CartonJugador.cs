using System;
using System.Collections.Generic;

namespace LoteriaMexicana.Models
{
    public class CartonJugador
    {
        public const int FILAS = 4;
        public const int COLUMNAS = 5;
        public const int TOTAL = FILAS * COLUMNAS;

        public Carta[,] Cartas { get; private set; }
        public bool[,] Marcadas { get; private set; }

        private Random _rng = new Random();

        public CartonJugador(List<Carta> todasLasCartas)
            : this(todasLasCartas, false)
        {
        }

        public CartonJugador(List<Carta> todasLasCartas, bool permitirDobles)
        {
            Cartas = new Carta[FILAS, COLUMNAS];
            Marcadas = new bool[FILAS, COLUMNAS];

            GenerarCarton(todasLasCartas, permitirDobles);
        }

        private void GenerarCarton(List<Carta> todasLasCartas, bool permitirDobles)
        {
            List<Carta> copia = new List<Carta>(todasLasCartas);

            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int col = 0; col < COLUMNAS; col++)
                {
                    int idx = _rng.Next(copia.Count);
                    Cartas[fila, col] = copia[idx];

                    if (!permitirDobles)
                        copia.RemoveAt(idx);
                }
            }
        }

        public void CrearNuevoCarton(List<Carta> todasLasCartas, bool permitirDobles)
        {
            GenerarCarton(todasLasCartas, permitirDobles);
            ReiniciarMarcadas();
        }

        public void CargarCartas(Carta[,] nuevasCartas)
        {
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int col = 0; col < COLUMNAS; col++)
                {
                    Cartas[fila, col] = nuevasCartas[fila, col];
                }
            }

            ReiniciarMarcadas();
        }

        public void MarcarCarta(int fila, int col)
        {
            Marcadas[fila, col] = true;
        }

        public void ReiniciarMarcadas()
        {
            Marcadas = new bool[FILAS, COLUMNAS];
        }

        public bool TieneCartaId(int cartaId, out int fila, out int col)
        {
            for (int f = 0; f < FILAS; f++)
            {
                for (int c = 0; c < COLUMNAS; c++)
                {
                    if (Cartas[f, c].Id == cartaId)
                    {
                        fila = f;
                        col = c;
                        return true;
                    }
                }
            }

            fila = -1;
            col = -1;
            return false;
        }

        public bool TieneLineaHorizontal()
        {
            for (int f = 0; f < FILAS; f++)
            {
                bool completa = true;

                for (int c = 0; c < COLUMNAS; c++)
                {
                    if (!Marcadas[f, c])
                    {
                        completa = false;
                        break;
                    }
                }

                if (completa)
                    return true;
            }

            return false;
        }

        public bool TieneLineaVertical()
        {
            for (int c = 0; c < COLUMNAS; c++)
            {
                bool completa = true;

                for (int f = 0; f < FILAS; f++)
                {
                    if (!Marcadas[f, c])
                    {
                        completa = false;
                        break;
                    }
                }

                if (completa)
                    return true;
            }

            return false;
        }

        public bool TieneDiagonal()
        {
            bool diag1 = true;

            for (int i = 0; i < FILAS; i++)
            {
                if (!Marcadas[i, i])
                {
                    diag1 = false;
                    break;
                }
            }

            if (diag1)
                return true;

            bool diag2 = true;

            for (int i = 0; i < FILAS; i++)
            {
                if (!Marcadas[i, COLUMNAS - 1 - i])
                {
                    diag2 = false;
                    break;
                }
            }

            return diag2;
        }

        public bool TieneLinea()
        {
            return TieneLineaHorizontal() || TieneLineaVertical() || TieneDiagonal();
        }

        public bool TieneCartonLleno()
        {
            for (int f = 0; f < FILAS; f++)
            {
                for (int c = 0; c < COLUMNAS; c++)
                {
                    if (!Marcadas[f, c])
                        return false;
                }
            }

            return true;
        }
    }
}