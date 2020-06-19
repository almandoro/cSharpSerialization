using System;
using System.Runtime.Serialization;

namespace zadanie1_core {

    [Serializable]
    public class Osoba {
        public string Imie { set; get; }
        public string Nazwisko { set; get; }
        private int rokUrodzenia;
        public int Wiek {
            get { return DateTime.Now.Year - rokUrodzenia; }
        }

        [NonSerialized]
        private string haslo;

        private int Maska;

        public bool SprawdzHaslo(string hasloTest) {
            if(haslo == hasloTest)
                return true;
            return false;
        }
        public bool UstawHaslo(string stare, string nowe) {
            if(SprawdzHaslo(stare)) {
                haslo = nowe;
                return true;
            }
            return false;
        }
        public Osoba(int rokUrodzenia, string haslo) {
            this.rokUrodzenia = rokUrodzenia;
            this.haslo = haslo;
        }

        [OnSerializing]
        private void PrzedSeralizacja(StreamingContext context) {
            rokUrodzenia ^= Maska;
        }

        [OnSerialized]
        private void PoSerializacji(StreamingContext context) {
            rokUrodzenia ^= Maska;
        }

        [OnDeserialized]
        private void PoDeserializacji(StreamingContext context) {
            rokUrodzenia ^= Maska;
            haslo = Imie + Nazwisko;
        }


    }

}
