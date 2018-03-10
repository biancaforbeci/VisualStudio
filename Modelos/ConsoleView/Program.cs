
using Controllers;
using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;

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

            Console.WriteLine("- Geral -");
            Console.WriteLine("4 - Limpar Tela");
            Console.WriteLine("5 - Sair");

            //return Convert.ToInt32(Console.ReadLine());

            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal)int.Parse(opcao);
        }

        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = OpcoesMenuPrincipal.Sair;
            ClienteController cc = new ClienteController();
            do
            {
                opcaoDigitada = Menu();
                
                switch (opcaoDigitada)
                {
                    
                    case OpcoesMenuPrincipal.CadastrarCliente:
                        Cliente c = CadastrarCliente();                        
                        cc.SalvarCliente(c);
                        ExibirDadosCliente(c);
                        break;
                    case OpcoesMenuPrincipal.PesquisarCliente:
                        Console.WriteLine("Digite o nome do cliente a ser procurado: ");
                        string pesquisa = Console.ReadLine();
                        PesquisarCliente(cc.ProcuraCliente(pesquisa));
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

        private static void PesquisarCliente(IEnumerable<Cliente>cli)
        {
            if (cli != null)
            {
                foreach (var item in cli)
                {
                    Console.WriteLine("Oi");
                    Console.WriteLine("Nome:" + item.nome);
                    Console.WriteLine("CPF: " + item.cpf);
                    Console.WriteLine("Rua: " + item._endereco.rua);
                    Console.WriteLine("Número: " + item._endereco.numero);
                    Console.WriteLine("Complemento: " + item._endereco.complemento);
                }
            }
            else
            {
                Console.WriteLine("Não encontrado esse cliente");
            }

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
