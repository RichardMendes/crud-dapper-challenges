using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo usuário");
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o nome do usuário: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o e-mail do usuário: ");
            var email = Console.ReadLine();
            Console.WriteLine("Digite a senha do usuário: ");
            var pass = Console.ReadLine();
            Console.WriteLine("Digite o slug do usuário: ");
            var slug = Console.ReadLine();
            Console.WriteLine("Digite a biografia do usuário: ");
            var bio = Console.ReadLine();
            Console.WriteLine("Digite a url de imagem do usuário: ");
            var img = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                Bio = bio,
                Slug = slug,
                PasswordHash = pass,
                Image = img
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }
        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("O usuário foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível criar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}