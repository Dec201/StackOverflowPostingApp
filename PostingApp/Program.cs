using System;
using System.Collections.Generic;

namespace PostingApp
{
    public class Program
    {

        public static bool QuitApplication;


        static void Main(string[] args)
        {

            do
            {


                MainMenu.PostMainMenu();



            } while (!QuitApplication);


        }
    }
}
