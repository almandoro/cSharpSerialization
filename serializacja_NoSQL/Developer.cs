using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace serializacja_NoSQL {
    class Developer {

        [BsonId]
        public Guid id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string jezyk_programowania { get; set; }
        public int staz { get; set; }
        public int pensja { get; set; }

        public Developer() {

        }

        public Developer(string imie, string nazwisko, string jezyk_programowania, int staz, int pensja) {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.jezyk_programowania = jezyk_programowania;
            this.staz = staz;
            this.pensja = pensja;
        }
    }
}
