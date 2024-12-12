using System.Threading.Channels;
using UsandoBancoDeDados.Banco;
using UsandoBancoDeDados.Modelos;

internal class Program
{
    public static void Main(string[] args)
    {

        //ADO NET
        try
        {
            //using var connection = new Connection().ObterConexao();
            //connection.Open();
            //Console.WriteLine(connection.State); //Retorna o estado da conexão.

            Menu();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Menu()
    {
        Console.WriteLine("Digite 1 para listar todos usuários");
        Console.WriteLine("Digite 2 para adicionar um usuário");
        Console.WriteLine("Digite 3 para atualizar um usuário");
        Console.WriteLine("Digite 4 para deletar um usuário");
        Console.WriteLine("Digite 0 para sair");

        Console.Write("\nDigite uma opção: ");
        int opcao = int.Parse(Console.ReadLine()!);

        switch (opcao)
        {
            case 0:
                Console.WriteLine("Saindo");
                break;
            case 1:
                ListarUsuarios();
                break;
            case 2:
                AdicionarUsuario(); 
                break;
            case 3:
                AtualizarUsuario();
                break;
            case 4:
                DeletarUsuario();
                break;
            default:
                Console.WriteLine("Opção inválido.");
                RetornaAoMenu();
                break;
        }

    }

    public static void ListarUsuarios()
    {
        List<Usuario> lista = new Connection().Listar().ToList();
        lista.ForEach(x => Console.WriteLine(x));

        RetornaAoMenu();
    }

    public static void AdicionarUsuario()
    {
        Console.Write("Digite o nome do usuário: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o cpf do usuário: ");
        string cpf = Console.ReadLine();
        Console.Write("Digite o caminho da foto de perfil: ");
        string fotoPerfil = Console.ReadLine();

        Usuario usuario = new Usuario() { Nome = nome, Cpf = cpf, FotoPerfil = fotoPerfil};

        new Connection().Adicionar(usuario);

        RetornaAoMenu();
    }

    public static void AtualizarUsuario()
    {
        ListarUsuarios();
        Console.Write("\nDigite o ID do usuário que deseja atualizar: ");
        int id = int.Parse(Console.ReadLine());

        Usuario usuario = new Connection().getUsuarioById(id);

        if (usuario != null)
        {
            int opcao = -1;

            Console.WriteLine(usuario);

            while(opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1 para alterar o Nome");
                Console.WriteLine("Digite 2 para alterar o CPF");
                Console.WriteLine("Digite 3 para alterar a Foto de Perfil");
                Console.WriteLine("Digite 0 para sair e salvar");

                Console.Write("\nDigite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("\nDigite o nome do usuário: ");
                        usuario.Nome = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("\nDigite o CPF do usuário: ");
                        usuario.Cpf = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("\nDigite o endereço da foto de perfil: ");
                        usuario.FotoPerfil = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } 
            
            new Connection().Atualizar(usuario);

        }
        else
        {
            Console.WriteLine("Usuário informado não existe.");
        }

        RetornaAoMenu();

    }

    public static void DeletarUsuario()
    {
        ListarUsuarios();

        Console.Write("\nDigite o ID do usuário que deseja atualizar: ");
        var idString = Console.ReadLine()[0];

        bool existe = int.TryParse(idString.ToString(), out int id);

        if(!existe)
        {
            Console.WriteLine("Valor informado não corresponde a um Id.");
            RetornaAoMenu();
        }


        Usuario usuario = new Connection().getUsuarioById(id);

        if (usuario != null)
        {
            new Connection().Deletar(usuario);
        }
        else
        {
            Console.WriteLine("Id informado não existe.");
        }        
        
        RetornaAoMenu();

    }

    public static void RetornaAoMenu()
    {
        Console.WriteLine();
        Console.Write("Tecla alguma tecla para retornar ao menu. ");
        Console.ReadKey(true);
        Thread.Sleep(800);
        Console.Clear();
        Menu();
    }

}
