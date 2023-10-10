using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasybellAuswerter
{
    public static class MeldungsManager
    {
        private static List<string> meldungsListe = new List<string>();

        public static void HinzufuegenMeldung(string meldungstext)
        {
            meldungsListe.Add(meldungstext);
        }

        public static List<string> HoleMeldungsListe()
        {
            return meldungsListe;
        }
    }

    // Beispiel für eine Klasse, die die Meldungsliste verwendet


  
}
