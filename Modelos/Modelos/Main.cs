
using System;

namespace Modelos
{
    class Program
    {

        enum OpcoesMenuPrincipal
        {
            CadastrarCliente,
            PesquisarCliente,
            EditarCliente,
            ExcluirCliente,
            LimparCliente,
            Sair
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
                        CadastrarCliente();                        
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

       
    }

    //Metodos Cliente

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

    }


}
