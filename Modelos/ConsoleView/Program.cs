
using Controllers;
using Modelos;
using System;

namespace ConsoleView
{
    class Program
    {

        enum OpcoesMenuPrincipal
        {
            CadastrarCliente = 1,
            PesquisarCliente = 2,
            EditarCliente = 3,
            ExcluirCliente = 4,
            LimparCliente = 5,
            Sair = 6
        }
        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("Escolha sua opção");
            Console.WriteLine();
            Console.WriteLine("- Clientes -");
            Console.WriteLine("1 - Cadastrar Novo");
            Console.WriteLine("2 - Pesquisar Cliente");
            Console.WriteLine("3 - Editar Cliente");

            Console.Write("- Geral -");
            Console.WriteLine("4 - Limpar Tela");
            Console.WriteLine("5 - Sair");

            //return Convert.ToInt32(Console.ReadLine());

            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal)int.Parse(opcao);
        }

        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = OpcoesMenuPrincipal.Sair;

            do
            {
                opcaoDigitada = Menu();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.CadastrarCliente:
                        Cliente c = CadastrarCliente();
                        ClienteController cc = new ClienteController();
                        cc.SalvarCliente(c);
                        ExibirDadosCliente(c);
                        break;
                    case OpcoesMenuPrincipal.PesquisarCliente:
                        PesquisarCliente();
                        break;
                    case OpcoesMenuPrincipal.EditarCliente:
                        break;
                    case OpcoesMenuPrincipal.ExcluirCliente:
                        break;
                    case OpcoesMenuPrincipal.LimparCliente:
                        break;
                    case OpcoesMenuPrincipal.Sair:
                        break;
                    default:
                        break;
                }




            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);


            Console.ReadKey();
        }

        private static Cliente CadastrarCliente()
        {


            Cliente cli = new Cliente();

            Console.Write("Digite o nome : ");
            cli.nome = Console.ReadLine();

            Console.ReadLine();

            Console.Write("Digite o CPF: ");
            cli.cpf = Console.ReadLine();

            Console.ReadLine();

            Endereco end = new Endereco();

            //Ou Cli._Endereco= new Endereco()
            // cli._endereco.rua....

            Console.Write("Digite o nome da rua: ");
            end.rua = Console.ReadLine();

            Console.ReadLine();

            Console.Write("Digite o número: ");
            end.numero = int.Parse(Console.ReadLine());

            Console.ReadLine();

            Console.Write("Digite o complemento:");
            end.complemento = Console.ReadLine();

            Console.ReadLine();

            cli._endereco = end;

            return cli;

        }

        private static Cliente PesquisarCliente()
        {
            // TODO: fazer depois
            return new Cliente();

        }

        private static void ExibirDadosCliente(Cliente cliente)
        {
            Console.WriteLine("--- DADOS CLIENTE ----");
            Console.WriteLine("ID: " + cliente.pessoaID);
            Console.WriteLine("Nome: " + cliente.nome);
            Console.WriteLine("CPF:  " + cliente.cpf);

            Console.WriteLine();

            Console.WriteLine("- Endereço -");
            Console.WriteLine("Rua: " + cliente._endereco.rua);
            Console.WriteLine("Num: " + cliente._endereco.numero);
            Console.WriteLine("Compl: " + cliente._endereco.complemento);
            Console.WriteLine("---------------------------");
            Console.WriteLine("");

        }




    }
}
