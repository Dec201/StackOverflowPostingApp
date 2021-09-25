using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingApp
{
    public class CreateAccount
    {

        public static void CreateUser(string currentUsername)
        {

            string password;
            string confirmPassword;
            string userName;
            bool success;


            Console.WriteLine("You have selected option 1,\nplease answer the following questions to create an account\n\n");


            do
            {
                Console.WriteLine("Type in your username");
                userName = Console.ReadLine();

                if (MainMenu.UserList.Any(x => x.UserName == userName) || userName.Length < 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n\nThat username has already been taken, or your username is less than 3 characters.\n" +
                        "Please choose another, thank you!\n");
                    success = false;
                }
                else
                {
                    success = true;
                }

            } while (!success);



                do
            {
                Console.WriteLine("\nType in your password");
                password = Console.ReadLine();

                Console.WriteLine("\nPlease re-type your password to confirm");
                confirmPassword = Console.ReadLine();

                if((password != confirmPassword) || password.Length < 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n\nYour password and confirmed password need to match, plus you password has to be more than 3 characters.\n" +
                        "Please retype them in.\n\n");
                    success = false;
                }
                else
                {
                    success = true;
                }

            } while (!success);




            var newUser = new User()
            {
                UserId = User.GetNextID(),
                UserName = userName,
                Password = password,
                ConfirmPassword = confirmPassword,
                AccountCreated = DateTime.UtcNow
            };


            MainMenu.UserList.Add(newUser);

            Console.WriteLine($"\nCongratulations {newUser.UserName}, you have created a new account" +
                $"\nYour Id : {newUser.UserId}\n\n" +
                $"Press enter to return to the main menu");
            Console.ReadLine();

            MainMenu.PostMainMenu();

        }

    }
}
