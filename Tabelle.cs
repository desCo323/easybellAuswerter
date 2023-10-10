using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace EasybellAuswerter
{
    class Tabelle
    {
        List<Call> list = new List<Call>();
        bool isFirstLine = true;
        public Tabelle()
        {

            
            string inputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input");

            // Überprüfen, ob der Ordner existiert
            if (Directory.Exists(inputFolderPath))
            {
                // Alle Dateien im Ordner abrufen
                string[] filePaths = Directory.GetFiles(inputFolderPath);

                foreach (string filePath in filePaths)
                {
                    string[] zeilen = File.ReadAllLines(filePath);

                    bool isFirstLine = true;

                    foreach (string ze in zeilen)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue; // Überspringe die erste Zeile und gehe zur nächsten Zeile
                        }

                        string[] daten = ze.Split(',');
                        DateTime timestamp = DateTime.Parse(daten[1]);
                        int dauer = int.Parse(daten[2]);
                        string eigeneNr = daten[3];
                        string richtung = daten[4];
                        string gegenstelle = daten[5];

                        list.Add(new Call { timestamp = timestamp, duration = dauer, ownNumber = eigeneNr, richtung = richtung, gegenstelle = gegenstelle });
                    }
                }
            }
            else
            {
                Console.WriteLine("Der Ordner 'input' im aktuellen Verzeichnis existiert nicht.");
            }

            // Die Liste "list" enthält nun Daten aus allen Dateien im Ordner "input".
            // Sie können die Liste weiter verarbeiten oder auswerten.
            //list = new List<Call>();
            //string[] zeilen = File.ReadAllLines(@"C:\Users\gre\Downloads\data.csv");
            //foreach (string ze in zeilen)
            //{
            //    if (isFirstLine)
            //    {
            //        isFirstLine = false;
            //        continue; // Überspringe die erste Zeile und gehe zur nächsten Zeile
            //    }
            //    string[] daten = ze.Split(',');
            //    DateTime timestamp = DateTime.Parse(daten[1]);;
            //    int dauer = int.Parse(daten[2]);
            //    string eigeneNr = daten[3]; 
            //    string richtung = daten[4]; 
            //    string gegenstelle = daten[5];
            //   // var parseDate = DateTime.Parse(timestamp);
            //    //Console.WriteLine(parseDate);

            //    list.Add(new Call { timestamp = timestamp, duration = dauer, ownNumber = eigeneNr, richtung = richtung, gegenstelle = gegenstelle });
            //}

            //foreach (Call listitem in list)
            //{
            //    Console.WriteLine(listitem.ToString());
            //}
            Console.WriteLine("Anzahl der Elemente in der Auswertung: " + list.Count);
            

        }
        public List<Call> GetAllCalls() { return list; }    
    }
}
