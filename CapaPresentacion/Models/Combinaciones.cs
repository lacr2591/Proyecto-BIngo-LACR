using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaPresentacion.Models
{
    public partial class Combinaciones
    {
        public Combinaciones()
        {
            Tarjetas = new HashSet<Tarjetas>();
        }

        public int IdCombinacion { get; set; }
        public string Numeros { get; set; }


        public string GenerarCombinacion()
        {
            List<int> columnaB = GenerarColumna(0, 16);
            List<int> columnaI = GenerarColumna(16, 31);
            List<int> columnaN = GenerarColumna(31, 46);
            List<int> columnaG = GenerarColumna(46, 61);
            List<int> columnaO = GenerarColumna(61, 76);

            string combinacion = "";

            for (int i = 0; i < 5; i++)
            {
                combinacion = combinacion + columnaB[i].ToString() + " ";
                combinacion = combinacion + columnaI[i].ToString() + " ";

                if (i != 2)
                    combinacion = combinacion + columnaN[i].ToString() + " ";

                combinacion = combinacion + columnaG[i].ToString() + " ";

                if (i == 4)
                    combinacion = combinacion + columnaO[i].ToString();
                else
                    combinacion = combinacion + columnaO[i].ToString() + " ";

            }

            return combinacion;
        }

        public bool esRepetido(List<string> combinaciones, string combinacionPorAgregar)
        {
            bool sonIguales = false;
            int contadorCoincidencias = 0;

            foreach (var combinacion in combinaciones)
            {
                int[] tempA = Array.ConvertAll(combinacion.Split(), s => int.Parse(s));
                int[] tempB = Array.ConvertAll(combinacionPorAgregar.Split(), s => int.Parse(s));

                contadorCoincidencias = tempA.Intersect(tempB).Count();
                if (contadorCoincidencias == 24)
                {
                    sonIguales = true;
                    break;
                }
                Console.WriteLine(contadorCoincidencias);
            }
            return sonIguales;
        }

        public List<int> GenerarColumna(int rangoI, int rangoF)
        {
            Random aleatorio = new Random();
            List<int> listaNum = new List<int>();

            int temp;
            bool esPrimero = true;
            for (int i = 0; i < 5; i++)
            {
                if (esPrimero)
                {
                    listaNum.Add(aleatorio.Next(rangoI, rangoF));
                    esPrimero = false;
                }
                else
                {
                    temp = aleatorio.Next(rangoI, rangoF);
                    while (listaNum.Contains(temp))
                    {
                        temp = aleatorio.Next(rangoI, rangoF);
                    }
                    listaNum.Add(temp);
                }
            }
            return listaNum;
        }


        public virtual ICollection<Tarjetas> Tarjetas { get; set; }
    }
}
