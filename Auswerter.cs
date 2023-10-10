using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasybellAuswerter
{
    public class Auswerter
    {
        public List<Call> calls;
        List<string> eigenenummern = new List<string>();
        public Auswerter(List<Call> listeuebergabe)
        {
            calls = listeuebergabe;
            Console.WriteLine("Elemente in der Auswertzbg: " + calls.Count);
            eigeneNummern();
            AuswertungIn();
            AuswertungOut();
            gesammtauswertung();
        }

        private void eigeneNummern()
        {
            // Eine liste erstellen mit allen Nummern die als Eigene Nummern gefunden werden. Diese Liste wird später genutzt um Nummernspezifische Auswertungen zu erhalten.
            foreach (var call in calls)
            {

                if (!eigenenummern.Contains(call.ownNumber))
                {
                    eigenenummern.Add(call.ownNumber);
                  //  Console.WriteLine("eigene Nummer gefunden und hinzugefügt.: " + call.ownNumber);
                }
            }
        }

        public void AuswertungIn()
        {

            foreach (string eigeneNummer in eigenenummern)
            {
                Console.WriteLine("Auswertung EINGEHENDE anrufe für die Nummer.: " + eigeneNummer);

                //Zaehle Anrufe
                int anzahlanrufe = 0;
                int sprechzeit = 0;
                int anzahlNichtAngenommeneAnrufe = 0;
                foreach (Call call in calls)
                {
                    if (call.ownNumber == eigeneNummer && call.richtung == "in")
                    {
                        anzahlanrufe++;
                        sprechzeit = sprechzeit + call.duration;
                        if (call.duration == 0)
                        {
                            anzahlNichtAngenommeneAnrufe++;
                        }

                    }
                }
                Console.WriteLine("Anzahl der EINGEHENDEN Anrufe: " + anzahlanrufe);
                Console.WriteLine("Anzahl der EINGEHENDEN NICHT ANGENOMMEN: " + anzahlNichtAngenommeneAnrufe);
                Console.WriteLine("Sprechzeit Eingehend: " + sprechzeit / 60 + " Minuten");
            }


        }

        public void AuswertungOut()
        {

            foreach (string eigeneNummer in eigenenummern)
            {
                Console.WriteLine("Auswertung Ausgehende anrufe für die Nummer.: " + eigeneNummer);

                //Zaehle Anrufe
                int anzahlanrufe = 0;
                int sprechzeit = 0;
                int anzahlNichtAngenommeneAnrufe = 0;
                foreach (Call call in calls)
                {
                    if (call.ownNumber == eigeneNummer && call.richtung == "out")
                    {
                        anzahlanrufe++;
                        sprechzeit = sprechzeit + call.duration;
                        if (call.duration == 0)
                        {
                            anzahlNichtAngenommeneAnrufe++;
                        }

                    }
                }
                Console.WriteLine("Anzahl der Ausgehende Anrufe: " + anzahlanrufe);
                Console.WriteLine("Anzahl der Ausgehende NICHT ANGENOMMEN: " + anzahlNichtAngenommeneAnrufe);
                Console.WriteLine("Sprechzeit Ausgehende: " + sprechzeit / 60 + " Minuten");
            }

        }

        public void gesammtauswertung()
        {
            int anzahlanrufe = 0;
            int sprechzeit = 0;

            foreach (Call call in calls)
            {
               sprechzeit = call.duration + sprechzeit;
            }

            Console.WriteLine("Anzahl der GESAMMTEN Gespraeche: " + calls.Count);
          //  Console.WriteLine("Anzahl der Ausgehende NICHT ANGENOMMEN: " + anzahlNichtAngenommeneAnrufe);
            Console.WriteLine("Sprechzeit Ausgehende: " + sprechzeit / 60 /60+ " Stunden");
        }


    }
}
