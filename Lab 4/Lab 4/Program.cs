using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definiendo la memoria de las máquinas de forma aleatoria.
            List<int> memory = new List<int>();
            Random Memory = new Random();
            for(int i = 0; i <= 4; ++i)
            {
                int m = Memory.Next(10, 21);
                memory.Add(m);
            }
            //Creando las máquinas.
            Reception reception = new Reception(memory[0], 0);
            Storage storage = new Storage(memory[1], 0);
            Assembly assembly = new Assembly(memory[2], 0);
            Verification verification = new Verification(memory[3], 0);
            Packing packing = new Packing(memory[4], 0);

            Console.WriteLine("La fábrica orientada a objetos ha comenzado a funcionar \n");
            Console.WriteLine("La máquina de recepción posee una memoria de " + reception.Memory());
            Console.WriteLine("La máquina de almacenamiento posee una memoria de " + storage.Memory());
            Console.WriteLine("La máquina de ensamblaje posee una memoria de " + assembly.Memory());
            Console.WriteLine("La máquina de verificación posee una memoria de " + verification.Memory());
            Console.WriteLine("La máquina de empaque posee una memoria de " + packing.Memory());

            //Encendiendo las máquinas.
            if(reception.State() == 0)
            {
                reception.TurnOn();
            }
            if(storage.State() == 0 && reception.State() == 1)
            {
                storage.TurnOn();
            }
            if (assembly.State() == 0 && storage.State() == 1)
            {
                assembly.TurnOn();
            }
            if (verification.State() == 0 && assembly.State() == 1)
            {
                verification.TurnOn();
            }
            if (packing.State() == 0 && verification.State() == 1)
            {
                packing.TurnOn();
            }

            int piece1 = 0;
            int piece2 = 0;
            int piece3 = 0;
            int piece4 = 0;
            int piece5 = 0;

            for (int t = 0; t <= 9; ++t) //Simulando lo que ocurre cada segundo durante 10 segundos.
            {
                Console.WriteLine();
                Console.WriteLine("Segundo " + t);
                Console.WriteLine(piece1);
                Console.WriteLine(piece2);
                Console.WriteLine(piece3);
                Console.WriteLine(piece4);
                Console.WriteLine(piece5);

                if (piece1 > reception.Memory())
                {
                    Console.WriteLine(piece1);
                    Console.WriteLine("AVISO: Memoria de la máquina de recepción llena.");
                    Console.WriteLine("Vaciando memoria...");
                    reception.Reboot();
                    Console.WriteLine("Reinicio completado.");
                    piece1 -= piece1;
                }
                else if (piece2 > storage.Memory())
                {
                    Console.WriteLine(piece2);
                    Console.WriteLine("AVISO: Memoria de la máquina de almacenamiento llena.");
                    Console.WriteLine("Vaciando memoria...");
                    storage.Reboot();
                    Console.WriteLine("Reinicio completado.");
                    piece2 -= piece2;
                }
                else if (piece3 > assembly.Memory())
                {
                    Console.WriteLine(piece3);
                    Console.WriteLine("AVISO: Memoria de la máquina de ensamblaje llena.");
                    Console.WriteLine("Vaciando memoria...");
                    assembly.Reboot();
                    Console.WriteLine("Reinicio completado.");
                    piece3 -= piece3;
                }
                else if (piece4 > verification.Memory())
                {
                    Console.WriteLine(piece4);
                    Console.WriteLine("AVISO: Memoria de la máquina de verificación llena.");
                    Console.WriteLine("Vaciando memoria...");
                    verification.Reboot();
                    Console.WriteLine("Reinicio completado.");
                    piece4 -= piece4;
                }
                else if (piece5 > packing.Memory())
                {
                    Console.WriteLine(piece5);
                    Console.WriteLine("AVISO: Memoria de la máquina de empaque llena.");
                    Console.WriteLine("Vaciando memoria...");
                    packing.Reboot();
                    Console.WriteLine("Reinicio completado.");
                    piece5 -= piece5;
                }
                else
                {
                    Console.WriteLine("Fábrica funcionando sin problemas.");
                    piece1 += Memory.Next(1, 4);
                    piece2 += Memory.Next(1, 4);
                    piece3 += Memory.Next(1, 4);
                    piece4 += Memory.Next(1, 4);
                    piece5 += Memory.Next(1, 4);
                }

            }
            Console.ReadKey();
        }
    }
}
