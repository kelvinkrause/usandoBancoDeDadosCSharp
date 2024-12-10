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

            //Menu();

            Usuario usuario = new Connection().getUsuarioById(1);
            Console.WriteLine(usuario);

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
                break;
        }

    }

    public static void ListarUsuarios()
    {
        List<Usuario> lista = new Connection().Listar().ToList();
        lista.ForEach(x => Console.WriteLine(x));
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
    }

    public static void AtualizarUsuario()
    {

    }
    public static void DeletarUsuario()
    {

    }

}
