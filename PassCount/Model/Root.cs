using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassCount.Model
{
    public class Root
    {
        public List<Conta> Contas { get; set; }

        public Root()
        {
            this.Contas = new List<Conta>();
        }

        public Root Read(String Path, String Key)
        {
            return JsonConvert.DeserializeObject<Root>(Cipher.Decrypt(Arquivo.Ler(Path), Key));
        }

        public Boolean Save(String Path, String Key)
        {
            return Arquivo.Gravar(Path, Cipher.Encrypt(JsonConvert.SerializeObject(this), Key));
        }
    }
}
