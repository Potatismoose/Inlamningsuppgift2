using Inlamningsuppgift2.Statics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Inlamningsuppgift2
{
    class Start
    {
        static string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //En array som håller koll på mappsökvägarna för programmet. 
        //Skapade en array då jag inte vet om jag kommer använda fler mappar än den i det första indexet.
        static string[] path = new string[1] { myDocs + @"\Classmates\"};



        /*
        -------------------------------------------------------------------------
                                PROGRAMMET STARTAR HÄR!!!
        -------------------------------------------------------------------------
        */
        public static void StartProgram() 
        {
            //om mappen inte finns i mina dokument så skapas den
            if (!Outputs.TestDirExistance(path[0]))
            {
                //Skapar en mapp i mina dokument som heter Classmates
                Directory.CreateDirectory(path[0]);
            }
            //Om inte filen logo.txt finns så skapas den
            if (!Outputs.TestFileExistance("logo.txt", path[0]))
            {
                //Skapar filen logo.txt
                Outputs.CreateFile("logo.txt", path);
                
            }
            
            //Därefter skrivs loggan ut
            Outputs.LogoPrint(path[0]+"logo.txt");
            Outputs.UserLogin();
        
        }
        
    }
}
