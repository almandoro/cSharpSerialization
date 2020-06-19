using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace serializacja_YAML {
    class Program {

        static void serializacja() {

            Console.WriteLine("[SERIALIZACJA YAML]");

            var receipt = new Dokument {
                rodzaj = "Lista zamowien",
                data = new DateTime(2007, 8, 6),
                klient = new Klient {
                    imie = "Maciej",
                    nazwisko = "Marcinkowski"
                },
                przedmioty = new Przedmiot[]
              {
                    new Przedmiot
                    {
                        id = "A4786",
                        opis = "Marlboro Gold (miękka)",
                        cena = 17.47M,
                        ilosc = 4
                    },
                    new Przedmiot
                    {
                        id = "E1628",
                        opis = "Specjal Jasny Pełny",
                        cena = 2.57M,
                        ilosc = 1
                    }
              }
            };

            var serializer = new SerializerBuilder().Build();
            var output = serializer.Serialize(receipt);
            Console.WriteLine(output);
            File.WriteAllText("lista.yml", output);

        }

        public static void deseralizacja() {

            Console.WriteLine("[DESERIALIZACJA YAML]");
            var input = new StringReader(File.ReadAllText("lista.yml"));

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var dokument = deserializer.Deserialize<Dokument>(input);

            Console.WriteLine($"Klient {dokument.klient.imie} {dokument.klient.nazwisko} otrzymał dokument:");
            Console.WriteLine($"Dokument {dokument.rodzaj}" +
                $" wystawiony {dokument.data} za:");
            foreach(var item in dokument.przedmioty)
                Console.WriteLine($" - ID: {item.id} Opis:{item.opis} Cena: {item.cena} Ilość: {item.ilosc}");

 
        }
        static void Main(string[] args) {
            serializacja();
            deseralizacja();
            Console.ReadKey();
        }
    }
}
