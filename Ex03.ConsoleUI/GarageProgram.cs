using Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using static Engine.VehicleFactory;

namespace Ex03.ConsoleUI
{
    class GarageProgram
    {
        private readonly GarageManager r_GarageManager = new GarageManager();
        private bool m_GameLoop = true;

        public void RunForestRun()
        {
            string inputFromUser;
            bool goodInput = false;
            eMainMenuOptions UserChoiceWhatToDo;

            while(m_GameLoop) 
            {
                PrintMainMenu();
                inputFromUser = Console.ReadLine();
                goodInput = eMainMenuOptions.TryParse(inputFromUser, out UserChoiceWhatToDo);
                if(goodInput)
                {
                    switch(UserChoiceWhatToDo)
                    {
                        case eMainMenuOptions.Option1:
                            InsertNewVehicleToGarage();
                            break;
                        case eMainMenuOptions.Option2:
                            ShowLicensePlateOfVehiclesInGarage();
                            break;
                        case eMainMenuOptions.Option3:
                            ChangeVehicleStatus();
                            break;
                        case eMainMenuOptions.Option4:
                            InflateVehicleTires();
                            break;
                        case eMainMenuOptions.Option5:
                            RefuelVehicle();
                            break;
                        case eMainMenuOptions.Option6:
                            ChargeElectricVehicle();
                            break;
                        case eMainMenuOptions.Option7:
                            ShowVehicleDetails();
                            break;
                        case eMainMenuOptions.Option8:
                            QuitProgram();
                            break;
                        default:
                            Console.WriteLine("You entered invalid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You entered invalid option. Only integer numbers are allowed ");
                }
            }
        }

        public void ChangeVehicleStatus()
        {
            string licenseNumber, inputFromUser;

            Console.WriteLine("Enter license plate number:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter the new status:");
            PrintEnumOptions(typeof(GarageCard.eVehicleState));
            inputFromUser = Console.ReadLine();
            try 
            { 
                if (r_GarageManager.IsVehicleInGarage(licenseNumber))
                {
                    r_GarageManager.ChangeVehicleStatus(licenseNumber, inputFromUser);
                }
                else 
                {
                    Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InflateVehicleTires()
        {
            string licenseNumber;

            Console.WriteLine("Enter license plate number:");
            licenseNumber = Console.ReadLine();
            try
            {
                if (r_GarageManager.IsVehicleInGarage(licenseNumber))
                {
                    r_GarageManager.InflateTiresAirToMaximum(licenseNumber);
                    Console.WriteLine("The vehicle tires has been inflated to maximum air pressure.");
                }
                else
                {
                    Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
            }
        }

        public void ShowLicensePlateOfVehiclesInGarage()
        {
            int userChoice;
            string inputFromUser;
            bool goodInput;
            List<string> listToPrintInGarage;

            Console.WriteLine("Choose which license plate to show: (1 - Show All, 2 - Filter status)");
            inputFromUser = Console.ReadLine();
            goodInput = int.TryParse(inputFromUser, out userChoice);
            if (goodInput)
            {
                if(userChoice == 1)
                {
                    Console.WriteLine("All The vehicles in the garage are:");
                    listToPrintInGarage = r_GarageManager.GetLicensePlateInGarage();
                    foreach (string licensePlateNumber in listToPrintInGarage)
                    {
                        Console.WriteLine(licensePlateNumber);
                    }
                }
                else if(userChoice == 2)
                {
                    Console.WriteLine("Choose which status plate you want to show:");
                    PrintEnumOptions(typeof(GarageCard.eVehicleState));
                    inputFromUser = Console.ReadLine();
                    listToPrintInGarage = r_GarageManager.GetLicensePlateInGarage(inputFromUser);
                    Console.WriteLine("All the vehicle is the requested status in the garage are:");
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
            if (goodInput && r_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                r_GarageManager.RefuelFuelVehicle(licenseNumber, fuelType, amountToRefuel);
                Console.WriteLine("The vehicle has been refueled!\n");
            }
            else if (!goodInput)
            {
                Console.WriteLine("You can refuel only decimal number.");
            }
            else // !r_GarageManager.IsVehicleInGarage(licenseNumber)
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
                if (goodInput && r_GarageManager.IsVehicleInGarage(licenseNumber))
                {
                    r_GarageManager.ChargeElectricVehicle(licenseNumber, amountToAdd);
                    Console.WriteLine("The vehicle has been charged!\n");
                }
                else if (!goodInput)
                {
                    Console.WriteLine("You can charge only decimal number.");
                }
                else // !r_GarageManager.IsVehicleInGarage(licenseNumber)
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
            if (r_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                vehicleDetails = r_GarageManager.GetVehicleDetails(licenseNumber);
                Console.WriteLine("The requested vehicle details are:");
                Console.WriteLine(vehicleDetails);
            }
            else
            {
                Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
            }
        }

        public void PrintMainMenu()
        {
            string mainMenuOptions = "\nPlease select one of the following options (a number between 1-7):\n"
                                     + "1 - Insert a new vehicle into the garage.\n"
                                     + "2 - Display all the vehicles currently in the garage. (with or without filter by their status)\n"
                                     + "3 - Change a vehicle's status.\n"
                                     + "4 - Inflate a specific vehicle's tires to maximum air pressure.\n"
                                     + "5 - Refuel a fuel based vehicle.\n" + "6 - Charge an electric based vehicle.\n"
                                     + "7 - Display a vehicle's full information.\n"
                                     + "8 - Quit the program\n";

            Console.WriteLine(mainMenuOptions);
        }

        public string GetValidInput(bool i_NeedToBeNumber)
        {
            string input = null;
            bool goodInput = false;

            while(!goodInput)
            {
                input = Console.ReadLine();
                if(i_NeedToBeNumber)
                {
                    goodInput = ((input.All(c => char.IsDigit(c) || c =='+' || c =='-') && !string.IsNullOrEmpty(input)));
                    if (!goodInput)
                    {
                        Console.WriteLine("Try again. need to contain only digits or + or -");
                    }
                }
                else
                {
                    goodInput = !string.IsNullOrEmpty(input);
                    if (!goodInput)
                    {
                        Console.WriteLine("Try again. can't be an empty line");
                    }
                }

                
            }

            return input;
        }

        public void InsertNewVehicleToGarage()
        {
            bool goodInput;
            bool needsToBeNumber = false;
            string licenseNumber, inputFromUser;
            eAvailableTypesOfVehicles vehicleType; 
            List<string> ownerVehicleInfo = new List<string>(); //Garage ticket

            Console.WriteLine("You chose option 1 to Insert a vehicle to the garage!");
            //1- string license number (plate?)
            Console.WriteLine("Please write the license number: ");
            needsToBeNumber = false;
            licenseNumber = GetValidInput(needsToBeNumber);
            if (!r_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Please write the owner name: ");
                needsToBeNumber = false;
                inputFromUser = GetValidInput(needsToBeNumber);
                ownerVehicleInfo.Add(inputFromUser);
                Console.WriteLine("Please write the owner phone number: ");
                needsToBeNumber = true;
                inputFromUser = GetValidInput(needsToBeNumber);
                ownerVehicleInfo.Add(inputFromUser);
                Console.WriteLine("Please select the type of the vehicle? (select the number next to the type)");
                PrintEnumOptions(typeof(eAvailableTypesOfVehicles));
                vehicleType = GetValidInputToTypesOfVehicles();

                // TODO put in enum and check if it is in the enum class
                //goodInput = eAvailableTypesOfVehicles.TryParse(inputFromUser, out vehicleType);

                Dictionary<string, Property> vehicleDictionary = r_GarageManager.InsertNewVehicleToGarage(vehicleType, licenseNumber, ownerVehicleInfo);

                foreach (KeyValuePair<string, Property> key in vehicleDictionary)
                {
                    bool good = false;
                    while(!good)
                    try
                    {
                        Console.WriteLine(key.Value.FormQuestion);
                        if(key.Value.MemberType.BaseType == typeof(Enum))
                        {
                            PrintEnumOptions(key.Value.MemberType);
                        }

                        inputFromUser = Console.ReadLine();
                        object parsedUserInput = r_GarageManager.TryParseToType(inputFromUser, key.Value.MemberType);
                        // if I'm here I didn't throw exception so the type is good
                        r_GarageManager.addParam(licenseNumber, parsedUserInput, key.Value.MemberName);
                        good = true;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("ERROR!!"); 
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Try again...\n"); 
                    }
                }
                Console.WriteLine("Congratulations! you created a new vehicle!\n");
            }
            else //Vihcle in the garage
            {
                r_GarageManager.ChangeVehicleStatus(licenseNumber, GarageCard.eVehicleState.InRepair);
            }
        }

        private eAvailableTypesOfVehicles GetValidInputToTypesOfVehicles()
        {
            bool isGoodInput = false;
            string inputFromUser;
            eAvailableTypesOfVehicles vehicleType = (eAvailableTypesOfVehicles)1;
            while(!isGoodInput)
            {
                inputFromUser = Console.ReadLine();
                isGoodInput = eAvailableTypesOfVehicles.TryParse(inputFromUser, out vehicleType);
                if(!isGoodInput)
                {
                    Console.WriteLine("You need to enter an integer number only from the range!"); //TODO add range
                }
            }

            return vehicleType;
        }

        public void PrintEnumOptions(Type i_EnumNamesToPrint)
        {
            int index = 1;
            int printedIndex = (int)Enum.GetValues(i_EnumNamesToPrint).GetValue(0);
            Console.Write("(");
            foreach (string name in Enum.GetNames(i_EnumNamesToPrint))
            {
                if(index != 1)
                {
                    Console.Write(",");
                }
                printedIndex = (int)Enum.GetValues(i_EnumNamesToPrint).GetValue(index-1);
                Console.Write($" {printedIndex} - {name}");
                ++index;
                ++printedIndex;
            }

            Console.WriteLine(" )");
        }

        public void QuitProgram()
        { 
           Console.WriteLine("Thank you for using our program! BYE.......");
           m_GameLoop = false;
        }

        public enum eMainMenuOptions
        {
            Option1 = 1,
            Option2,
            Option3,
            Option4,
            Option5,
            Option6,
            Option7,
            Option8
        }

    }
}
