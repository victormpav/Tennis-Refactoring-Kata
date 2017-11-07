namespace Tennis
{
    public class Player
    {
        private const int MAX_SCORE = 3;
        public string Name { get; private set; }
        public int Score { get; private set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void IncreaseScore()
        {
            Score++;
        }

        public bool IsUnderMaxScore()
        {
            return Score <= MAX_SCORE;
        }

        public bool SameScoreAsPlayer(Player player)
        {
            return Score == player.Score;
        }
    }
}