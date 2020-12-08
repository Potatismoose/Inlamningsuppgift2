using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inlamningsuppgift2.Statics
{
    class Outputs
    {
        

        public static void LogoPrint(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Console.WriteLine(line);

            }
        }
        //Metod för att kontrollera om mappen finns. 
        public static bool TestDirExistance(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }

            //Metod för att kolla om filen finns i dokumentmappen
            public static bool TestFileExistance(string fileName, string path)
        {
            
            switch (fileName)
            {
                //Kontroll för logo.txt filen
                case "logo.txt":
                    if (File.Exists(path + fileName))
                    {
                        return true;
                    }
  
                    else
                    {
                        return false;
                    }

                default:
                    return false;
                    
            }
            
        }

        //Metod som skapar en fil med det filnamn som skickas in.
        public static void CreateFile(string fileName, string[] path)
        {
            
            if (fileName == "logo.txt")
            {
                using FileStream fs = File.Create($"{path[0]}{fileName}");
                fs.Close();
                //Skriver en logga till filen
                //SträngArray som skrivs till logo.txt
                string[] logoPrint = {
                " ,-----.,--.                                          ,--.",
                "'  .--./|  | ,--,--. ,---.  ,---. ,--,--,--. ,--,--.,-'  '-. ,---.   ,---.  ",
                "|  |    |  |' ,-.  |(  .-' (  .-' |        |' ,-.  |'-.  .-'| .-. : (  .-'  ",
                @"'  '--'\|  |\ '-'  |.-' `) .-' `) |  |  |  |\ '-'  |  |  |  \   --. .-' `) ",
                " `-----'`--' `--`--'`----' `----' `--`--`--' `--`--'  `--'   `----' `----' "
                       };
                //Skriver loggan till Documents\Classmates\logo.txt
                using (StreamWriter file =
                new StreamWriter($"{path[0]}logo.txt"))
                {
                    //Skriver varje index i arrayen till en ny rad i filen.
                    foreach (string line in logoPrint)
                    {
                        file.WriteLine(line);
                    }
                }
            }
        }


        public static void UserLogin(string[] path)
        {
            bool loggedIn = default(bool);
            string error = default(string);
            
            do
            {
                Console.Clear();
                Outputs.LogoPrint(path[0] + "logo.txt");
                
                if (!string.IsNullOrEmpty(error))
                {
                    
                    Console.SetCursorPosition(25, 7);
                    Console.WriteLine(error);
                    
                    error = default(string);
                }
                Console.SetCursorPosition(25, 6);
                var pass = default(string);
                ConsoleKey key;
                
                Console.Write("Ange lösenordet$> ");
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        Console.Write("\b \b");
                        pass = pass[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        pass += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);
                string loginCredentials = pass;

                switch (loginCredentials.ToLower())
                {
                    case "norrlänningarna":
                        loggedIn = true;
                        break;
                    default:
                        error = "Fel lösenord, försök igen";
                        break;
                }
            } while (!loggedIn);
            

        }
    }

    

}

