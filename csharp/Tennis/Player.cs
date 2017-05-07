namespace Tennis
{
    public class Player
    {
        private const int SINGLE_POINT = 1;

        public int score;
        public string name;

        public Player(string name)
        {
            this.name = name;
        }

        public void IncreaseScore()
        {
            score += SINGLE_POINT;
        }
    }
}
