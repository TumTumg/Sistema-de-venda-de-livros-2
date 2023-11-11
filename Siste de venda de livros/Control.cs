using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siste_de_venda_de_livros
{
    class Control
    {
        private List<Model.Usuario> usuarios;
        private List<Model.Livro> livros;

        public Control()
        {
            usuarios = new List<Model.Usuario>();
            livros = new List<Model.Livro>
            {
                new Model.Livro { Titulo = "Harry Potter e a ordem da Fênix R$ 50,09", Estoque = 10 },
                new Model.Livro { Titulo = "Mangá de Naruto Shipudden R$ 25,00" , Estoque = 5 },
                new Model.Livro { Titulo = "A arte da guerra R$ 60,00 ", Estoque = 0 },
                new Model.Livro { Titulo = "Anti-Otário" , Estoque = 0 }
                
            };
        }

        public void IniciarSistema()
        {
            Console.WriteLine("Bem-vindo ao sistema de venda de livros!");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Cadastro");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    RealizarLogin();
                    break;
                case 2:
                    RealizarCadastro();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        private void RealizarLogin()
        {
            Console.Write("Digite seu login: ");
            string login = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Model.Usuario usuario = usuarios.Find(u => u.Login == login && u.Senha == senha);

            if (usuario != null)
            {
                Console.WriteLine($"Bem-vindo, {usuario.Nome}!");
                EscolherLivros();
            }
            else
            {
                Console.WriteLine("Login ou senha incorretos. Tente novamente.");
            }
        }

        private void RealizarCadastro()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite seu endereço: ");
            string endereco = Console.ReadLine();
            Console.Write("Digite seu telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Digite seu login: ");
            string login = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Model.Usuario novoUsuario = new Model.Usuario
            {
                Nome = nome,
                Endereco = endereco,
                Telefone = telefone,
                DataNascimento = dataNascimento,
                Login = login,
                Senha = senha
            };

            usuarios.Add(novoUsuario);

            Console.WriteLine("Cadastro realizado com sucesso!");
            EscolherLivros();
        }

        private void EscolherLivros()
        {
            Console.WriteLine("Escolha o livro que deseja comprar:");

            foreach (Model.Livro livro in livros)
            {
                Console.WriteLine($"{livro.Titulo} - Estoque: {livro.Estoque}");
            }

            string tituloLivro = Console.ReadLine();
            Model.Livro livroEscolhido = livros.Find(l => l.Titulo == tituloLivro);

            if (livroEscolhido != null && livroEscolhido.Estoque > 0)
            {
                EfetuarCompra(livroEscolhido);
            }
            else if (livroEscolhido != null)
            {
                RealizarReserva(livroEscolhido);
            }
            else
            {
                Console.WriteLine("Livro não encontrado. Tente novamente.");
            }
        }

        private void EfetuarCompra(Model.Livro livro)
        {
            Console.Write("Digite o número do cartão de crédito: ");
            string numeroCartao = Console.ReadLine();

            // Simulação de validação do número do cartão com sistema externo
            if (ValidarNumeroCartao(numeroCartao))
            {
                Console.WriteLine($"Compra do livro {livro.Titulo} efetuada com sucesso!");
                livro.Estoque--;
            }
            else
            {
                Console.WriteLine("Número do cartão inválido. Tente novamente.");
            }
        }

        private void RealizarReserva(Model.Livro livro)
        {
            Console.WriteLine($"O livro {livro.Titulo} está indisponível no momento. Deseja realizar a reserva? (S/N)");
            string resposta = Console.ReadLine();

            if (resposta.ToUpper() == "S")
            {
                Console.WriteLine($"Reserva do livro {livro.Titulo} realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }

        private bool ValidarNumeroCartao(string numeroCartao)
        {
            // Simulação de validação do número do cartão com sistema externo
            return numeroCartao.Length == 16;
        }
    }

}
