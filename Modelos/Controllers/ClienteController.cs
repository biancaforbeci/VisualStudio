using Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    public class ClienteController
    {
        static List<Cliente> MeusClientes = new List<Cliente>();
        static int ultimoID = 0;

        public int SalvarCliente(Cliente cliente)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            cliente.pessoaID = id;
            MeusClientes.Add(cliente);

            return cliente.pessoaID;
        }

        public Cliente PesquisarPorNome(string nome)
        {
            var c = from x in MeusClientes
                    where x.nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            var c = from x in MeusClientes
                    where x.pessoaID.Equals(idCliente)
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public void ExcluirCliente(int idCliente)
        {
            Cliente cli = PesquisarPorID(idCliente);

            if (cli != null)
                MeusClientes.Remove(cli);
                
            
        }

        public List<Cliente> ListarCliente()
        {
            return MeusClientes;
        }

        public void EditarCliente(int idClienteEditar, Cliente clienteEditado)
        {
            Cliente clienteEditar = PesquisarPorID(idClienteEditar);

            if (clienteEditar != null)

                clienteEditar.nome = clienteEditado.nome;
                clienteEditar.cpf = clienteEditado.cpf;
                clienteEditar.enderecoID = clienteEditado.enderecoID;

                
         }

        
    }
}
