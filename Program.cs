using System;
using System.Collections.Generic;

class Program
{
    class usuario
    {
        public string Pessoa { get; set; }
        public bool EstaRegistrada { get; set; }
        public usuario(string pessoa)
        {
            Pessoa = pessoa;
            EstaRegistrada = false;
        }
        public override string ToString()
        {
            return $"{(EstaRegistrada !? "Não está registrada" : "Usuario registrado")} {Pessoa}";
        }
    }

static void Main(string[] args)
{
    List<usuario> usuarios = new List<usuario>();
    bool rodar = true;

    while(rodar)
    {
        Console.Clear();
        Console.WriteLine("=== Gerenciamento de Usuários ===\n");
        Console.WriteLine("1. Cadastrar usuário");
        Console.WriteLine("2. Buscar usuário");
        Console.WriteLine("3. Apagar usuário");
        Console.WriteLine("4. Sair");
        Console.Write("\nEscolha uma opção: ");
        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                AddUsuarios(usuarios);
                break;
            case "2":
                listausuario(usuarios);
                break;
            case "3":
                removeusuario(usuarios);
                break;
            case "4":
                rodar = false;
                break;
            
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}
static void AddUsuarios(List<usuario> usuarios)
{
    Console.Write("\nDigite o nome do usuário: ");
    string Pessoa = Console.ReadLine();
    usuarios.Add(new usuario(Pessoa));
    Console.WriteLine("Usuario criado com sucesso.");
    Console.ReadKey();
}

static void listausuario(List<usuario> usuarios)
{
    Console.Write("\nEscreva o nome do seu usuário: ");
    string procura = Console.ReadLine();
    usuario resultado = usuarios.Find(u => u.Pessoa == procura);

    if(resultado != null)
    {
        Console.WriteLine($"Usuário encontrado: {resultado.Pessoa}");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Usuário não encontrado. Tente novamente");
        Console.ReadKey();
    }
}
static void removeusuario(List<usuario> usuarios)
{
    Console.WriteLine("Qual o usuário que você gostaria de remover: ");
    string apagar = Console.ReadLine();
    usuario usuarioApagar = usuarios.Find(u => u.Pessoa == apagar);

    if(usuarioApagar != null)
    {
        usuarios.Remove(usuarioApagar);
        Console.WriteLine($"Usuário {apagar} removido com sucesso.");
    }
    else
    {
        Console.WriteLine("Usuário não encontrado.");
    }
    Console.ReadKey();
}
}