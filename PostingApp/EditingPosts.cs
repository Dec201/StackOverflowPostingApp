using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PostingApp
{
    public class EditingPosts
    {


        public static void EditPost()
        {

            bool success;
            string postDescription;
            int selectedPostId;

            Console.Clear();

            if (MainMenu.CurrentUser == null)
            {
                Console.WriteLine("You have not logged into your account, please login first.\n" +
                    "Press enter to return back to the main page");
                Console.ReadLine();
                MainMenu.PostMainMenu();
            }

            var usersPosts = MainMenu.PostList.FindAll(x => x.PostAuthor == MainMenu.CurrentUser);

            if (usersPosts.Count == 0)
            {
                Console.WriteLine("You do not have any posts in the database.\n" +
                    "You will need to create one in order to edit one");
            }


            foreach (var postList in usersPosts)
            {

                Console.WriteLine("Below are a list of all your posts on the database\n");

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


            try
            {

                do
                {

                    Console.WriteLine("Type in your post Id in order to change your post");
                    selectedPostId = int.Parse(Console.ReadLine());

                    if(usersPosts.Any(x => x.Id == selectedPostId))
                    {
                        success = true;
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou have selected an Id that does not match any of your posts.\n" +
                                                       "Please try again. Thank you.\n");
                        success = false;
                    }

                } while (!success);


                do
                {
                    Console.WriteLine("Type out the contents of your post");
                    postDescription = Console.ReadLine();

                    if (postDescription.Length < 3)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nYour post description needs to be longer than 3 characters.\n" +
                            "Please try again. Thank you.\n");
                        success = false;
                    }
                    else
                    {
                        success = true;
                    }

                } while (!success);


                MainMenu.PostList[selectedPostId].PostDescription = postDescription;
                MainMenu.PostList[selectedPostId].PostLastEdited = DateTime.UtcNow;

            }
            catch (Exception)
            {

                Console.WriteLine("Your post Id does not match up with any of your current posts.\n" +
                    "Please press enter to return to the main page");
                Console.ReadLine();

            }



            MainMenu.PostMainMenu();


        }
    }
}