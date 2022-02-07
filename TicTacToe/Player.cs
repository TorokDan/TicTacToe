namespace TicTacToe
{
    public enum Players { None, Player1, Player2 };
    public class Player
    {
        public Players Name { get; set; }
        public bool Nyert { get; set; }

        public Player(Players name)
        {
            Name = name;
        }
    }
}
