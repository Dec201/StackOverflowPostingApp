using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static PostingApp.CreateAccount;

namespace PostingApp
{
    public class MainMenu 
    {


        public static List<User> UserList = new List<User>();
        public static List<PostMenu> PostList = new List<PostMenu>();
        public static bool LoggedIn;
        public static string CurrentUser;


        public static void PostMainMenu()
        {

            bool inputPass;
            int userSelection;
            Console.ForegroundColor = ConsoleColor.Cyan;

            do
            {

                Console.Clear();

                if(LoggedIn)
                {
                    Console.WriteLine($"Hello {CurrentUser}, welcome to the PostApp\n\n");
                }


                Console.WriteLine("Post Main Menu \n\n");

                Console.WriteLine("Select from the following options \n\n" +
                    "1. Setup a user account \n" +
                    "2. Login into account \n" +
                    "3. Create a new post\n" +
                    "4. Show all posts\n" +
                    "5. Edit an old post\n" +
                    "6. Exit Application\n\n");


                string userInput = Console.ReadLine();
                inputPass = int.TryParse(userInput, out userSelection);

                if(userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine("You need to select a number between 1 - 6");
                    Console.WriteLine("Press enter to continue....");
                    Console.ReadLine();
                    Console.Clear();
                    inputPass = false;
                }    

            } while (!inputPass);
            

            switch (userSelection)
            {
                case 1:
                    CreateUser(CurrentUser);
                    break;                
                case 2:
                   AccountLogin.Login();
                    break;
                case 3:
                    CreatePost.CreateNewPost();
                    break;
                case 4:
                    ShowAllPosts();
                    break;
                case 5:
                    EditingPosts.EditPost();
                    break;
                case 6:
                    QuitMenu();
                    break;
                default:
                    break;
            }


        }


        public static void QuitMenu()
        {
            Console.WriteLine("Are you sure you want to quit.\n" +
                "Type q to quit the application or press enter to return to the main menu.");

            string userQuitInput = Console.ReadLine();

            if(userQuitInput == "q")
            {
                Program.QuitApplication = true;
            }
            else
            {
                PostMainMenu();
            }

        }





        public static void ShowAllPosts()
        {

            Console.Clear();

            if (PostList.Count == 0)
            {
                Console.WriteLine("There are current no posts in the database\n\n");
            }
            else
            {

                Console.WriteLine("Showing all posts in the database\n");

                foreach (var postList in PostList)
                {

                    Console.WriteLine($"Id [{postList.Id}]\n" +
                        $"Title - {postList.PostTitle}\n" +
                        $"Description - {postList.PostDescription}\n" +
                        $"Author - {postList.PostAuthor}");
                    if (postList.PostLastEdited is not null)
                    {
                        Console.WriteLine($"Time Edited - {postList.PostLastEdited}\n\n");
                    }
                    else
                    {
                        Console.WriteLine($"Time Created - {postList.PostTime}\n\n");
                    }

                }
            }
            Console.WriteLine("To return back to the main menu please press enter");

            Console.ReadLine();

            PostMainMenu();

        }
    }
}
