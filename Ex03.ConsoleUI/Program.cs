using System;
using System.Collections.Generic;
using Engine;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            RunForestRun();
        }

        public static void RunForestRun()
        {
            GarageManager garageManager;
            string inputFromUser;
            bool goodInput = false;
            int whatToDo;


            // tester
            Console.WriteLine("Hello, please select one of the options 1-8? ");
            inputFromUser = Console.ReadLine();
            goodInput = int.TryParse(inputFromUser, out whatToDo);

            switch(whatToDo)
            {
                case 1: //want to insert new car to the garage
                    //1- string owner name
                    Console.WriteLine("Please write the owner name: ");
                    inputFromUser = Console.ReadLine();

                    //2- string owner phone number
                    Console.WriteLine("Please write the owner phone number: ");
                    inputFromUser = Console.ReadLine();


                    //3- enum type of vehicle -- look at 9
                    Console.WriteLine("Please select the type of the vehile? (1-fuel motor, 2-electric motor.... (by enum class) ");
                    inputFromUser = Console.ReadLine();
                    // put in enum and check if it is in the enum class

                    //4- string module name
                    Console.WriteLine("Please write the module name: ");
                    inputFromUser = Console.ReadLine();

                    //5- string license number (plate?)
                    Console.WriteLine("Please write the license number: ");
                    inputFromUser = Console.ReadLine();

                    //6- float currect energy in engine
                    Console.WriteLine("Please write the currect energy in engine: ");
                    inputFromUser = Console.ReadLine();

                    //7- list wheels
                    Console.WriteLine("Please write the data about the wheels: ");
                    inputFromUser = Console.ReadLine();

                    //8- state of the car is - "בתיקון"

                    //9- another switch case by the enum module we found to add data to build the right vehicle
                    switch( /*enumVehicleType*/whatToDo) // whatoDo is not good
                    {
                        case 1 /*FuelMotorcycle*/:
                            //GarageManager.askFuelMotor();
                            //10 -type of license
                            Console.WriteLine("Please write you'r type of license: ");
                            inputFromUser = Console.ReadLine();

                            //11 -נפח מנוע
                            Console.WriteLine("Please write you'r engine 'nefah': ");
                            inputFromUser = Console.ReadLine();
                            break;
                    }
                    break;
                
                case 2/*EnergyMotorcycle*/:
                            Console.WriteLine("Hello, print");
                    break;


            }

            //pressed 1
        }
    }
}
