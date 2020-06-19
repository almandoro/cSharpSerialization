using System;
using System.Xml.Serialization;

namespace zadanie2_core {
    public class Towar {
        [XmlElement("NazwaTowaru")]
        public string Nazwa { set; get; }
        public decimal CenaDetaliczna { set; get; }

        [XmlIgnore]
        public decimal CenaHurtowa { set; get; }

        [XmlAttribute("Id")]
        public int IdTowaru { set; get; }        public Towar() {
            Nazwa = "Brak";
            CenaDetaliczna = 0;
            CenaHurtowa = 0;
            IdTowaru = -1;
        }
    }
}
