﻿using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;

internal class Program
{
    private const string CONNECTION_STRING = @"ATENÇÃO:::ADICIONAR SUA CONNECTION STRING";
    private static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        Database.Connection.Open();

        Load();

        Console.ReadKey();
        Database.Connection.Close();
    }

    private static void Load()
    {
        // Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que você deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Gestão de post");
        Console.WriteLine("6 - Vincular perfil/usuário");
        Console.WriteLine("7 - Vincular post/tag");
        Console.WriteLine("8 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: MenuUserScreen.Load(); break;
            case 2: MenuRoleScreen.Load(); break;
            case 3: MenuCategoryScreen.Load(); break;
            case 4: MenuTagScreen.Load(); break;
            case 5: MenuPostScreen.Load(); break;
            case 6: JoinUserRoleScreen.Load(); break;
            case 7: JoinPostTagScreen.Load(); break;
            default: Load(); break;
        }
    }
}