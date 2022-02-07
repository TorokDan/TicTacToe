namespace TicTacToe
{
    public class Board
    {
        public int Hosszusag { get; set; }
        public Field[,] Mezok { get; set; }

        public Board(int hossz)
        {
            Hosszusag = hossz * hossz;
            Mezok = new Field[hossz, hossz];
            MezokErtekadas();
        }

        public bool BenneVan(int keresendo)
        {
            foreach (var mezo in Mezok)
                if (mezo.Position == keresendo)
                    return true;
            return false;
        }
        public bool CheckedByPosition(int keresendo) //Todo
        {
            foreach (var mezo in Mezok)
                if (mezo.Position == keresendo)
                    return mezo.Checked;
            return false; //Ezt nem tudom, h hogy kéne szebben megoldani....
        }
        public Field FieldByPosition(int keresendo) //Todo
        {
            foreach (var mezo in Mezok)
                if (mezo.Position == keresendo)
                    return mezo;
            return new Field(0); //....
        }
        public bool CheckIfWonByPosition(Players jatekos, int position)
        {
            var vissza = false;
            switch (position)
            {
                case 1:
                    vissza =
                        CheckArray(jatekos, new int[] { 2, 3 }) ||
                        CheckArray(jatekos, new int[] { 5, 9 }) ||
                        CheckArray(jatekos, new int[] { 4, 7 });
                    break;
                case 2:
                    vissza = 
                        CheckArray(jatekos, new int[] { 1, 3 })||
                        CheckArray(jatekos, new int[] { 5, 8 });
                    break;
                case 3:
                    vissza = 
                        CheckArray(jatekos, new int[] { 1, 2 })||
                        CheckArray(jatekos, new int[] { 5, 7 })||
                        CheckArray(jatekos, new int[] { 6, 9 });
                    break;
                case 4:
                    vissza = 
                        CheckArray(jatekos, new int[] { 1, 7 })||
                        CheckArray(jatekos, new int[] { 5, 6 });
                    break;
                case 5:
                    vissza =
                        CheckArray(jatekos, new int[] { 1, 9 })||
                        CheckArray(jatekos, new int[] { 2, 8 })||
                        CheckArray(jatekos, new int[] { 3, 7 })||
                        CheckArray(jatekos, new int[] { 4, 6 });
                    break;
                case 6:
                    vissza =
                        CheckArray(jatekos, new int[] { 3, 9 })||
                        CheckArray(jatekos, new int[] { 4, 5 });
                    break;
                case 7:
                    vissza =
                        CheckArray(jatekos, new int[] { 1, 4 })||
                        CheckArray(jatekos, new int[] { 3, 5 })||
                        CheckArray(jatekos, new int[] { 8, 9 });
                    break;
                case 8:
                    vissza =
                        CheckArray(jatekos, new int[] { 2, 5 })||
                        CheckArray(jatekos, new int[] { 7, 9 });
                    break;
                case 9:
                    vissza =
                        CheckArray(jatekos, new int[] { 1, 5 })||
                        CheckArray(jatekos, new int[] { 3, 6 })||
                        CheckArray(jatekos, new int[] { 7, 8 });
                    break;
                default:
                    vissza = false;
                    break;
            }
            return vissza;
        }

        private void MezokErtekadas()
        {
            var seged = 1;
            for (int i = 0; i < Mezok.GetLength(0); i++)
                for (int j = 0; j < Mezok.GetLength(1); j++)
                    Mezok[i, j] = new Field(seged++);
        }
        private bool CheckArray(Players jatekos, int[] positions)
        {
            int szamlalo = 0;
            while (szamlalo < positions.Length &&
                FieldByPosition(positions[szamlalo]).Checked == true &&
                FieldByPosition(positions[szamlalo]).CheckedBy == jatekos)
                szamlalo++;
            return szamlalo == positions.Length;
        }

        public override string ToString()
        {
            var eredmeny = string.Empty;
            var simaSor = new string(' ', 3) + '|' + new string(' ', 3) + '|' + new string(' ', 3) + "\n";
            var valasztoSor = new string('_', 3) + '|' + new string('_', 3) + '|' + new string('_', 3) + "\n";
            for (int i = 0; i < Mezok.GetLength(0); i++)
            {
                var seged = string.Empty;
                for (int j = 0; j < Mezok.GetLength(1); j++)
                {
                    if (!string.IsNullOrEmpty(seged))
                        seged += '|';
                    seged += $" {Mezok[i, j].ToString()} ";
                }
                seged += "\n";
                if (!string.IsNullOrEmpty(eredmeny))
                    eredmeny += valasztoSor + simaSor + seged;
                else
                    eredmeny += simaSor + seged;
            }
            eredmeny += simaSor;
            return eredmeny;
        }
    }
}
