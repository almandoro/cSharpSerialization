using System;
using System.Collections.Generic;
using System.Text;

namespace serializacja_SQL {
    class Developer {

        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string jezyk_programowania { get; set; }
        public int staz { get; set; }
        public int pensja { get; set; }

        public Developer() {

        }

        public Developer(int id, string imie, string nazwisko, string jezyk_programowania, int staz, int pensja) {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.jezyk_programowania = jezyk_programowania;
            this.staz = staz;
            this.pensja = pensja;
        }
    }
}
