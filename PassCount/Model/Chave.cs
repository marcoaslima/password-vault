using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassCount.Model
{
    public class Chave
    {
        public String Nome { get; set; }
        public String Valor { get; set; }

        public Chave(String Nome, String Valor)
        {
            this.Nome = Nome;
            this.Valor = Valor;
        }
    }
}
