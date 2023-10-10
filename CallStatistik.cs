using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasybellAuswerter
{
    public class CallStatistik
    {

        //Liste um alle eigenen Nummern zu Speichern 
        List<string> eigenenummern = new List<string>();
        public List<Call> calls;
        List<string> mesages = new List<string>();
        DateTime startdatum = DateTime.Now;
        DateTime enddatum = DateTime.Now;

        public CallStatistik(List<Call> listeuebergabe)
        {
            calls = listeuebergabe;
            eigeneNummern();      
            Datumsbereich();
            MeldungsManager.HinzufuegenMeldung("Es werden " + calls.Count + "Anrufe Ausgewertet.");
            MeldungsManager.HinzufuegenMeldung("Es wurden " + eigenenummern.Count + " eigene Nummern erkannt.");
            MeldungsManager.HinzufuegenMeldung("Datumsbereich " + startdatum.Date + " Enddatum: " + enddatum.Date);


            Auswertung();
        
            generiereBericht(); 
        }

        private void eigeneNummern()
        {
            // Eine liste erstellen mit allen Nummern die als Eigene Nummern gefunden werden. Diese Liste wird später genutzt um Nummernspezifische Auswertungen zu erhalten.
            foreach (var call in calls)
            {

                if (!eigenenummern.Contains(call.ownNumber))
                {
                    eigenenummern.Add(call.ownNumber);
                   
                }
            }

        }

        public void Auswertung()
        {
            //die Tabelle Calls wird durchsucht nach eigenen Nummern, Pro Nummer wird die Auswertung volzogen.
            foreach ( string eigeneNummer in eigenenummern)
            {
                
                int anzahlAnrufRichtungIn = 0;
                int zeitRichtungIn = 0;           
                int anzahlAnrufeRichtungOut = 0;
                int zeitRichtungOut =0;
                int anzahlNichtAngenommeneAnrufeIn = 0;
                int anzahlNichtAngenommeneAnrufeOut = 0;
                float prozentAnrufeVerpasstOut = 0;
                float prozentAnrufeVerpasstIn = 0;
                //die Calls Durchgehen:
                foreach (Call call in calls)
                {
                    //Bestimmen das nur die Jetzt zu Prüfende Nummer ausgewertet wird:
                    if(call.ownNumber == eigeneNummer)
                    {
                        //Prüfen ob richtung in oder Out ist
                        if(call.richtung == "in")
                        {
                            anzahlAnrufRichtungIn++;
                            zeitRichtungIn = zeitRichtungIn + call.duration;
                            if(call.duration == 0)
                            {
                                anzahlNichtAngenommeneAnrufeIn++;
                            }
                        }
                        if (call.richtung == "out")
                        {
                            anzahlAnrufeRichtungOut++;
                            zeitRichtungOut = zeitRichtungOut + call.duration;
                            if (call.duration == 0)
                            {
                                anzahlNichtAngenommeneAnrufeOut++;
                            }
                        }
                    }
                }

                if (anzahlAnrufeRichtungOut > 0)
                {
                    prozentAnrufeVerpasstOut = ((float)anzahlNichtAngenommeneAnrufeOut / anzahlAnrufeRichtungOut) * 100;
                }

                if (anzahlAnrufRichtungIn > 0)
                {
                    prozentAnrufeVerpasstIn = ((float)anzahlNichtAngenommeneAnrufeIn / anzahlAnrufRichtungIn) * 100;
                }

                MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++++++++++++++++++++++++ ");
                MeldungsManager.HinzufuegenMeldung("Analyse für Nummer " + eigeneNummer);
                MeldungsManager.HinzufuegenMeldung("Anzahl eingehende Anrufe " + anzahlAnrufRichtungIn);
                MeldungsManager.HinzufuegenMeldung("Anzahl ausgehende Anrufe " + anzahlAnrufeRichtungOut);
                MeldungsManager.HinzufuegenMeldung("Dauer eingehende Anrufe in Stunden " + zeitRichtungIn / 60 / 60);
                MeldungsManager.HinzufuegenMeldung("Dauer eingehende Anrufe in Minuten " + zeitRichtungIn / 60);
                MeldungsManager.HinzufuegenMeldung("Dauer ausgehende Anrufe in Stunden " + zeitRichtungOut / 60 / 60);
                MeldungsManager.HinzufuegenMeldung("Dauer ausgehende Anrufe in Minuten " + zeitRichtungOut / 60);
                MeldungsManager.HinzufuegenMeldung("Nicht angenommene Anrufe Ausgehend " + anzahlNichtAngenommeneAnrufeOut);
                MeldungsManager.HinzufuegenMeldung("Nicht angenommene Anrufe eingehend " + anzahlNichtAngenommeneAnrufeIn);
                MeldungsManager.HinzufuegenMeldung("Nicht angenommene Prozenz ausgehend " + prozentAnrufeVerpasstOut);
                MeldungsManager.HinzufuegenMeldung("Nicht angenommene Prozent eingehend " + prozentAnrufeVerpasstIn);
                MeldungsManager.HinzufuegenMeldung("    ");

                

            }
        }

    public void Datumsbereich()
        {

            foreach (Call call in calls)
            {
                if (call.timestamp < startdatum) { startdatum = call.timestamp; }
                if (call.timestamp > enddatum) {  enddatum = call.timestamp; }
            }
        }
    public void generiereBericht()
        {
            foreach (string mesage in mesages)
            {
                Console.WriteLine(mesage);
            }
        }
   
    }
}
