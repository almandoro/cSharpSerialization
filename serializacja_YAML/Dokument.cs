using System;
using System.Collections.Generic;
using System.Text;

namespace serializacja_YAML {
    class Dokument {
        public string rodzaj { get; set; }
        public DateTime data { get; set; }
        public Klient klient { get; set; }
        public Przedmiot[] przedmioty { get; set; }
    }
}
