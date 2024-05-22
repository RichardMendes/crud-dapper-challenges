using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualização de usuário");
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o Id do usuário: ");
            var id = Console.ReadLine();
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

            Update(new User
            {
                Id = int.Parse(id),
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
        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("O usuário foi atualizado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}