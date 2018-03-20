using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EntregadorController
    {
        static List<Entregador> ListaEntregadores = new List<Entregador>();
        static int ultimoID = 0;

        public int CadastrarEntregador(Entregador ent)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            ent.enderecoID = id;
            ListaEntregadores.Add(ent);
            return id;
        }

        public Entregador ProcurarPorIDEntregador(int id) //Procurar por id é nome do método do professor.
        {
            var e = from x in ListaEntregadores
                    where x.pessoaID.Equals(id)
                    select x;

            if (e != null)
            {
                return e.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }


        public Entregador EditarFornecedor(int id)
        {
            Entregador c = ProcurarPorIDEntregador(id);

            if (c != null)
                return c;
            else
                return null;

        }

        public void ExcluirEndereco(int id)
        {
            Entregador end = ProcurarPorIDEntregador(id);
            if (end != null)
            {
                ListaEntregadores.Remove(end);
            }
        }

        public List<Entregador> EnderecosCadastrados()
        {
            return ListaEntregadores;
        }
    }
}
