﻿using Engine;
using System;
using System.Collections.Generic;
using static Engine.GarageManager;
using static Engine.VehicleFactory;

namespace Ex03.ConsoleUI
{
    class GarageProgram
    {
        GarageManager garageManager = new GarageManager();



        public void RunForestRun()
        {
            GarageManager garageManager = new GarageManager();
            string inputFromUser;
            bool goodInput = false;
            int whatToDo;



            while(true) //TODO change it to bool
            {
                PrintMainMenu();
                inputFromUser = Console.ReadLine();
                goodInput = int.TryParse(inputFromUser, out whatToDo);

                switch(whatToDo)
                {
                    case 1: //want to insert new car to the garage
                        InsertNewVehicleToGarage();
                        break;

                    case 2:
                        Console.WriteLine("Hello, print");


                        break;
                    case 5:
                        RefuelVehicle();
                        break;
                    case 6:
                        ChargeElectricVehicle();
                        break;
                    case 7:
                        ShowVehicleDetails();
                        break;
                    default:
                        break;
                }
            }

        }

        public void ShowLicensePlateOfVehiclesInGarage()
        {
            int userChoice;
            string licenseNumber, inputFromUser;
            bool goodInput;

            Console.WriteLine("Choose which license plate to show: (1 - Show All, 2 - Filter status)");
            inputFromUser = Console.ReadLine();
            goodInput = int.TryParse(inputFromUser, out userChoice);
            if (goodInput)
            {
                if(userChoice == 1)
                {
                    List<string> listToPrintInGarage = garageManager.GetLicensePlateInGarage();
                    foreach (string licensePlateNumber in listToPrintInGarage)
                    {
                        Console.WriteLine(licensePlateNumber);
                    }
                }
                else if(userChoice == 2)
                {
                    List<string> listToPrintInGarage = garageManager.GetLicensePlateInGarage();
                    foreach (string licensePlateNumber in listToPrintInGarage)
                    {
                        Console.WriteLine(licensePlateNumber);
                    }

                }
            }

        }

        public void RefuelVehicle()
        {
            float amountToRefuel;
            string fuelType,licenseNumber, inputFromUser;
            bool goodInput;

            Console.WriteLine("Enter license plate number:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter the amount to refuel:");
            inputFromUser = Console.ReadLine();
            goodInput = float.TryParse(inputFromUser, out amountToRefuel);
            Console.WriteLine("Enter the type of fuel:");
            PrintEnumOptions(typeof(FuelEngine.eVehicleFuelType));
            fuelType = Console.ReadLine();
            if (goodInput && garageManager.IsVehicleInGarage(licenseNumber))
            {
                garageManager.RefuelFuelVehicle(licenseNumber, fuelType, amountToRefuel);
            }
            else if (!goodInput)
            {
                Console.WriteLine("You can refuel only decimal number.");
            }
            else // !garageManager.IsVehicleInGarage(licenseNumber)
            {
                Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
            }
        }

        public void ChargeElectricVehicle()
        {
            string inputFromUser, licenseNumber;
            float amountToAdd;
            bool goodInput;

            try { 
                Console.WriteLine("Enter license plate number:");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Enter the hours to charge:");
                inputFromUser = Console.ReadLine();
                goodInput = float.TryParse(inputFromUser, out amountToAdd);
                if (goodInput && garageManager.IsVehicleInGarage(licenseNumber))
                {
                    garageManager.ChargeElectricVehicle(licenseNumber, amountToAdd);
                }
                else if (!goodInput)
                {
                    Console.WriteLine("You can charge only decimal number.");
                }
                else // !garageManager.IsVehicleInGarage(licenseNumber)
                {
                    Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowVehicleDetails()
        {
            string vehicleDetails, licenseNumber;

            Console.WriteLine("Enter license plate number:");
            licenseNumber = Console.ReadLine();
            if (garageManager.IsVehicleInGarage(licenseNumber))
            {
                vehicleDetails = garageManager.GetVehicleDetails(licenseNumber);
                Console.WriteLine(vehicleDetails);
            }
            else
            {
                Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
            }
        }

        public void PrintMainMenu()
        {
            string mainMenuOptions = "Please select one of the following options (a number between 1-7):\n"
                                     + "1 - Insert a new vehicle into the garage.\n"
                                     + "2 - Display all the vehicles currently in the garage. (with or without filter by their status)\n"
                                     + "3 - Change a vehicle's status.\n"
                                     + "4 - Inflate a specific vehicle's tires to maximum air pressure.\n"
                                     + "5 - Refuel a fuel based vehicle.\n" + "6 - Charge an electric based vehicle.\n"
                                     + "7 - Display a vehicle's full information.\n";

            Console.WriteLine(mainMenuOptions);
        }

        public void InsertNewVehicleToGarage()
        {
            bool goodInput;
            string licenseNumber, inputFromUser;
            eAvailableTypesOfVehicles vehicleType; //TODO can i use it without the class name before?
            List<string> ownerVehicleInfo = new List<string>(); //Garage ticket
            List<string> commonVehicleInfo = new List<string>(); //Vehicle
            List<string> commonTypeOfVehicleInfo = new List<string>(); //Car / Motorcycle
            List<string> specificTypeOfVehicleInfo = new List<string>(); // engine / fuel (car / Motorcycle)

            Console.WriteLine("You chose option 1 to Insert a vehicle to the garage!");

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
                Console.WriteLine("Please select the type of the vehicle? (select the fucking number next to the type)"); //TODO delte fucking very important!!
                PrintEnumOptions(typeof(eAvailableTypesOfVehicles));
                inputFromUser = Console.ReadLine();

                // TODO put in enum and check if it is in the enum class
                goodInput = eAvailableTypesOfVehicles.TryParse(inputFromUser, out vehicleType);

                List<string> vehicleQuestions =  garageManager.InsertNewVehicleToGarage(vehicleType, licenseNumber);

                foreach(string question in vehicleQuestions)
                {
                    Console.WriteLine(question);
                    inputFromUser = Console.ReadLine();
                    specificTypeOfVehicleInfo.Add(inputFromUser);
                }

                //garageManager.UpdateVehicle(licenseNumber, specificTypeOfVehicleInfo);

                /*
                //5- string module name
                Console.WriteLine("Please write the module name: ");
                inputFromUser = Console.ReadLine();
                commonVehicleInfo.Add(inputFromUser);

                //6- list wheels
                Console.WriteLine("Please write the data about the tires: ");
                Console.WriteLine("Please write the name of the manufacture: ");
                inputFromUser = Console.ReadLine();
                commonVehicleInfo.Add(inputFromUser); // a- manufactureName

                Console.WriteLine("Please write the current air pressure of the tire: ");
                inputFromUser = Console.ReadLine();
                commonVehicleInfo.Add(inputFromUser); // b- current air pressure


                //7- state of the car is - "בתיקון"

                //8- another switch case by the enum module we found to add data to build the right vehicle
                switch(vehicleType ) 
                {
                    case eAvailableTypesOfVehicles.FuelMotorcycle:
                    case eAvailableTypesOfVehicles.ElectricMotorcycle:
                        // Motorcycle-
                        //10 -type of license
                        Console.WriteLine("Please write your type of license: ");
                        inputFromUser = Console.ReadLine();
                        commonTypeOfVehicleInfo.Add(inputFromUser); //string

                        //11 -capacity
                        Console.WriteLine("Please write your engine capacity: ");
                        inputFromUser = Console.ReadLine();
                        commonTypeOfVehicleInfo.Add(inputFromUser); //int

                        // 12
                        Console.WriteLine("Please write the current amount of fuel: ");
                        inputFromUser = Console.ReadLine();
                        specificTypeOfVehicleInfo.Add(inputFromUser); //float

                        break;
                    case eAvailableTypesOfVehicles.FuelCar:
                    case eAvailableTypesOfVehicles.ElectricCar:
                        //10 -type of color
                        Console.WriteLine("Please write your type of color: ");
                        inputFromUser = Console.ReadLine();
                        commonTypeOfVehicleInfo.Add(inputFromUser); //enum

                        //11 - amount of doors
                        Console.WriteLine("Please write the amount of doors: ");
                        inputFromUser = Console.ReadLine();
                        commonTypeOfVehicleInfo.Add(inputFromUser); //int - TODO: add enum of the amount of doors

                        // 12
                        Console.WriteLine("Please write the current amount of fuel: ");
                        inputFromUser = Console.ReadLine();
                        specificTypeOfVehicleInfo.Add(inputFromUser); //float

                        break;

                    case eAvailableTypesOfVehicles.Truck:
                        //10 -type of color
                        Console.WriteLine("Please write if you carry dangerous materials (Y-yes or N-no): ");
                        inputFromUser = Console.ReadLine();
                        commonTypeOfVehicleInfo.Add(inputFromUser); //bool

                        // 11 - max carry weight 
                        Console.WriteLine("Please write your max carry weight : ");
                        inputFromUser = Console.ReadLine();
                        commonTypeOfVehicleInfo.Add(inputFromUser); //float

                        // 12
                        Console.WriteLine("Please write the current amount of fuel: ");
                        inputFromUser = Console.ReadLine();
                        specificTypeOfVehicleInfo.Add(inputFromUser); //float
                       
                        break;
                }


                garageManager.InsertNewVehicleToGarage(
                    vehicleType,
                    ownerVehicleInfo,
                    commonVehicleInfo,
                    commonTypeOfVehicleInfo,
                    specificTypeOfVehicleInfo);
                */
            }
            else //Vihcle in the garage
            {
                //change status to in repair
                garageManager.ChangeVehicleStatus(licenseNumber, GarageCard.eVehicleState.InRepair);
            }

        }

        public void PrintEnumOptions(Type i_EnumNamesToPrint)
        {
            int index = 1;

            Console.Write("(");
            foreach (string name in Enum.GetNames(i_EnumNamesToPrint))
            {
                if(index != 1)
                {
                    Console.Write(",");
                }

                Console.Write($" {index} - {name}");
                ++index;
            }

            Console.Write(")");
        }

    }
}