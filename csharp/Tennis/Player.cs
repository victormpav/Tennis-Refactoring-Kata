namespace Tennis
{
    public class Player
    {
        public int score;
        public string name;

        public int playerTwoScore;
        public string playerTwoNameS;

        public Player(string name)
        {
            this.name = this.playerTwoNameS = name;
        }
    }
}
