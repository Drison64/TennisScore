using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TennisUwU.objects;

namespace TennisUwU.utils {
    public class FlagUtils {

        public static string getFlag(string flagCode) {

            using (StreamReader r = new StreamReader("resources/countries.json"))
            {
                string json = r.ReadToEnd();
                List<Flag> flags = JsonConvert.DeserializeObject<List<Flag>>(json);

                foreach (Flag item in flags) {

                    if (string.Equals(flagCode, item.FlagName, StringComparison.OrdinalIgnoreCase)) {
                        return "https://www.countryflags.io/{0}/flat/64.png".Replace("{0}", item.FlagName);
                    }

                }

                return null;

            }

        }
        
    }
}