using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PassCount.Model
{
    public class Arquivo
    {
        public static String Ler(String Path)
        {
            String Conteudo = String.Empty;

            try
            {  
                using (StreamReader sr = new StreamReader(Path))
                {
                    Conteudo = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
            }

            return Conteudo;
        }

        public static Boolean Gravar(String Path, String Conteudo)
        {
            Boolean Gravado = true;

            try
            {
                using (StreamWriter file = new System.IO.StreamWriter(Path))
                {
                    file.WriteLine(Conteudo);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                Gravado = false;
            }

            return Gravado;
        }
    }
}
