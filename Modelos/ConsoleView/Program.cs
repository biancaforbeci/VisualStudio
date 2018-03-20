
using Controllers;
using Modelos;
using System;
using System.Collections.Generic;

namespace ConsoleView
{
    class Program
    {
        enum OpcoesMenuPrincipal

        {
            CadastrarCliente = 1,
            PesquisarCliente = 2,
            ListarTodosClientes = 3,
            EditarCliente = 4,
            ExcluirCliente = 5,
            LimparTela = 6,
            Sair = 7
        }

        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("Escolha sua opcao");
            Console.WriteLine("");

            Console.WriteLine(" - Clientes - ");
            Console.WriteLine("1 - Cadastrar Novo");
            Console.WriteLine("2 - Pesquisar Cliente");
            Console.WriteLine("3 - Listar Clientes Cadastrados");
            Console.WriteLine("4 - Editar Cliente");
            Console.WriteLine("5 - Excluir Cliente");

            Console.WriteLine(" - Geral -");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("7 - Sair");

            //return Convert.ToInt32(Console.ReadLine());
            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal)int.Parse(opcao);
        }
        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada =
                OpcoesMenuPrincipal.Sair;

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
                    case OpcoesMenuPrincipal.ListarTodosClientes:
                        ListarTodosClientes();
                        break;
                    case OpcoesMenuPrincipal.EditarCliente:
                        EditarCliente();
                        break;
                    case OpcoesMenuPrincipal.ExcluirCliente:
                        ExcluirCliente();
                        break;
                    case OpcoesMenuPrincipal.LimparTela:
                        break;
                    case OpcoesMenuPrincipal.Sair:
                        break;
                    default:
                        break;
                }

            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);

        }

        private static void ExcluirCliente()
        {
            Console.WriteLine("Digite o id do cliente que deseja excluir: ");
            int idCliente = int.Parse(Console.ReadLine());

            EnderecoController e = new EnderecoController();
            ClienteController cc = new ClienteController();
            Cliente c = cc.PesquisarPorID(idCliente);
            e.ExcluirEndereco(c.enderecoID);
            cc.ExcluirCliente(idCliente);
            
        }

        // Metodos Cliente
        private static Cliente CadastrarCliente()
        {
            Cliente cli = new Cliente();

            Console.Write("Digite o nome: ");
            cli.nome = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o cpf: ");
            cli.cpf = Console.ReadLine();

            Endereco end = CadastrarEndereco();
            cli.enderecoID = end.enderecoID;

            return cli;
        }

        private static Endereco CadastrarEndereco()
        {
            EnderecoController ee = new EnderecoController();
            Endereco end = new Endereco();

            Console.Write("Digite o nome da rua: ");
            end.rua = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o numero: ");
            end.numero = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o complemento: ");
            end.complemento = Console.ReadLine();

            ee.CadastrarEndereco(end);

            return end;
        }

        private static void PesquisarCliente()
        {
            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            ClienteController cc = new ClienteController();
            Cliente cli = cc.PesquisarPorNome(nomeCliente);

            if (cli != null)
            {
                ExibirDadosCliente(cli);
            }
            else
                Console.WriteLine(" * Cliente não encontrado");
        }

        private static void ExibirDadosCliente(Cliente cliente)
        {
            
            Console.WriteLine();
            Console.WriteLine("--- DADOS CLIENTE --- ");
            Console.WriteLine("ID:" + cliente.pessoaID);
            Console.WriteLine("Nome: " + cliente.nome);
            Console.WriteLine("Cpf: " + cliente.cpf);

            ExibirDadosDeEndereco(cliente);


        }

        private static void ExibirDadosDeEndereco(Cliente cliente){
            Console.WriteLine("- Endereco -");
            EnderecoController e = new EnderecoController();
            Endereco end = e.ListarEndereco(cliente.enderecoID);

            Console.WriteLine("Rua: " + end.rua);
            Console.WriteLine("Num: " + end.numero);
            Console.WriteLine("Compl.: " + end.complemento);
            
            Console.WriteLine("-------------- ");
            Console.WriteLine();
            }

        
        private static void ListarTodosClientes()
        {
            Console.WriteLine();
            Console.WriteLine("---- Clientes Cadastrados  --- ");

            ClienteController cc = new ClienteController();
            List<Cliente> lista = cc.ListarCliente();

            if (lista.Count == 0)
            {
                Console.WriteLine(" * Ainda não existem clientes cadastrados");
            }
            else
            {
                foreach (Cliente cli in lista)
                {
                    ExibirDadosCliente(cli);
                }
            }
            Console.WriteLine();

        }

        private static void EditarCliente()
        {
            Console.WriteLine("Digite o ID do cliente:");
            int n = int.Parse(Console.ReadLine());

            ClienteController cc = new ClienteController();
            Cliente cli = cc.EditarCliente(n);

            if (cli != null)
            {
                Console.Write("Digite o nome novo: ");
                cli.nome = Console.ReadLine();

                Console.WriteLine();

                Console.Write("Digite o cpf novo: ");
                cli.cpf = Console.ReadLine();

                EnderecoController e = new EnderecoController();

                Endereco endereco = EditarEndereco(cli);
                e.EditarEndereco(endereco,cli.enderecoID);

                ExibirDadosCliente(cli);
            }
            else
            {
                Console.WriteLine("Erro, ID cliente não encontrado.");
            }
            
        }

        private static Endereco EditarEndereco(Cliente cli)
        {
            EnderecoController e = new EnderecoController();
            Endereco end = e.ListarEndereco(cli.enderecoID);
            
            Console.Write("Digite o nome da rua novo: ");
            end.rua = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o numero novo: ");
            end.numero = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o complemento novo: ");
            end.complemento = Console.ReadLine();

            return end;
        }

         
    }
}