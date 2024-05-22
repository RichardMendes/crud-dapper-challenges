using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias e número de posts em cada");
            Console.WriteLine("-------------");
            var cats = List();
            foreach (var item in cats)
            {
                Console.WriteLine(@$"Categoria {item.Name}");
                {
                    int count = 0;
                    foreach (var i in item.Posts)
                    {

                        if (i.CategoryId != 0)
                            count++;
                        else { count = 0; Console.WriteLine($"{count} posts"); }
                        var last = item.Posts.Last();
                        if (i == last)
                            Console.WriteLine($"{count} posts");

                    }
                }
            }
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static List<Category> List()
        {
            var query = @"SELECT 
                [Category].[Name],
                [Category].[Id],
                [Post].*
            FROM 
                [Category] 
                LEFT JOIN [Post] ON [Category].[Id] = [CategoryId]";
            var categories = new List<Category>();
            var items = Database.Connection.Query<Category, Post, Category>(
            query,
            (category, post) =>
            {
                var cat = categories.FirstOrDefault(x => x.Id == category.Id);
                if (cat == null)
                {
                    cat = category;
                    if (post != null)
                        cat.Posts.Add(post);

                    categories.Add(cat);
                }
                else
                    cat.Posts.Add(post);

                return category;
            }, splitOn: "Id");
            return categories;
        }
    }
}