using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Perfil");
            Console.WriteLine("-------------");
            Console.WriteLine("-------------");
            Console.WriteLine("Nome do perfil: ");
            var name = Console.ReadLine();
            Console.WriteLine("Slug do perfil: ");
            var slug = Console.ReadLine();
            Create(new Role
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine("Tag cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}