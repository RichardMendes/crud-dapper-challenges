using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Posts");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Post>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Title} ({item.Slug})");

        }
    }
}