using System;
using System.Collections.Generic;
using System.Diagnostics;

//Falta validar para que siempre entre el mismo nombre
namespace Conf3_CP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region menuforteclado
            //Teclado obj = new Teclado();
            //obj.MideVelocityOfTecleo();
            //obj.MideVelocityOfTecleo();
            //obj.MideVelocityOfTecleo();
            //int position = 1;
            //float min = float.Parse(obj.MapStr[0].Value, CultureInfo.InvariantCulture.NumberFormat);
            
            //for (int i = 1; i < obj.MapStr.Count;i++)
            //{ 
            //    float temp = float.Parse(obj.MapStr[i].Value, CultureInfo.InvariantCulture.NumberFormat);
            //    if (temp < min)
            //    {
            //        min = temp;
            //        position = i;
            //    }

            //}
            //Console.WriteLine("La vez q mas rapido se tecleo el nombre fue la {0} y con un valor de {1} segundos", position, min);
            #endregion
            #region Menu Triangulo
            //float[] tempLados = new float[3];
            //while (true)
            //{
            //    for (int i = 0; i <= 2; i++)
            //    {
            //        Console.WriteLine("Entre el lado {0} del triangulo", i + 1);

            //        tempLados[i] = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
            //    }

            //    if (Tringulo.FormanTrinagulo(tempLados))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Los lados no forman triangulo. Pulsa Enter para repetir");
            //        Console.ReadLine();
            //    }
            //}
            //Console.WriteLine("Es un triangulo de tipo {0}", Tringulo.DeterminaTipoDeTriangulo(tempLados).ToString());
            #endregion
            #region Determina Secuencia
            Numeros.DeterminaSecuencia();
            #endregion
        }
    }
    #region Teclado
    class Teclado
    {

        public enum Velocity { Rapido = 1, Regular, Lenta };

        private List<KeyValuePair<string, string>> mapStr = new List<KeyValuePair<string, string>>();

        public List<KeyValuePair<string, string>> MapStr { get => mapStr; set => mapStr = value; }

       
        public Velocity MideVelocityOfTecleo()
        {
            Stopwatch crono = new Stopwatch();
            string str;
            //while(true)
            //{
                Console.WriteLine("Write a string");
                crono.Start();
                str = Console.ReadLine();
                crono.Stop();
        //    if (MapStr.Count > 0)
        //    {
        //        if (MapStr.FirstOrDefault().Value != MapStr.LastOrDefault().Value)
        //        {
        //            break;
        //        }
        //        Console.WriteLine("First Value {0} ; Last Value {1}", MapStr.FirstOrDefault().Value, MapStr.LastOrDefault().Value);
        //    }
        //} while (MapStr[0].Value != MapStr[MapStr.Count - 1].Value);
        //     while(MapStr.Count > 0 && (MapStr[0].Value != MapStr[MapStr.Count - 1].Value));

            float time = str.Length / (float)crono.ElapsedMilliseconds * 1000;

            if (time > 2)
            {
                mapStr.Add(new KeyValuePair<string, string>(str, time.ToString()));
                return Velocity.Rapido;
            }
            else if (time < 1)
            {
                mapStr.Add(new KeyValuePair<string, string>(str, time.ToString()));
                return Velocity.Lenta;
            }

            mapStr.Add(new KeyValuePair<string, string>(str, time.ToString()));
            return Velocity.Regular;

        }
    }
    #endregion
    #region Triangulo
    class Tringulo
    {
        public enum TipoDeTriagulo {Equilatero, Isosceles, Escaleno};
        private float[] lados;

        public Tringulo()
        {
            lados = new float[3];
        }

        public float[] Lados { get => lados; set => lados = value; }

        static public bool FormanTrinagulo(float[] sides)
        {
            if (sides[0] < (sides[1] + sides[2]) && sides[1] < (sides[0] + sides[2]) && sides[2] < (sides[1] + sides[0]))
            {
                return true;
            }
            return false;
        }

        static public TipoDeTriagulo DeterminaTipoDeTriangulo(float[] sides)
        {
            if (sides[0] == sides[1] && sides[0] == sides[2]) {
                return TipoDeTriagulo.Equilatero;
            }
            else if(sides[0] == sides[1] || sides[1] == sides[2]) {
                return TipoDeTriagulo.Isosceles;
            }
            return TipoDeTriagulo.Escaleno;
        }
    }
    #endregion
    #region Numeros
    class Numeros
    {
        public static bool EsPrimo(int number)
        {
            if (number >= 0 && number <= 3)
            {
                return true;
            }
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true; 
        }

        public static void OrdenaDeMenorAmayor(ref int[] valores)
        {
            for (int i = 0; i < valores.Length-1; i++)
            {
                int temp;
                for (int k = i + 1; k < valores.Length; k++)
                {
                    if (valores[k] < valores[i])
                    {
                        temp = valores[k];
                        valores[i] = valores[k];
                        valores[k] = temp;
                    }
                }
            }
        }

        public static long Factorial(long number)
        {
            long result = number;
            for (int i = 1; i < number; i++)
            {
                result*=i;
            }
            return result;
        }

        public static long Promedio(List<long> number)
        {
            long total = 0;
            foreach (var value in number)
            {
                total += value;
            }
            return total / number.Count;
        }

        public static void DeterminaSecuencia()
        {
            string str = "";
            List<long> positivos = new List<long>();
            //try
            //{
            while (true)
            {
                Console.WriteLine("Entre un numero on Entre End Para salir");
                str = Console.ReadLine();
                if (str == "End")
                {
                    break;
                }
                float temp = float.Parse(str);
                if (temp >= 0)
                {
                    if (EsPrimo((int)temp) == true)
                    {
                        Console.WriteLine("El numero es primo");
                    }
                    else
                    {
                        Console.WriteLine("El numero no es primo");
                    }
                    positivos.Add((long)temp);
                }

            }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Ha generado una excepcion de tipo {0}", e.Message);
            //}
            Console.WriteLine("El promedio de los positivos es {0} e introdujo {1} numeros positivos", Promedio(positivos),positivos.Count);
        }

        public static int PrimoMasCercano(int number)
        {
            int result = number;
            while (true)
            {
                if (EsPrimo(result) == true)
                {
                    break;
                }
                result++;
            }
            return result;
        }
    }
    #endregion
    #region Strings
    public class StringsHelper
    {
        public static bool EsPalindroma(string s)
        {
            char[] charToTrim = {'?','!',';','.',':',};
            string temp = s.Trim().ToUpper().Trim(charToTrim).Replace(" ","");

            for (int i = 0; i < temp.Length / 2; i++)
            {
                if (temp[i] != temp[temp.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string Reverse(string str)
        {
            char[] temp = new char[str.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {
                temp[i] = str[str.Length - 1 - i];   
              
         
            }
            return new string(temp);
        }
    }
    #endregion
}
