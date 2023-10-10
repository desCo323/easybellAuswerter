using EasybellAuswerter;



// See https://aka.ms/new-console-template for more information

EasybellAuswerter.Tabelle t = new Tabelle();

TimeCheck check = new TimeCheck();
List<Call> offen= new List<Call>();
List<Call> geschlossen = new List<Call>();
foreach ( Call Call in t.GetAllCalls())
{
    if ( check.istinOeffnungszeit(Call.timestamp))
    {
        offen.Add(Call);
        //Console.WriteLine("offen" + Call.ToString);
    }
    else
    {
        geschlossen.Add(Call);
        //Console.WriteLine("zu" + Call.ToString);
    }
}

MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("Anrufe WÄHREND den Öffnungszeiten");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("     ");
MeldungsManager.HinzufuegenMeldung("     ");
CallStatistik statistik1 = new CallStatistik(offen);

MeldungsManager.HinzufuegenMeldung("     ");
MeldungsManager.HinzufuegenMeldung("     ");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("Anrufe AUSSERHALB der Öffnungszeiten");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("+++++++++++++++++++++++++++++");
MeldungsManager.HinzufuegenMeldung("     ");
MeldungsManager.HinzufuegenMeldung("     ");
CallStatistik statistik2 = new CallStatistik(geschlossen);
//List<DateTime> testTimes = new List<DateTime>
//{
//    // Offene Testzeiten
//    new DateTime(2023, 6, 8, 10, 30, 0),
//    new DateTime(2023, 5, 8, 13, 45, 0),
//    new DateTime(2023, 10, 9, 17, 15, 0),
//    new DateTime(2023, 4, 6, 16, 30, 0),
//    new DateTime(2023, 3, 5, 9, 0, 0),
//    new DateTime(2023, 4, 5, 11, 45, 0),
//    new DateTime(2023, 2, 6, 14, 0, 0),
//    new DateTime(2023, 1, 8, 12, 15, 0),
//    new DateTime(2023, 2, 8, 17, 30, 0),
//    new DateTime(2023, 11, 6, 10, 0, 0),

//    // Geschlossene Testzeiten
//    new DateTime(2023, 10, 8, 0, 0, 0),
//    new DateTime(2023, 10, 8, 6, 30, 0),
//    new DateTime(2023, 10, 8, 20, 45, 0),
//    new DateTime(2023, 10, 8, 3, 15, 0),
//    new DateTime(2023, 10, 8, 22, 0, 0),
//    new DateTime(2023, 10, 8, 18, 45, 0),
//    new DateTime(2023, 10, 8, 21, 30, 0),
//    new DateTime(2023, 10, 8, 4, 0, 0),
//    new DateTime(2023, 10, 8, 23, 30, 0),
//    new DateTime(2023, 10, 8, 2, 15, 0)
//};
//foreach (DateTime testzeit in testTimes) {
//    check.istinOeffnungszeit(testzeit);
//        }

List<string> meldungen = MeldungsManager.HoleMeldungsListe();

Console.WriteLine("Meldungen:");
foreach (string meldung in meldungen)
{
    Console.WriteLine(meldung);
}

Console.ReadKey();