using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using static Ex03.GarageLogic.VehicleFactory;

namespace Ex03.ConsoleUI
{
    class GarageProgram
    {
        private readonly GarageManager r_GarageManager = new GarageManager();
        private bool m_GameLoop = true;
        private const int k_StartIndexOfEnum = 1;

        public enum eMainMenuOptions
        {
            Option1 = k_StartIndexOfEnum,
            Option2,
            Option3,
            Option4,
            Option5,
            Option6,
            Option7,
            Option8
        }

        public void StartProgram()
        {
            string inputFromUser;
            bool goodInput;
            eMainMenuOptions UserChoiceWhatToDo;

            Console.WriteLine("Welcome, thanks for choosing our Garage Factory program! we know you had a lot of choices.. Good Luck! (=");
            while (m_GameLoop) 
            {
                printMainMenu();
                inputFromUser = Console.ReadLine();
                goodInput = Enum.TryParse(inputFromUser, out UserChoiceWhatToDo);
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

        public void InsertNewVehicleToGarage()       // Option 1 in main menu 
        {
            bool isNeededToBeNumber;
            string licenseNumber, inputFromUser;
            eAvailableTypesOfVehicles vehicleType;
            List<string> ownerVehicleInfo = new List<string>();
            Dictionary<string, Property> vehiclePropertiesDictionary = null;

            Console.WriteLine("Please write the license number: ");
            isNeededToBeNumber = false;
            licenseNumber = getValidInput(isNeededToBeNumber);
            if (!r_GarageManager.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Please write the owner name: ");
                isNeededToBeNumber = false;
                inputFromUser = getValidInput(isNeededToBeNumber);
                ownerVehicleInfo.Add(inputFromUser);
                Console.WriteLine("Please write the owner phone number: ");
                isNeededToBeNumber = true;
                inputFromUser = getValidInput(isNeededToBeNumber);
                ownerVehicleInfo.Add(inputFromUser);
                Console.WriteLine("Please select the type of the vehicle? (select the number next to the type)");
                PrintEnumOptions(typeof(eAvailableTypesOfVehicles));
                vehicleType = getValidInputToTypesOfVehicles();
                vehiclePropertiesDictionary = r_GarageManager.InsertNewVehicleToGarage(vehicleType, licenseNumber, ownerVehicleInfo);
                foreach (KeyValuePair<string, Property> key in vehiclePropertiesDictionary)
                {
                    bool good = false;
                    while (!good)
                        try
                        {
                            Console.WriteLine(key.Value.FormQuestion);
                            if (key.Value.MemberType.BaseType == typeof(Enum))
                            {
                                PrintEnumOptions(key.Value.MemberType);
                            }

                            inputFromUser = Console.ReadLine();
                            object parsedUserInput = r_GarageManager.TryParseToType(inputFromUser, key.Value.MemberType);
                            // if I'm here I didn't throw exception so the type is good
                            r_GarageManager.addParam(licenseNumber, parsedUserInput, key.Value.MemberName);
                            good = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ERROR!!");
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Try again...\n");
                        }
                }

                Console.WriteLine("Congratulations! you created a new vehicle!\n");
            }
            else    // vehicle in the garage
            {
                r_GarageManager.ChangeVehicleStatus(licenseNumber, GarageCard.eVehicleState.InRepair);
                Console.WriteLine("The vehicle is already in the system.");
            }
        }

        public void ShowLicensePlateOfVehiclesInGarage()       // Option 2 in main menu
        {
            int userChoice;
            string inputFromUser;
            bool isGoodInput;
            List<string> listToPrintInGarage;
            bool isSucceeded = false;

            while(!isSucceeded)
            {
                try
                {
                    Console.WriteLine("Choose which licenses plate to show: (1 - Show All, 2 - Filter status)");
                    inputFromUser = Console.ReadLine();
                    isGoodInput = int.TryParse(inputFromUser, out userChoice);
                    if(isGoodInput)
                    {
                        if(userChoice == 1)
                        {
                            listToPrintInGarage = r_GarageManager.GetLicensePlateInGarage();
                            if(listToPrintInGarage.Count == 0)
                            {
                                Console.WriteLine("There isn't any vehicles in the system");
                            }
                            else
                            {
                                Console.WriteLine("All The vehicles in the garage are:");
                                foreach (string licensePlateNumber in listToPrintInGarage)
                                {
                                    Console.WriteLine(licensePlateNumber);
                                }
                            }

                            isSucceeded = true;
                        }
                        else if(userChoice == 2)
                        {
                            Console.WriteLine("Choose which status plate you want to show:");
                            PrintEnumOptions(typeof(GarageCard.eVehicleState));
                            inputFromUser = Console.ReadLine();
                            listToPrintInGarage = r_GarageManager.GetLicensePlateInGarage(inputFromUser);
                            if (listToPrintInGarage.Count == 0)
                            {
                                Console.WriteLine("There isn't any vehicles with the requested status in the system");
                            }
                            else
                            {
                                Console.WriteLine("All the vehicle with the requested status in the garage are:");
                                foreach(string licensePlateNumber in listToPrintInGarage)
                                {
                                    Console.WriteLine(licensePlateNumber);
                                }
                            }

                            isSucceeded = true;
                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid option, pay attention to the instructions");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You need to insert only an integer number! only 1 or 2");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ChangeVehicleStatus()       // Option 3 in main menu
        {
            string licenseNumber, inputFromUser;
            bool isSucceeded = false;

            while(!isSucceeded)
            {
                Console.WriteLine("Enter license plate number:");
                licenseNumber = Console.ReadLine();
                try
                {
                    if(r_GarageManager.IsVehicleInGarage(licenseNumber))
                    {
                        Console.WriteLine("Enter the new status:");
                        PrintEnumOptions(typeof(GarageCard.eVehicleState));
                        inputFromUser = Console.ReadLine();
                        r_GarageManager.ChangeVehicleStatus(licenseNumber, inputFromUser);
                        Console.WriteLine("The status of the vehicle has been changed!");
                       isSucceeded = true;
                    }
                    else
                    {
                        if(r_GarageManager.IsGarageEmpty())
                        {
                            Console.WriteLine("The garage is empty, try to insert vehicles with option 1 first.");
                            isSucceeded = true;
                        }
                        else
                        {
                            Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void InflateVehicleTires()       // Option 4 in main menu
        {
            string licenseNumber; 
            bool isSucceeded = false;

            while(!isSucceeded)
            {
                Console.WriteLine("Enter license plate number:");
                licenseNumber = Console.ReadLine();
                try
                {
                    if(r_GarageManager.IsVehicleInGarage(licenseNumber))
                    {
                        r_GarageManager.InflateTiresAirToMaximum(licenseNumber);
                        Console.WriteLine("The vehicle tires has been inflated to maximum air pressure.");
                        isSucceeded = true;
                    }
                    else
                    {
                        if (r_GarageManager.IsGarageEmpty())
                        {
                            Console.WriteLine("The garage is empty, try to insert vehicles with option 1 first.");
                            isSucceeded = true;
                        }
                        else
                        {
                            Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void RefuelVehicle()       // Option 5 in main menu
        {
            float amountToRefuel;
            string fuelType,licenseNumber, inputFromUser;
            bool goodInput,isSucceeded = false;
            int enumNumber;

            while (!isSucceeded)
            {
                try
                {
                    Console.WriteLine("Enter license plate number:");
                    licenseNumber = Console.ReadLine();
                    if(r_GarageManager.IsVehicleInGarage(licenseNumber))
                    {
                        Console.WriteLine("Enter the type of fuel:");
                        PrintEnumOptions(typeof(FuelEngine.eVehicleFuelType));
                        fuelType = Console.ReadLine();
                        goodInput = int.TryParse(fuelType, out enumNumber);
                        if(goodInput)
                        {
                            goodInput = false;
                            if(Enum.IsDefined(typeof(FuelEngine.eVehicleFuelType), enumNumber))
                            {
                                Console.WriteLine("Enter the amount to refuel:");
                                inputFromUser = Console.ReadLine();
                                goodInput = float.TryParse(inputFromUser, out amountToRefuel);
                                if (goodInput)
                                {
                                    r_GarageManager.RefuelFuelVehicle(licenseNumber, fuelType, amountToRefuel);
                                    Console.WriteLine("The vehicle has been refueled!\n");
                                    isSucceeded = true;
                                }
                                else
                                {
                                    Console.WriteLine("You can refuel only decimal number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You entered an invalid option, pay attention to the instructions!");
                            }
                        }
                    }
                    else // !r_GarageManager.IsVehicleInGarage(licenseNumber)
                    {
                        if(r_GarageManager.IsGarageEmpty())
                        {
                            Console.WriteLine("The garage is empty, try to insert vehicles with option 1 first.");
                            isSucceeded = true;
                        }
                        else
                        {
                            Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goodInput = false;
                    isSucceeded = true;
                }
            }
        }

        public void ChargeElectricVehicle()       // Option 6 in main menu
        {
            string inputFromUser, licenseNumber;
            float amountToAdd;
            bool goodInput,isSucceeded = false;

            while(!isSucceeded)
            {
                try
                {
                    Console.WriteLine("Enter license plate number:");
                    licenseNumber = Console.ReadLine();
                    if(r_GarageManager.IsVehicleInGarage(licenseNumber))
                    {
                        Console.WriteLine("Enter the hours to charge:");
                        inputFromUser = Console.ReadLine();
                        goodInput = float.TryParse(inputFromUser, out amountToAdd);
                        if(goodInput)
                        {
                            r_GarageManager.ChargeElectricVehicle(licenseNumber, amountToAdd);
                            Console.WriteLine("The vehicle has been charged!\n");
                            isSucceeded = true;
                        }
                        else if(!goodInput)
                        {
                            Console.WriteLine("You can charge only decimal number.");
                        }
                    }
                    else // !r_GarageManager.IsVehicleInGarage(licenseNumber)
                    {
                        if(r_GarageManager.IsGarageEmpty())
                        {
                            Console.WriteLine("The garage is empty, try to insert vehicles with option 1 first.");
                            isSucceeded = true;
                        }
                        else
                        {
                            Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goodInput = false;
                    isSucceeded = true;
                }
            }
        }

        public void ShowVehicleDetails()       // Option 7 in main menu
        {
            string vehicleDetails, licenseNumber;
            bool isSucceeded= false;

            while(!isSucceeded)
            {
                try
                {
                    Console.WriteLine("Enter license plate number:");
                    licenseNumber = Console.ReadLine();
                    if(r_GarageManager.IsVehicleInGarage(licenseNumber))
                    {
                        vehicleDetails = r_GarageManager.GetVehicleDetails(licenseNumber);
                        Console.WriteLine("The requested vehicle details are:");
                        Console.WriteLine(vehicleDetails);
                        isSucceeded = true;
                    }
                    else
                    {
                        if(r_GarageManager.IsGarageEmpty())
                        {
                            Console.WriteLine("The garage is empty, try to insert vehicles with option 1 first.");
                            isSucceeded = true;
                        }
                        else
                        {
                            Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void printMainMenu()
        {
            string mainMenuOptions = "\nPlease select one of the following options (a number between 1-8):\n"
                                     + "1 - Insert a new vehicle into the garage.\n"
                                     + "2 - Display all the vehicles currently in the garage. (with or without filter by their status)\n"
                                     + "3 - Change a vehicle's status.\n"
                                     + "4 - Inflate a specific vehicle's tires to maximum air pressure.\n"
                                     + "5 - Refuel a fuel based vehicle.\n" + "6 - Charge an electric based vehicle.\n"
                                     + "7 - Display a vehicle's full information.\n"
                                     + "8 - Quit the program\n";

            Console.WriteLine(mainMenuOptions);
        }

        private string getValidInput(bool i_NeedToBeNumber)
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

        private eAvailableTypesOfVehicles getValidInputToTypesOfVehicles()
        {
            bool isGoodInput = false;
            string inputFromUser;
            eAvailableTypesOfVehicles vehicleType = (eAvailableTypesOfVehicles)1;
            while(!isGoodInput)
            {
                int enumNumber;
                
                inputFromUser = Console.ReadLine();
                isGoodInput = int.TryParse(inputFromUser, out enumNumber);
                if(isGoodInput)
                {
                    if (!Enum.IsDefined(typeof(eAvailableTypesOfVehicles), enumNumber))
                    {
                        Console.WriteLine("The number must be in the given range!");
                        isGoodInput = false;
                    }
                    else
                    {
                        isGoodInput = Enum.TryParse(inputFromUser, out vehicleType);
                    }
                }
                else
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
    }
}
