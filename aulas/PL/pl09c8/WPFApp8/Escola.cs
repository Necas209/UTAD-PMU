using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace WPFApp8
{
    public class Escola : IEnumerable
    {
        public string Nome { get; private set; }
        private List<Departamento> Departamentos;

        public event MethodWithoutArgs InitEnded;

        public Escola()
        {
            Departamentos = new List<Departamento>();
        }

        public void Init()
        {
            Nome = "Escola de Ciências e Tecnologia";
            Departamentos.Add(new Departamento("Engenharias", 65));
            Departamentos.Add(new Departamento("Física", 18));
            Departamentos.Add(new Departamento("Matemática", 33));
            if (InitEnded != null)
                InitEnded();
        }

        public int GetNDocentes(int index)
        {
            return Departamentos[index].NDocentes;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Departamentos.Count; i++)
                yield return Departamentos[i];
        }
    }
}
