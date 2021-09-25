using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingApp
{
    public class AccountLogin
    {


        public static void Login()
        {

            string userNameInput;
            string userPasswordInput;


            Console.WriteLine("\n\nPlease type in your UserName");
            userNameInput = Console.ReadLine();
            Console.WriteLine("Please type in your Password");
            userPasswordInput = Console.ReadLine();


            foreach (var item in MainMenu.UserList.ToList())
            {

                if (item.UserName == userNameInput && item.Password == userPasswordInput)
                {
                    MainMenu.LoggedIn = true;
                    MainMenu.CurrentUser = userNameInput;
                    MainMenu.PostMainMenu();
                }

            }

            if(MainMenu.LoggedIn)
            {
                Console.WriteLine("\nYou have typed in the wrong User Id, username or password. \nYou have been logged out.\n" +
                    "Press enter to continue");
                MainMenu.LoggedIn = false;
            }
            else
            {
                Console.WriteLine("\nYou have typed in the wrong User Id, username or password. \nPress enter to continue");
            }

            Console.ReadLine();
            MainMenu.PostMainMenu();


        }




    }
}
