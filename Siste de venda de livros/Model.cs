using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siste_de_venda_de_livros
{
    class Model
    {
        public class Usuario
        {
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Telefone { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
        }

        public class Livro
        {
            public string Titulo { get; set; }
            public int Estoque { get; set; }
        }
    }
}
