using Engine;
using System;
using System.Collections.Generic;
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
                }
                else
                {
                    Console.WriteLine($"There isn't any vehicle with {licenseNumber} license plate.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                                     + "7 - Display a vehicle's full information.\n"
                                     + "8 - Quit the program\n";

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

            if (!r_GarageManager.IsVehicleInGarage(licenseNumber))
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
                Console.WriteLine("Please select the type of the vehicle? (select the number next to the type)");
                PrintEnumOptions(typeof(eAvailableTypesOfVehicles));
                inputFromUser = Console.ReadLine();

                // TODO put in enum and check if it is in the enum class
                goodInput = eAvailableTypesOfVehicles.TryParse(inputFromUser, out vehicleType);

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
                        Console.WriteLine("ERROR!!"); //TODO change to properly maybe put in while
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Try again...\n"); //TODO change to properly maybe put in while
                    }
                }
                Console.WriteLine("Congratulations! you created a new vehicle!\n");

                //r_GarageManager.UpdateVehicle(licenseNumber, specificTypeOfVehicleInfo);

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


                r_GarageManager.InsertNewVehicleToGarage(
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
                r_GarageManager.ChangeVehicleStatus(licenseNumber, GarageCard.eVehicleState.InRepair);
            }

        }







        //public void InsertNewVehicleToGarage()
        //{
        //    bool goodInput;
        //    string licenseNumber, inputFromUser;
        //    eAvailableTypesOfVehicles vehicleType; //TODO can i use it without the class name before?
        //    List<string> ownerVehicleInfo = new List<string>(); //Garage ticket
        //    List<string> commonVehicleInfo = new List<string>(); //Vehicle
        //    List<string> commonTypeOfVehicleInfo = new List<string>(); //Car / Motorcycle
        //    List<string> specificTypeOfVehicleInfo = new List<string>(); // engine / fuel (car / Motorcycle)

        //    Console.WriteLine("You chose option 1 to Insert a vehicle to the garage!");
        //    //1- string license number (plate?)
        //    Console.WriteLine("Please write the license number: ");
        //    licenseNumber = Console.ReadLine();

        //    if(!r_GarageManager.IsVehicleInGarage(licenseNumber))
        //    {
        //        commonVehicleInfo.Add(licenseNumber); //licenseNumber

        //        //2- string owner name
        //        Console.WriteLine("Please write the owner name: ");
        //        inputFromUser = Console.ReadLine();
        //        ownerVehicleInfo.Add(inputFromUser);

        //        //3- string owner phone number
        //        Console.WriteLine("Please write the owner phone number: ");
        //        inputFromUser = Console.ReadLine();
        //        ownerVehicleInfo.Add(inputFromUser);

        //        //4- enum type of vehicle -- look at 9
        //        Console.WriteLine("Please select the type of the vehicle? (select the number next to the type)"); 
        //        PrintEnumOptions(typeof(eAvailableTypesOfVehicles));
        //        inputFromUser = Console.ReadLine();

        //        // TODO put in enum and check if it is in the enum class
        //        goodInput = eAvailableTypesOfVehicles.TryParse(inputFromUser, out vehicleType);

        //        List<string> vehicleQuestions =  r_GarageManager.InsertNewVehicleToGarage(vehicleType, licenseNumber);

        //        foreach(string question in vehicleQuestions)
        //        {
        //            Console.WriteLine(question);
        //            inputFromUser = Console.ReadLine();
        //            specificTypeOfVehicleInfo.Add(inputFromUser);
        //        }

        //        //r_GarageManager.UpdateVehicle(licenseNumber, specificTypeOfVehicleInfo);

        //        /*
        //        //5- string module name
        //        Console.WriteLine("Please write the module name: ");
        //        inputFromUser = Console.ReadLine();
        //        commonVehicleInfo.Add(inputFromUser);

        //        //6- list wheels
        //        Console.WriteLine("Please write the data about the tires: ");
        //        Console.WriteLine("Please write the name of the manufacture: ");
        //        inputFromUser = Console.ReadLine();
        //        commonVehicleInfo.Add(inputFromUser); // a- manufactureName

        //        Console.WriteLine("Please write the current air pressure of the tire: ");
        //        inputFromUser = Console.ReadLine();
        //        commonVehicleInfo.Add(inputFromUser); // b- current air pressure


        //        //7- state of the car is - "בתיקון"

        //        //8- another switch case by the enum module we found to add data to build the right vehicle
        //        switch(vehicleType ) 
        //        {
        //            case eAvailableTypesOfVehicles.FuelMotorcycle:
        //            case eAvailableTypesOfVehicles.ElectricMotorcycle:
        //                // Motorcycle-
        //                //10 -type of license
        //                Console.WriteLine("Please write your type of license: ");
        //                inputFromUser = Console.ReadLine();
        //                commonTypeOfVehicleInfo.Add(inputFromUser); //string

        //                //11 -capacity
        //                Console.WriteLine("Please write your engine capacity: ");
        //                inputFromUser = Console.ReadLine();
        //                commonTypeOfVehicleInfo.Add(inputFromUser); //int

        //                // 12
        //                Console.WriteLine("Please write the current amount of fuel: ");
        //                inputFromUser = Console.ReadLine();
        //                specificTypeOfVehicleInfo.Add(inputFromUser); //float

        //                break;
        //            case eAvailableTypesOfVehicles.FuelCar:
        //            case eAvailableTypesOfVehicles.ElectricCar:
        //                //10 -type of color
        //                Console.WriteLine("Please write your type of color: ");
        //                inputFromUser = Console.ReadLine();
        //                commonTypeOfVehicleInfo.Add(inputFromUser); //enum

        //                //11 - amount of doors
        //                Console.WriteLine("Please write the amount of doors: ");
        //                inputFromUser = Console.ReadLine();
        //                commonTypeOfVehicleInfo.Add(inputFromUser); //int - TODO: add enum of the amount of doors

        //                // 12
        //                Console.WriteLine("Please write the current amount of fuel: ");
        //                inputFromUser = Console.ReadLine();
        //                specificTypeOfVehicleInfo.Add(inputFromUser); //float

        //                break;

        //            case eAvailableTypesOfVehicles.Truck:
        //                //10 -type of color
        //                Console.WriteLine("Please write if you carry dangerous materials (Y-yes or N-no): ");
        //                inputFromUser = Console.ReadLine();
        //                commonTypeOfVehicleInfo.Add(inputFromUser); //bool

        //                // 11 - max carry weight 
        //                Console.WriteLine("Please write your max carry weight : ");
        //                inputFromUser = Console.ReadLine();
        //                commonTypeOfVehicleInfo.Add(inputFromUser); //float

        //                // 12
        //                Console.WriteLine("Please write the current amount of fuel: ");
        //                inputFromUser = Console.ReadLine();
        //                specificTypeOfVehicleInfo.Add(inputFromUser); //float

        //                break;
        //        }


        //        r_GarageManager.InsertNewVehicleToGarage(
        //            vehicleType,
        //            ownerVehicleInfo,
        //            commonVehicleInfo,
        //            commonTypeOfVehicleInfo,
        //            specificTypeOfVehicleInfo);
        //        */
        //    }
        //    else //Vihcle in the garage
        //    {
        //        //change status to in repair
        //        r_GarageManager.ChangeVehicleStatus(licenseNumber, GarageCard.eVehicleState.InRepair);
        //    }

        //}

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

                Console.Write($" {printedIndex} - {name}");
                ++index;
                ++printedIndex;
            }

            Console.WriteLine(" )");
        }

        public void QuitProgram()
        {
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
