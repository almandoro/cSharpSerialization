using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace serializacja_SQL {
    class Program {
        public static string connectionString = "Data Source=C:\\Users\\Maciek\\source\\serializacja_SQL\\baza.db";

        public static void serializacja() {
            Console.WriteLine("[SERIALIZACJA]");

            Developer[] developerzy = {
                new Developer(){id=1, imie="Maciej", nazwisko="Marcinkowski", jezyk_programowania="Java", staz=2, pensja=2000},
                new Developer(){id=2, imie="Sebastian", nazwisko="Ogrodowczyk", jezyk_programowania="MongoDB", staz=0, pensja=8000}
            };

            using(IDbConnection cnn = new SQLiteConnection(connectionString)) {
                foreach(var dev in developerzy) {
                    var output = cnn.Query<Developer>("" +
                    "INSERT INTO developers (id,imie,nazwisko,jezyk_programowania,staz,pensja)" +
                    $"VALUES ({dev.id},\"{dev.imie}\",\"{dev.nazwisko}\",\"{dev.jezyk_programowania}\",{dev.staz},{dev.pensja});", new DynamicParameters());
                    Console.WriteLine($"Do bazy zapisany Developer: {dev.imie} {dev.nazwisko}\n" +
                                    $"Programuje od {dev.staz} lat w języku: {dev.jezyk_programowania}\n" +
                                    $"Zarabia {dev.pensja}ZŁ");
                }
            }
        }

        public static void deserializacja() {
            Console.WriteLine("[DESERIALIZACJA]");
            using(IDbConnection cnn = new SQLiteConnection(connectionString)) {
                var output = cnn.Query<Developer>("SELECT * FROM developers", new DynamicParameters());
                foreach(var developer in output) {                    
                    Console.WriteLine($"Znaleziony Developer: {developer.imie} {developer.nazwisko}\n" +
                        $"Programuje od {developer.staz} lat w języku: {developer.jezyk_programowania}\n" +
                        $"Zarabia {developer.pensja}ZŁ");
                }
            }
        }
        static void Main(string[] args) {
            serializacja();
            deserializacja();
            Console.ReadKey();

        }
    }
}
