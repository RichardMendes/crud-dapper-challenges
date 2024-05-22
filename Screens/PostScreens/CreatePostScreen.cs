using Blog.Models;
using Blog.Repositories;
using Microsoft.Identity.Client;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Posts");
            Console.WriteLine("--------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o Id da Categoria do post: ");
            var idCat = Console.ReadLine();
            Console.WriteLine("Digite o Id do Autor do post: ");
            var idAut = Console.ReadLine();
            Console.WriteLine("Digite a título do post: ");
            var title = Console.ReadLine();
            Console.WriteLine("Digite o resumo do post: ");
            var summary = Console.ReadLine();
            Console.WriteLine("Digite o post: ");
            var body = Console.ReadLine();
            Console.WriteLine("Digite a slug do post: ");
            var slug = Console.ReadLine();
            Create(new Post
            {
                CategoryId = int.Parse(idCat),
                AuthorId = int.Parse(idAut),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            });

        }

        public static void Create(Post post)
        {

            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}