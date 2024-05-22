namespace Blog.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Posts");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar posts");
            Console.WriteLine("2 - Cadastrar post");
            Console.WriteLine("3 - Atualizar post");
            Console.WriteLine("4 - Excluir post");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: ListPostScreen.Load(); break;
                case 2: CreatePostScreen.Load(); break;
                //case 3: UpdateRoleScreen.Load(); break;
                //case 4: DeleteRoleScreen.Load(); break;
                default: Load(); break;
            }


        }
    }
}