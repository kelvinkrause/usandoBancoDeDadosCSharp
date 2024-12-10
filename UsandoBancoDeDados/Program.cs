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

            Listar(new Connection().Listar().ToList());
            AdicionarUsuario();
            Listar(new Connection().Listar().ToList());

            //Usuario kelvin = new Usuario() { Nome = "Kelvin", Cpf = "99988899942"};
            //Console.WriteLine(kelvin);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Listar(List<Usuario> lista)
    {
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

}
