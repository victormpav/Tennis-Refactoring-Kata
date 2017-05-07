using System;

namespace Tennis
{
    public class Match
    {
        private const int FORTY_POINTS = 3;

        public readonly Player playerOne;
        public readonly Player playerTwo;

        public Match(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public int AbsoluteDiffrenceBetweenPlayers()
        {
            return Math.Abs(playerOne.score - playerTwo.score);
        }

        public Player PlayerWithHighScore()
        {
            return playerOne.score > playerTwo.score ? playerOne : playerTwo;
        }

        public bool Tied()
        {
            return playerOne.score == playerTwo.score;
        }

        public bool TiedAtFourtyOrMore()
        {
            bool playersScoreFortyOrMore = playerOne.score >= FORTY_POINTS && playerTwo.score >= FORTY_POINTS;
            return Tied() && playersScoreFortyOrMore;
        }

        public bool AtLeastOnePlayerHasMoreThanForty()
        {
            return (playerOne.score > FORTY_POINTS) || (playerTwo.score > FORTY_POINTS);
        }
    }
}