using System.Linq;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            // Console.Clear();
            Console.WriteLine("Lista de usuários com perfis");
            Console.WriteLine("-----------------");
            var users = List();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Email})");
                Console.Write("Perfis: ");
                foreach (var i in item.Roles)
                {
                    Console.Write($"{i.Name}");
                    var last = item.Roles.Last();
                    if (i == last)
                    {
                        Console.Write(".\n");
                    }
                    else
                        Console.Write(", ");
                }
            }
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static List<User> List()
        {
            var query = @"SELECT 
                [User].*,
                [Role].*
            FROM 
                [User] 
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";
            var users = new List<User>();
            var items = Database.Connection.Query<User, Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if (role != null)
                        usr.Roles.Add(role);

                    users.Add(usr);
                }
                else
                    usr.Roles.Add(role);

                return user;
            }, splitOn: "Id");

            return users;
        }

    }




}