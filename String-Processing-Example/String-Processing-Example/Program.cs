using System;

namespace String_Processing_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("´The program will process your social security number.");
            char userSelection;
            do
            {
                //Console.Clear();
                userSelection = UserInterface();
                switch (userSelection)
                {
                    case 'C':
                        SSNchecker();//Calling SSN checking function.
                        break;
                    case 'N':
                        SSNCreator(); //Calling SSN creating function.
                        break;
                    case 'X':
                        break;
                    default:
                        Console.WriteLine("Invalid input, please check your input. To resume the program, press enter.");
                        Console.ReadKey();
                        break;

                }
            } while (userSelection != 'X');          


        }//End main program
        static char UserInterface()
        {
            Console.WriteLine("Processing your social security number.");
            Console.WriteLine("[C] Check the validity of your social security number.");
            Console.WriteLine("[N] Create a new social security number.");
            Console.WriteLine("[X] Abort program.");
            Console.Write("Choose an option: ");
            return char.ToUpper(Console.ReadKey().KeyChar);
        }
        static void SSNCreator()
        {
            Console.Write("\nInput the beginning portion of a social security number with the following format [DDMMYY-XXX]: "); //" 15  03   11 - 132"
            string userInput = Console.ReadLine();
            userInput = InputTrimmer(userInput);
            if(isValidLength(userInput, 10))
            {
                if (isValidDate(userInput))
                {
                   int idNumber = InputParser(userInput);
                    char getValidationSymbol = GetValidationSymbol(idNumber);
                    PrintSSNumber($"{userInput} {getValidationSymbol}");

                }
            } 
        }

        static void SSNchecker()
        {
            Console.Write("\nInput a social security number with the following format [DDMMYY-XXXT] to be checked: ");
            string userInput = Console.ReadLine();
            userInput = InputTrimmer(userInput);
            if (isValidLength(userInput))
            {
                
                int idNumber = InputParser(userInput);
                char getLastChar = GetUserInputChkMark(userInput);
                bool isOK = isValidID(idNumber, getLastChar);
                isValidID(idNumber, getLastChar);
                PrintResult(isOK);
            }
            else
            {
                Console.WriteLine("Invalid length, please check your input.");

            }
        }

      
        static bool isValidDate(string userInput)
        {
            //string birthdate = userInput.Substring(0, 6);
            //string removed = userInput.Remove(6, 1);
            //foreach (char A in removed)
            bool result = false;
            string day = userInput.Substring(0, 2);
            string month = userInput.Substring(2, 2);
            string year = userInput.Substring(4, 2);
            string century = userInput.Substring(6, 1);
            if (century == "-")
            {
                year = "19" + year;
            }
            else if (century == "A")
            {
                year = "20" + year;

            }
            else
            {
                Console.WriteLine("Väärä vuosisata.");
                return result;
            }
            //Checking validity of the input date in a try-catch segment
            try
            {
                DateTime birthday = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid date, please check your input.");
            }
            return result;
        }
        static bool isValidLength(string userInput)
        {
            return userInput.Length == 11;
        }
        static bool isValidLength(string userInput, int length)
        {
            return userInput.Length == length;
           // if (userInput.Length == 11)
           //     return true;
           // else if (userInput.Length == 10)
           //    return true;
           // else
           //     return false;
        }

        static string InputTrimmer(string userInput)
        {
            string result = userInput.Replace(" ", "");
            return result;
        }
        static char GetUserInputChkMark(string userInput)
        {
            return userInput[userInput.Length - 1];
        }
        static int InputParser(string Parse)
        {
            //Read first six digits and store them to birthdate
            // string birthdate = P.Substring(0, 6);
            string removed = Parse;
          if (Parse.Length > 10) // Condition set to eliminate the possiblity of too lo
            {
                removed = Parse.Remove(10, 1);
            }
            
            removed = removed.Remove(6, 1);
            return int.Parse(removed);

        }
        static char GetValidationSymbol(int idNumber)
        {
            //Validate social number authenticity
            string chkMark = "0123456789ABCDEFHJKLMNPRUSTUWXY";
            int modChk = idNumber % 31;
            //Checking if the userInput matches calculated value
            return chkMark[modChk];
            //return chkMark[modChk] == userInputChkMark;
        }
        static bool isValidID(int idNumber, char userInputChkMark)
        {
            //Validate social number authenticity
            string chkMark = "0123456789ABCDEFHJKLMNPRUSTUWXY";
            int modChk = idNumber % 31;
            //Checking if the userInput matches calculated value
            if (chkMark[modChk] == userInputChkMark)
                return true;
            else
                return false;
            //return chkMark[modChk] == userInputChkMark;
        }
        static void PrintResult(bool isValidId)
        {
            if (isValidId)
                Console.WriteLine("Valid SSN!");
            else
                Console.WriteLine("Invalid SSN!");
        }
        static void PrintSSNumber(string newSSNumber)
        {
            Console.WriteLine($"Created social security number: {newSSNumber}");
        }




    }
}
