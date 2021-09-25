using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingApp
{
    public class CreatePost
    {


        public static void CreateNewPost()
        {

            string postTitle;
            string postDescription;
            bool success;

            if (MainMenu.LoggedIn)
            {



                do
                {
                    Console.WriteLine("\n\nType your post title");
                    postTitle = Console.ReadLine();

                    Console.WriteLine("Type out the contents of your post");
                    postDescription = Console.ReadLine();

                    if (postTitle.Length < 3 || postDescription.Length < 3)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nYour post title and post description both need to be longer than 3 characters.\n" +
                            "Please try again. Thank you.\n");
                        success = false;
                    }
                    else
                    {
                        success = true;
                    }

                } while (!success);



                var user = MainMenu.UserList.FirstOrDefault(x => x.UserName == MainMenu.CurrentUser);

                var newPost = new PostMenu
                {
                    Id = PostMenu.GetNextID(),
                    PostAuthor = MainMenu.CurrentUser,
                    PostTitle = postTitle,
                    PostDescription = postDescription,
                    PostTime = DateTime.UtcNow,
                    PostLastEdited = null,
                    UserId = user.UserId
                };


                MainMenu.PostList.Add(newPost);

                Console.WriteLine($"\nCongratulations {newPost.PostAuthor}, you have created a new Post" +
                                            $"\nYour Post Id : {newPost.Id}\n" +
                                            $"Post was created at {newPost.PostTime}\n" +
                                            $"Press enter to return to the main menu");

                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("\n\nYou have to log into your account to create a post.\n" +
                    "Press enter to return to the main menu");
                Console.ReadLine();

            }

            MainMenu.PostMainMenu();


        }











    }
}
