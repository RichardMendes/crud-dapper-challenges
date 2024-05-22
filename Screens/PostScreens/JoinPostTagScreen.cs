using Dapper;

namespace Blog.Screens.PostScreens
{
    public class JoinPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vínculo de posts e tags");
            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o id do post: ");
            var idpost = Console.ReadLine();
            Console.WriteLine("Digite o id da tag a ser vínculada: ");
            var idtag = Console.ReadLine();
            Vinculate(idpost, idtag);
        }

        public static void Vinculate(string idpost, string idtag)
        {
            try
            {
                var query = @"INSERT INTO [PostTag] VALUES (@idpost, @idtag)";
                Database.Connection.Query(query, new { idpost, idtag });
                Console.WriteLine("Tag vinculada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o post com a tag listada");
                Console.WriteLine(ex.Message);
            }
        }
    }
}