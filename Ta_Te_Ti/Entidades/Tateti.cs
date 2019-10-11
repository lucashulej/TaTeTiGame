using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tateti
    {
        public int[,] matriz = new int[3, 3];
        
        public Tateti()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = j; 
                }
            }

            for(int i = 0; i < 3; i++)
            {
                Console.Write(matriz[i, 0] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.Write(matriz[i, 1] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.Write(matriz[i, 2] + " ");
            }
            Console.WriteLine();

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.WriteLine(matriz[i, j]);
            //    }
            //    Console.WriteLine("OTRA COLUMA");
            //}

        }
    }
}
