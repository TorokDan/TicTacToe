namespace TicTacToe
{
    
    public class Field
    {
        public int Position { get; set; }
        public bool Checked { get; set; }
        public Players CheckedBy { get; set; }

        public Field(int position)
        {
            Position = position;
            Checked = false;
            CheckedBy = Players.None;
        }

        public void Check(Players jatekos)
        {
            Checked = true;
            CheckedBy = jatekos;
        }

        public override string ToString()
        {
            if (Checked)
                return CheckedBy == Players.Player1 ? "X" : "O";
            return Position.ToString();
        }
    }
}
