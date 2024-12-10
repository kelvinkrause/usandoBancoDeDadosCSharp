﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoBancoDeDados.Modelos;

namespace UsandoBancoDeDados.Banco;

internal class Connection
{
    private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsandoBancoDeDados;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(connectionString);
    }

    public IEnumerable<Usuario> Listar()
    {
        var lista = new List<Usuario>();
        using var connection = ObterConexao();
        connection.Open();

        string sql = "SELECT * FROM USUARIOS WHERE ATIVO = 1";

        SqlCommand command = new SqlCommand(sql, connection);

        using SqlDataReader dateReader = command.ExecuteReader(); 
        //SqlDataReader, responável por ler as informações do banco 

        while (dateReader.Read())
        {
            int id = Convert.ToInt32(dateReader["Id"]);
            string nome = Convert.ToString(dateReader["Nome"]);
            string cpf = Convert.ToString(dateReader["Cpf"]);
            string fotoPerfil = Convert.ToString(dateReader["FotoPerfil"]);
            bool ativo = Convert.ToBoolean(dateReader["Ativo"]);

            lista.Add(new Usuario() { Id = id, Nome = nome, Cpf = cpf, FotoPerfil = fotoPerfil, Ativo = ativo});

        }

        return lista;
    }

    public void Adicionar(Usuario usuario)
    {
        using var connection = ObterConexao();
        connection.Open();

        string sql = "INSERT INTO USUARIOS (Nome, Cpf, FotoPerfil, Ativo) " +
            "VALUES (@nome, @cpf, @fotoPerfil, 1)";

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", usuario.Nome);
        command.Parameters.AddWithValue("@cpf", usuario.Cpf);
        command.Parameters.AddWithValue("@fotoPerfil", usuario.FotoPerfil);

        int retorno = command.ExecuteNonQuery();
        if(retorno > 1) 
                Console.WriteLine($"Linhas afetadas: {retorno}");

    }


}