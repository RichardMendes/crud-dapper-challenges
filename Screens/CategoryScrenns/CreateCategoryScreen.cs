using Blog.Models;
using Blog.Repositories;
using Microsoft.Identity.Client;

namespace Blog.Screens.CategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criação de categoria");
            Console.WriteLine("--------------");
            Console.WriteLine("-----------------");
            Console.WriteLine("Digite o nome da categoria: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o slug da categoria: ");
            var slug = Console.ReadLine();

            Create(new Category
            {
                Name = name,
                Slug = slug
            });

        }

        public static void Create(Category category)
        {

            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Categoria cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}