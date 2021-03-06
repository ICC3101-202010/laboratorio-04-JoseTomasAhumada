﻿using System;
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
            Console.WriteLine("La máquina de empaque posee una memoria de " + packing.Memory() + "\n");

            //Encendiendo las máquinas.
            if(reception.State() == 0)
            {
                reception.TurnOn();
                Console.WriteLine("Máquina de recepción encendida.");
            }
            if(storage.State() == 0 && reception.State() == 1)
            {
                storage.TurnOn();
                Console.WriteLine("Máquina de almacenamiento encendida.");
            }
            if (assembly.State() == 0 && storage.State() == 1)
            {
                assembly.TurnOn();
                Console.WriteLine("Máquina de ensamblaje encendida.");
            }
            if (verification.State() == 0 && assembly.State() == 1)
            {
                verification.TurnOn();
                Console.WriteLine("Máquina de verificación encendida.");
            }
            if (packing.State() == 0 && verification.State() == 1)
            {
                packing.TurnOn();
                Console.WriteLine("Máquina de empaque encendida.\n");
            }

            int piece1 = 0;
            int piece2 = 0;
            int piece3 = 0;
            int piece4 = 0;
            int piece5 = 0;

            for (int t = 1; t <= 10; ++t) //Simulando lo que ocurre cada segundo durante 10 segundos.
            {
                Console.WriteLine("Segundo " + t);
                if (piece1 > reception.Memory())
                {
                    while (piece1 > reception.Memory())
                    {
                        Console.WriteLine("AVISO: Memoria de la máquina de recepción llena.");
                        Console.WriteLine("¿Desea reiniciar la máquina? si/no");
                        string option = Console.ReadLine();
                        if (option == "si")
                        {
                            reception.Reboot();
                            Console.WriteLine("Máquina de recepción reiniciada. \n");
                            piece1 -= piece1;
                        }
                    }
                }
                if (piece2 > storage.Memory())
                {
                    while (piece2 > storage.Memory())
                    {
                        Console.WriteLine("AVISO: Memoria de la máquina de almacenamiento llena.");
                        Console.WriteLine("Desea reiniciar la máquina? si/no");
                        string option = Console.ReadLine();
                        if (option == "si")
                        {
                            storage.Reboot();
                            Console.WriteLine("Máquina de almacenamiento reiniciada. \n");
                            piece2 -= piece2;
                        }
                    }
                }
                if (piece3 > assembly.Memory())
                {
                    while (piece3 > assembly.Memory())
                    {
                        Console.WriteLine("AVISO: Memoria de la máquina de ensamblaje llena.");
                        Console.WriteLine("Desea reiniciar la máquina? si/no");
                        string option = Console.ReadLine();
                        if(option == "si")
                        {
                            assembly.Reboot();
                            Console.WriteLine("Máquina de ensamblaje reiniciada.\n");
                            piece3 -= piece3;
                        }
                    }
                }
                if (piece4 > verification.Memory())
                {
                    while (piece4 > verification.Memory())
                    {
                        Console.WriteLine("AVISO: Memoria de la máquina de verificación llena.");
                        Console.WriteLine("Desea reiniciar la máquina? si/no");
                        string option = Console.ReadLine();
                        if(option == "si")
                        {
                            verification.Reboot();
                            Console.WriteLine("Máquina de verificación reiniciada.\n");
                            piece4 -= piece4;
                        }
                        
                    }
                }
                if (piece5 > packing.Memory())
                {
                    while (piece5 > packing.Memory())
                    {
                        Console.WriteLine("AVISO: Memoria de la máquina de empaque llena.");
                        Console.WriteLine("Desea reiniciar la máquina? si/no");
                        string option = Console.ReadLine();
                        if (option == "si")
                        {
                            packing.Reboot();
                            Console.WriteLine("Máquina de empaque reiniciada.\n");
                            piece5 -= piece5;
                        }
                    }
                }
                else
                {
                    reception.Recieve();
                    storage.Stock();
                    assembly.Assemble();
                    verification.Verify();
                    packing.Pack();
                    Console.WriteLine();
                    piece1 += Memory.Next(1, 4);
                    piece2 += Memory.Next(1, 4);
                    piece3 += Memory.Next(1, 4);
                    piece4 += Memory.Next(1, 4);
                    piece5 += Memory.Next(1, 4);
                }
            }
            //Apagando las máquinas.
            if (reception.State() == 1)
            {
                reception.TurnOff();
                Console.WriteLine("Máquina de recepción apagada.");
            }
            if (storage.State() == 1 && reception.State() == 0)
            {
                storage.TurnOff();
                Console.WriteLine("Máquina de almacenamiento apagada.");
            }
            if (assembly.State() == 1 && storage.State() == 0)
            {
                assembly.TurnOff();
                Console.WriteLine("Máquina de ensamblaje apagada.");
            }
            if (verification.State() == 1 && assembly.State() == 0)
            {
                verification.TurnOff();
                Console.WriteLine("Máquina de verificación apagada.");
            }
            if (packing.State() == 1 && verification.State() == 0)
            {
                packing.TurnOff();
                Console.WriteLine("Máquina de empaque apagada.");
            }
            Console.WriteLine("La máquina orientada a objetos se ha apagado correctamente.");
            Console.ReadKey();
        }
    }
}
