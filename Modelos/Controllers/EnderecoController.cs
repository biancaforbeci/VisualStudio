using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EnderecoController
    {
        static List<Endereco> EnderecosCli = new List<Endereco>();
        static int ultimoID = 0;

        public int CadastrarEndereco(Endereco end)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            end.enderecoID = id;
            EnderecosCli.Add(end);
            return id;
        }

        public Endereco ListarEndereco(int id) //Procurar por id é nome do método do professor.
        {
            var e = from x in EnderecosCli
                    where x.enderecoID.Equals(id)
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

                
        public void EditarEndereco(Endereco end, int id)
        {
            Endereco antigo =ListarEndereco(id);
            antigo.rua = end.rua;
            antigo.numero = end.numero;
            antigo.complemento = end.complemento;

        }       

        public void ExcluirEndereco(int id)
        {
            Endereco end = ListarEndereco(id);
            if (end != null)
            {
                EnderecosCli.Remove(end);
            }
        }

        public List<Endereco> EnderecosCadastrados()
        {
            return EnderecosCli;
        }

    }
}
