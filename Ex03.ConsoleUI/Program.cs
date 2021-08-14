using Engine;
using System;
using System.Collections.Generic;

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
            GarageManager garageManager = new GarageManager();
            string inputFromUser;
            bool goodInput = false;
            int whatToDo;

            PrintMainMenu();
            inputFromUser = Console.ReadLine();
            goodInput = int.TryParse(inputFromUser, out whatToDo);


            switch (whatToDo)
            {
                case 1: //want to insert new car to the garage
                    string licenseNumber;
                    GarageManager.eAvailableTypesOfVehicles i_VehicleType; //TODO can i use it without the class name before?
                    List<string> ownerVehicleInfo = new List<string>(); //Garage ticket
                    List<string> commonVehicleInfo = new List<string>(); //Vehicle
                    List<object> commonTypeOfVehicleInfo = new List<object>(); //Car / Motorcycle
                    List<object> specificTypeOfVehicleInfo = new List<object>(); // engine / fuel (car / Motorcycle)


                    //1- string license number (plate?)
                    Console.WriteLine("Please write the license number: ");
                    licenseNumber = Console.ReadLine();

                    if(!garageManager.IsVehicleInGarage(licenseNumber))
                    {
                        commonVehicleInfo.Add(licenseNumber); //licenseNumber

                        //2- string owner name
                        Console.WriteLine("Please write the owner name: ");
                        inputFromUser = Console.ReadLine();
                        ownerVehicleInfo.Add(inputFromUser);

                        //3- string owner phone number
                        Console.WriteLine("Please write the owner phone number: ");
                        inputFromUser = Console.ReadLine();
                        ownerVehicleInfo.Add(inputFromUser);

                        //4- enum type of vehicle -- look at 9
                        Console.WriteLine(
                            "Please select the type of the vehicle? (1-fuel motor, 2-electric motor.... (by enum class) "); //TODO find a way to print it dinamicly, if I added more types
                        inputFromUser = Console.ReadLine();

                        // TODO put in enum and check if it is in the enum class
                        goodInput = GarageManager.eAvailableTypesOfVehicles.TryParse(inputFromUser, out i_VehicleType);
                         

                        //5- string module name
                        Console.WriteLine("Please write the module name: ");
                        inputFromUser = Console.ReadLine();
                        commonVehicleInfo.Add(inputFromUser);

                        //6- float currect energy in engine
                        Console.WriteLine("Please write the currect energy in engine: ");
                        inputFromUser = Console.ReadLine();
                        commonVehicleInfo.Add(inputFromUser); // TODO it is a float number in a string

                        //7- list wheels
                        Console.WriteLine("Please write the data about the tires: ");
                        Console.WriteLine("Please write the name of the manufacture: ");
                        inputFromUser = Console.ReadLine();
                        commonVehicleInfo.Add(inputFromUser); // a- manufactureName

                        Console.WriteLine("Please write the current air pressure of the tire: ");
                        inputFromUser = Console.ReadLine();
                        commonVehicleInfo.Add(inputFromUser); // b- current air pressure

                        Console.WriteLine("Please write the maximum air pressure of the tire: ");
                        inputFromUser = Console.ReadLine();
                        commonVehicleInfo.Add(inputFromUser); // c- max air pressure


                        //8- state of the car is - "בתיקון"

                        //9- another switch case by the enum module we found to add data to build the right vehicle
                        switch ( /*enumVehicleType*/whatToDo) // whatoDo is not good
                        {
                            case 1 /*FuelMotorcycle*/:
                                // Motorcycle-
                                //10 -type of license
                                Console.WriteLine("Please write you'r type of license: ");
                                inputFromUser = Console.ReadLine();
                                commonTypeOfVehicleInfo.Add(inputFromUser); //string

                                //11 -נפח מנוע
                                Console.WriteLine("Please write you'r engine 'nefah': ");
                                inputFromUser = Console.ReadLine();
                                commonTypeOfVehicleInfo.Add(inputFromUser); //int

                                /*Fuel*/
                                Console.WriteLine("Please write the type of fuel: ");
                                inputFromUser = Console.ReadLine();
                                specificTypeOfVehicleInfo.Add(inputFromUser); //enum

                                Console.WriteLine("Please write the current amount of fuel: ");
                                inputFromUser = Console.ReadLine();
                                specificTypeOfVehicleInfo.Add(inputFromUser); //int

                                Console.WriteLine("Please write the current amount of fuel: ");
                                inputFromUser = Console.ReadLine();
                                specificTypeOfVehicleInfo.Add(inputFromUser); //int

                                break;
                                case 2 /*EnergyMotorcycle*/:
                                break;
                        }


                        garageManager.InsertNewVehicleToGarage(i_VehicleType, ownerVehicleInfo, commonVehicleInfo, commonTypeOfVehicleInfo, specificTypeOfVehicleInfo)

                    }
                    else //Vihcle in the garage
                    {
                        //change status to in repair
                        garageManager.ChangeVehicleStatus(licenseNumber,GarageCard.eVehicleState.InRepair);
                    }


                    break;
                


                case 2:
                            Console.WriteLine("Hello, print");
                    break;

                default:
                    break;
           }

        }


        public static void PrintMainMenu()
        {
            string mainMenuOptions = "Please select one of the following options (a number between 1-7):\n" +
                                     "1 - Insert a new vehicle into the garage.\n" +
                                     "2 - Display all the vehicles currently in the garage. (with or without filter by their status)\n" +
                                     "3 - Change a vehicle's status.\n" +
                                     "4 - Inflate a specific vehicle's tires to maximum air pressure.\n" +
                                     "5 - Refuel a fuel based vehicle.\n" +
                                     "6 - Charge an electric based vehicle.\n" +
                                     "7 - Display a vehicle's full information.\n";
            
            Console.WriteLine(mainMenuOptions);
        }

        }

    }
}
