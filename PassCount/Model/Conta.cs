using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassCount.Model
{
    public class Conta
    {
        public String Nome { get; set; }
        public List<Chave> Chaves { get; set; }

        public Conta(String Nome)
        {
            this.Nome = Nome;
            this.Chaves = new List<Chave>();
        }

        
    }
}
