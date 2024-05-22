using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluisão de usuários");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o Id do usuário a ser excluído");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {

            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluido com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o usuário");
                Console.WriteLine(ex.Message);
            }

        }
    }
}