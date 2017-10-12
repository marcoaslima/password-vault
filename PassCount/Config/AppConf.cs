using Newtonsoft.Json;
using PassCount.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassCount.Config
{
    public class AppConf
    {
        public static String CONFIG_DEFAULT_PATH
        {
            get
            {
                return Utils.ToLocalPath("config.json");
            }
        }

        public Window window { get; set; }
        public List<Recent> recents { get; set; }
        public string startpage { get; set; }

        public static AppConf Get()
        {
            return JsonConvert.DeserializeObject<AppConf>(Arquivo.Ler(CONFIG_DEFAULT_PATH));
        }

    }
}
