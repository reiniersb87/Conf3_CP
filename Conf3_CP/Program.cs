using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Conf3_CP
{
    class Program
    {
        static void Main(string[] args)
        {
            Teclado obj = new Teclado();
            obj.MideVelocityOfTecleo();
            obj.MideVelocityOfTecleo();
            obj.MideVelocityOfTecleo();
          
 
        }
    }

    class Teclado {

        public enum Velocity {Rapido = 1, Regular, Lenta};
        public SortedDictionary<string, float> mapStr = new SortedDictionary<string, float>();  
        
        public Velocity MideVelocityOfTecleo()
        {
            Stopwatch crono = new Stopwatch();
            Console.WriteLine("Write a string");
            crono.Start();
            string str = Console.ReadLine();
            crono.Stop();
            float time = str.Length / (float)crono.ElapsedMilliseconds * 1000;
            
            if (time > 2)
            {
                mapStr.Add(str, time);
                return Velocity.Rapido;
            } 
            else if (time < 1)
            {
                mapStr.Add(str, time);
                return Velocity.Lenta;
            }

            mapStr.Add(str, time);
            return Velocity.Regular;

        }
    }
}
