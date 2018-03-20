using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    class FornecedorController
    {
        static List<Fornecedor> ListaFornecedores = new List<Fornecedor>();
        static int ultimoID = 0;

        public int CadastrarEntregador(Fornecedor f)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            f.enderecoID = id;
            ListaFornecedores.Add(f);
            return id;
        }

        public Fornecedor ProcurarPorIDFornecedor(int id) //Procurar por id é nome do método do professor.
        {
            var e = from x in ListaFornecedores
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


        public Fornecedor EditarFornecedor(int id)
        {
            Fornecedor c = ProcurarPorIDFornecedor(id);

            if (c != null)
                return c;
            else
                return null;

        }

        public void ExcluirEndereco(int id)
        {
            Fornecedor forn = ProcurarPorIDFornecedor(id);
            if (forn != null)
            {
                ListaFornecedores.Remove(forn);
            }
        }

        public List<Fornecedor> EnderecosCadastrados()
        {
            return ListaFornecedores;
        }
    }
}
