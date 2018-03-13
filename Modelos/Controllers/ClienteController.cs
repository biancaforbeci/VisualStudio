using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Cliente> ProcuraCliente (string nome)  //public Cliente PesquisarCliente()
        {
            Console.WriteLine("here");

            var a = from item in MeusClientes where item.nome.ToLower().Equals(nome.Trim().ToLower()) select item;

            // if(c != null){
            //  return c.FirstorDefault();
            // else
            // return null;

            return a;

        }

        public void ExcluirCliente(Cliente c)
        {
            MeusClientes.Remove(c);
        }
        
    }
}
