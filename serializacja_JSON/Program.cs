using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace serializacja_JSON {
    class Program {

        public static void serializacja() {
            Console.WriteLine("[SERIALIZACJA]");
            Samochod[] samochody = {
            new Samochod(){Marka="Opel",Model="Astra G",Nadwozie="Coupe",Moc=200,Kolor="czarny"},
            new Samochod(){Marka="Alfa",Model="159",Nadwozie="Laweta",Moc=90,Kolor="czerwony"}
            };

            string jsonString = JsonConvert.SerializeObject(samochody,Formatting.Indented);
            Console.WriteLine(jsonString);
            File.WriteAllText("przyklad.json", jsonString);
            Console.WriteLine("\n\n");
        }

        public static void deserializacja() {
            Console.WriteLine("[DESERIALIZACJA]");
            Samochod[] samochody = null;
            string text = File.ReadAllText("przyklad.json");
            var output = JsonConvert.DeserializeObject<List<Samochod>>(text);
            foreach(var samochod in output) {
                Console.WriteLine($"Odczytany samochod marki {samochod.Marka} " +
                    $"model {samochod.Model} " +
                    $"silnik o mocy {samochod.Moc}KM " +
                    $"nadwozie {samochod.Nadwozie} " +
                    $"kolor karoserii {samochod.Kolor}\n");

            }
            
        }

        static void Main(string[] args) {
            serializacja();
            deserializacja();
            Console.Read();
        }
    }
}
