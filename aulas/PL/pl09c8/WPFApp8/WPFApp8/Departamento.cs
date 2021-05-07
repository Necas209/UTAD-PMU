using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp8
{
    public class Departamento
    {
        public string Nome { get; private set; }
        public int NDocentes { get; private set; }

        public Departamento(string nome, int ndocentes)
        {
            Nome = nome;
            NDocentes = ndocentes;
        }
    }
}
