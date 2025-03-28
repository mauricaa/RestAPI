using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    public class Klassenraum
    {
        public string RoomName { get; set; }
        public double Size { get; set; }
        public int Seats { get; set; }
        public bool HasCynap { get; set; }
        public List<Schueler> Schueler { get; set; }

        public Klassenraum(string roomName, double size, int seats, bool hasCynap)
        {
            RoomName = roomName;
            Size = size;
            Seats = seats;
            HasCynap = hasCynap;
            Schueler = new List<Schueler>();
        }

        public void AddSchueler(Schueler schueler)
        {
            if (Schueler.Count >= Seats)
            {
                throw new InvalidOperationException($"Kann Schüler {schueler.Name}: nicht hinzufügen da der Raum bereits vollständig besetzt ist.");
            }

            Schueler.Add(schueler);
        }

        public void RemoveSchueler(Schueler schueler)
        {
            Schueler.Remove(schueler);
        }
    }
}