using System;
using System.Collections.Generic;
using System.Linq;
using Test_2;

namespace SchoolManagement
{
    public class Schule
    {
        public List<Schueler> Schueler { get; set; }
        public List<Klassenraum> Klassenraeume { get; set; }

        public Schule()
        {
            Schueler = new List<Schueler>();
            Klassenraeume = new List<Klassenraum>();
        }

        // Methode 1: Gesamtanzahl der Schüler
        public int GetTotalSchueler()
        {
            return Schueler.Count;
        }

        // Methode 2: Anzahl der männlicher und weiblicher Schüler
        public (int maleCount, int femaleCount) GetMaleAndFemaleCount()
        {
            int maleCount = Schueler.Count(s => s.Gender == "Male");
            int femaleCount = Schueler.Count(s => s.Gender == "Female");
            return (maleCount, femaleCount);
        }

        // Methode 3: der Klassenräume
        public int GetTotalKlassenraeume()
        {
            return Klassenraeume.Count;
        }

        // Methode 4: Durchschnittsalter der Schüler
        public int GetAverageAge()
        {
            DateTime today = DateTime.Today;
            var totalAge = Schueler.Sum(s => (today - s.BirthDate).Days / 365.25);
            double averageAge = totalAge / Schueler.Count;

            return (int)Decimal.Round((decimal)averageAge, 0, MidpointRounding.ToZero); // rundet immer ab
        }
        // Methode 5: Klassenräume mit Cynap-Gerät 
        public List<Klassenraum> GetKlassenraeumeWithCynap()
        {
            return Klassenraeume.Where(k => k.HasCynap).ToList();
        }

        // Methode 6: Anzahl verschiedenen Klassen 
        public int GetTotalKlassen()
        {
            return Schueler.Select(s => s.ClassName).Distinct().Count();
        }

        // Methode 7:  alle Klassen der Schule mit der Anzahl der Schüler 
        public Dictionary<string, int> GetClassStudentCount()
        {
            return Schueler
                .GroupBy(s => s.ClassName)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Methode 8:  Frauenanteil in % einer Klasse 
        public double GetFemalePercentageInClass(string className)
        {
            var studentsInClass = Schueler.Where(s => s.ClassName == className).ToList();
            int femaleCount = studentsInClass.Count(s => s.Gender == "Female");
            return (femaleCount / (double)studentsInClass.Count) * 100;

        }

        // Methode 9: ob eine Klasse in einem bestimmten Raum unterrichtet werden kann oder ob zu wenig Plätze vorhanden sind
        public bool CanClassBeTaughtInRoom(string className, Klassenraum room)
        {
            var classSize = Schueler.Count(s => s.ClassName == className);
            return room.Seats >= classSize;
        }
    }
}