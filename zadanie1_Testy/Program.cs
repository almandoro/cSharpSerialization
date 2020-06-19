using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using zadanie1_core;

namespace zadanie1_testy {
    class Program {
        static void serializacja() {
            Console.WriteLine("[SERIALIZACJA BINARNA]");
            Osoba[] osoby = {
            new Osoba(1912,"password"){Imie="Alan", Nazwisko="Turing"},
            new Osoba(1903,"password"){Imie="John", Nazwisko="Neumann"},
            new Osoba(1923,"password"){Imie="Edgar", Nazwisko="Codd"}
            };

            Console.WriteLine("Obiekty przed serializacją:\n");
            foreach(var osoba in osoby) {
                Console.WriteLine($"Serializacja osoby {osoba.Imie} {osoba.Nazwisko}," +
                    $" urodzony/a {osoba.Wiek}. " +
                    $"Jego hasło to: {osoba.Imie + osoba.Nazwisko}? {osoba.SprawdzHaslo(osoba.Imie + osoba.Nazwisko)}");
            }
            
            BinaryFormatter formater = new BinaryFormatter();
            FileStream fs = null;
            try {
                fs = new FileStream("osoby.dat", FileMode.Create);
                formater.Serialize(fs, osoby);
            } catch(Exception ex) {
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
            } finally {
                if(fs != null)
                    fs.Close();
            }
            Console.WriteLine("\n\n");
        }

        static void deserializacja() {
            Console.WriteLine("[DESERIALIZACJA BINARNA]");
            BinaryFormatter formater = new BinaryFormatter();
            FileStream fs = null;
            Osoba[] osoby2 = null;
            try {
                fs = new FileStream("osoby.dat", FileMode.Open);
                osoby2 = (Osoba[])formater.Deserialize(fs);
            } catch(Exception ex) {
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
            } finally {
                if(fs != null)
                    fs.Close();
            }
            foreach(Osoba o in osoby2) {
                Console.WriteLine("Imię: {0}, nazwisko: {1}, ile by miał lat: {2}",
                o.Imie, o.Nazwisko, o.Wiek);
                Console.WriteLine("\thasło password: {0}",
                o.SprawdzHaslo("password"));
                Console.WriteLine("\thasło {1}{2}: {0}",
                o.SprawdzHaslo(o.Imie + o.Nazwisko), o.Imie, o.Nazwisko);
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
