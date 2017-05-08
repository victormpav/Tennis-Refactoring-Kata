namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private const string PLAYER_ONE_NAME = "player1";

        private readonly Player playerOne;
        private readonly Player playerTwo;
        private readonly Match match;

        public TennisGame3(string playerOneName, string playerTwoName)
        {
            playerOne = new Player(playerOneName);
            playerTwo = new Player(playerTwoName);

            match = new Match(playerOne, playerTwo);
        }

        public string GetScore()
        {
            ReadableScoreBoard readableScoreBoard = new ReadableScoreBoard(match);
            return readableScoreBoard.Score();
        }

        public void WonPoint(string playerName)
        {
            if (playerName == PLAYER_ONE_NAME)
                playerOne.IncreaseScore();
            else
                playerTwo.IncreaseScore();
        }
    }
}

