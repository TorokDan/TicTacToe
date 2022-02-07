using System;

namespace TicTacToe
{
    public class Game
    {
        private Player aktualisJatekos;
        private bool ended;

        public Board Tabla { get; set; }
        public Player[] Jatekosok { get; set; }

        public Game()
        {
            Tabla = new Board(3);
            Jatekosok = new Player[] {
                new Player(Players.Player1),
                new Player(Players.Player2)
            };
            aktualisJatekos = Jatekosok[0];
            ended = false;
        }

        public void Kor()
        {
            //Tabla.Mezok[0, 0].Check(aktualisJatekos.Name);
            while (!ended)
            {
                Console.WriteLine(Tabla.ToString());
                Console.WriteLine($"\n{aktualisJatekos.Name}: Kérlek válassz egy mezőt");
                var be = Console.ReadLine();
                    if (!int.TryParse(be, out var beKonvertalt))
                        Console.WriteLine("Kérlek számot adj meg!");
                    else if (Tabla.Hosszusag < beKonvertalt)
                        Console.WriteLine("Kérlek a választható számok közül válassz!");
                    else if (Tabla.CheckedByPosition(beKonvertalt))
                        Console.WriteLine("Kérlek olyat válassz, ami még nem volt választva");
                    else
                        Console.WriteLine($"A választott mező a(z) {Lepes(beKonvertalt)}");
                System.Threading.Thread.Sleep(800);
                Console.Clear();
            }
            Console.WriteLine($"A nyertes {aktualisJatekos.Name}\n\n");
            Console.WriteLine(Tabla.ToString());
            Console.ReadKey();
        }

        private int Lepes(int be)
        {
            Tabla.FieldByPosition(be).Check(aktualisJatekos.Name);

            ended = Tabla.CheckIfWonByPosition(aktualisJatekos.Name, be);
            if (!ended)
                aktualisJatekos = aktualisJatekos == Jatekosok[0] ? Jatekosok[1] : Jatekosok[0];
            return be;
        }
    }
}
