using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace serializacja_NoSQL {
    class Program {

        static string mongo = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false";

        static void serializacja() {

            Console.WriteLine("[SERIALIZACJA]");
            Developer[] developerzy = {
                new Developer(){imie="Maciej", nazwisko="Marcinkowski", jezyk_programowania="Java", staz=2, pensja=2000},
                new Developer(){imie="Sebastian", nazwisko="Ogrodowczyk", jezyk_programowania="MongoDB", staz=0, pensja=8000}
            };

            var klient = new MongoClient(mongo);
            var baza = klient.GetDatabase("nosql");
            var kolekcja = baza.GetCollection<Developer>("developers");

            foreach(var dev in developerzy) {
                kolekcja.InsertOne(dev);
                Console.WriteLine($"Do bazy zapisany Developer: {dev.imie} {dev.nazwisko}\n" +
                $"Programuje od {dev.staz} lat w języku: {dev.jezyk_programowania}\n" +
                $"Zarabia {dev.pensja}ZŁ");
            }
            Console.WriteLine("\n\n");
        }

        static void deserializacja() {

            Console.WriteLine("[DESERIALIZACJA]");
            var klient = new MongoClient(mongo);
            var baza = klient.GetDatabase("nosql");
            var kolekcja = baza.GetCollection<Developer>("developers");

            var output = kolekcja.Find(new BsonDocument()).ToList();
            foreach(var developer in output) {
                Console.WriteLine($"Znaleziony Developer: {developer.imie} {developer.nazwisko}\n" +
                    $"Programuje od {developer.staz} lat w języku: {developer.jezyk_programowania}\n" +
                    $"Zarabia {developer.pensja}ZŁ");
            }

        }
        static void Main(string[] args) {
            serializacja();
            deserializacja();
            Console.Read();
        }
    }
}
