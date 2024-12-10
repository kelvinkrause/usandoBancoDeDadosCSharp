using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoBancoDeDados.Modelos;

internal class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    private string _cpf;
    public string Cpf 
    {
        get
        {
            return _cpf;
        }
        set
        {
            if(value.Length > 11)
            {
                Console.WriteLine("CPF não pode conter mais de 11 digitos.");
            }
            else
            {
                _cpf = value;
            }
        } 
    }
    
    public string FotoPerfil { get; set; }
    public bool Ativo { get; set; }

    public override string ToString()
    {
        return $@"
        Id: {Id}
        Nome: {Nome}
        CPF: {_cpf.Substring(0, 3)}.{_cpf.Substring(3, 3)}.{_cpf.Substring(6, 3)}-{_cpf.Substring(9, 2)}
        Foto Perfil: {FotoPerfil}
        Ativo: {Ativo}";
    }

}
