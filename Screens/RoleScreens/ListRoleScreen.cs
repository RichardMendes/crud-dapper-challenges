using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Perfis");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");

        }
    }
}