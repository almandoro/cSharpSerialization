using System;
using System.IO;
using System.Xml.Serialization;
using zadanie2_core;

namespace zadanie2_testy {
    class Program {

        static void serializacja() {
            Console.WriteLine("[SERIALIZACJA XML]");
            Towar[] oferta = {
            new Towar(){Nazwa="Jabłka", CenaDetaliczna=2.5m,
            CenaHurtowa=1.2m, IdTowaru=1},
            new Towar(){Nazwa="Śliwki", CenaDetaliczna=3.2m,
            CenaHurtowa=1.5m, IdTowaru=3},
            new Towar(){Nazwa="Truskawki", CenaDetaliczna=3.8m,
            CenaHurtowa=1.6m, IdTowaru=4}
            };

            Console.WriteLine("Obiekty przed serializacją:\n");
            foreach(var towar in oferta) {
                Console.WriteLine($"Serializacja towaru o ID:{towar.IdTowaru}, " +
                    $"nazywa się {towar.Nazwa}, " +
                    $"cena detaliczna {towar.CenaDetaliczna}, " +
                    $"cena hurtowa {towar.CenaHurtowa}");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Towar[]));
            FileStream fs = null;
            try {
                fs = new FileStream("Oferta.xml", FileMode.Create);
                serializer.Serialize(fs, oferta);
            } catch(Exception ex) {
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
            } finally {
                if(fs != null)
                    fs.Close();
            }
            Console.WriteLine("\n\n");
        }

        static void deserializacja() {
            Console.WriteLine("[DESERIALIZACJA XML]");
            Towar[] kopiaOferty = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Towar[]));
            FileStream fs = null;
            try {
                fs = new FileStream("Oferta.xml", FileMode.Open);
                kopiaOferty = (Towar[])serializer.Deserialize(fs);
            } catch(Exception ex) {
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
            } finally {
                if(fs != null)
                    fs.Close();
            }
            foreach(Towar t in kopiaOferty) {
                Console.Write("Towar {0}, cena detaliczna - {1}, ",
                t.Nazwa, t.CenaDetaliczna);
                Console.WriteLine("cena hurtowa - {0}, id towaru - {1}",
                t.CenaHurtowa, t.IdTowaru);
            }
            Console.WriteLine("\n\n");
        }

        static void Main(string[] args) {
            serializacja();
            deserializacja();
            Console.ReadKey();
        }
    }
}
