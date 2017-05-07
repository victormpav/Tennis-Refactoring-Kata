namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private const string LOVE_SCORE = "Love";
        private const string FIFTEEN_SCORE = "Fifteen";
        private const string THIRTY_SCORE = "Thirty";
        private const string FORTY_SCORE = "Forty";

        string[] SCORE_NAMES_MAPPING = { LOVE_SCORE, FIFTEEN_SCORE, THIRTY_SCORE, FORTY_SCORE };

        private const string ALL_SCORE = "-All";
        private const string SOCORE_SEPARATOR = "-";

        private const string DEUCE_SCORE = "Deuce";
        
        private const string ADVANTAGE_SCORE = "Advantage ";
        private const string WINER_MATCH = "Win for ";

        private const string PLAYER_ONE_NAME = "player1";
        private const int ADVANTAGE_THRESHOLD_POINTS = 4;
        private const int SINGLE_POINT = 1;
        private const int FORTY_POINTS = 3;

        private readonly Player m_playerOne;
        private readonly Player m_playerTwo;

        public TennisGame3(string playerOneName, string playerTwoName)
        {
            m_playerOne = new Player(playerOneName);
            m_playerTwo = new Player(playerTwoName);
        }

        public string GetScore()
        {
            string score;
            if ((PlayerScoresAreBelowAdvantageThreshold()) && PlayersAreNotTiedAtFourty())
            {
                score = SCORE_NAMES_MAPPING[m_playerOne.score];
                return (AreTied()) ? score + ALL_SCORE : score + SOCORE_SEPARATOR + SCORE_NAMES_MAPPING[m_playerTwo.score];
            }
            else
            {
                if (AreTied())
                    return DEUCE_SCORE;
                score = m_playerOne.score > m_playerTwo.score ? m_playerOne.name : m_playerTwo.name;
                return ((m_playerOne.score - m_playerTwo.score) * (m_playerOne.score - m_playerTwo.score) == 1) ? ADVANTAGE_SCORE + score : WINER_MATCH + score;
            }
        }

        public bool PlayersAreNotTiedAtFourty()
        {
            return !(m_playerOne.score == FORTY_POINTS && m_playerTwo.score == FORTY_POINTS);
        }

        private bool PlayerScoresAreBelowAdvantageThreshold()
        {
            return (m_playerOne.score < ADVANTAGE_THRESHOLD_POINTS) && (m_playerTwo.score < ADVANTAGE_THRESHOLD_POINTS);
        }

        private bool AreTied()
        {
            return m_playerOne.score == m_playerTwo.score;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == PLAYER_ONE_NAME)
                IncreaseScore(m_playerOne);
            else
                IncreaseScore(m_playerTwo);
        }

        private void IncreaseScore(Player player)
        {
            player.score += SINGLE_POINT;
        }
    }
}

