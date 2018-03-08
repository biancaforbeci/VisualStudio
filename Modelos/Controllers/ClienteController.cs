using Modelos;
using System;
using System.Collections.Generic;

namespace Controllers
{
    public class ClienteController
    {
        static List<Cliente> MeusClientes = new List<Cliente>();

        public ClienteController()
        {
            MeusClientes = new List<Cliente>(); //referência a lista está instaciada
        }

        public void SalvarCliente(Cliente cliente)
        {
            // TODO: Persistir os dados do cliente
            MeusClientes.Add(cliente);


        }
    }
}
