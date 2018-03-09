using System;
using System.Linq;
using AwesomeBot.Helper;
using AwesomeBot.Move;

namespace AwesomeBot.Bot
{
    public class AwesomeBot
    {
        private readonly MoveType _direction;
        private MoveType _lastMove;

        public AwesomeBot()
        {
            _direction = new Random().Next() % 2 == 0 ? MoveType.Left : MoveType.Right;    
        }

        public Move.Move MoveBot(BotState state)
        {
            var board = state.Board;

            if (state.RoundNumber == 1)
            {
                _lastMove = board.MyId.ToString() == BotConstants.Player1 ? MoveType.Left : MoveType.Right;
                return new Move.Move(_lastMove);
            }

            var validMoves = board.GetValidMoves(board.MyPosition);
            //validMoves.ShiftLeft(1);

            var move = validMoves.Contains(_lastMove) ? MoveType.Pass : validMoves[new Random().Next(validMoves.Count - 1)];
            //var move = validMoves.FirstOrDefault();

            return new Move.Move(move);
        }
    }
}
