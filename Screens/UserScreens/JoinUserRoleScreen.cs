using Blog.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreens
{
    public static class JoinUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vínculo de usuários e perfis");
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o id do usuário: ");
            var iduser = Console.ReadLine();
            Console.WriteLine("Digite o id do perfil a ser vínculado: ");
            var idrole = Console.ReadLine();
            Vinculate(idrole, iduser);
        }

        public static void Vinculate(string iduser, string idrole)
        {
            try
            {
                var query = @"INSERT INTO [UserRole] VALUES (@iduser, @idrole)";
                Database.Connection.Query(query, new { iduser, idrole });
                Console.WriteLine("Perfil vinculado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o usuário com o perfil listado");
                Console.WriteLine(ex.Message);
            }

        }
    }
}