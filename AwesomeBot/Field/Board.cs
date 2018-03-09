using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeBot.Bot;
using AwesomeBot.Helper;
using AwesomeBot.Move;

namespace AwesomeBot.Field
{
    public class Board
    {
        public int MyId { get; set; }
        public int EnId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string[][] FieldPositions { get; set; }

        public Point MyPosition { get; private set; }
        public Point EnemyPosition { get; set; }


        public void InitField()
        {
            try
            {
                FieldPositions = new string[Width][];
                for (int i = 0; i < Width; i++)
                {
                    FieldPositions[i] = new string[Height];
                }
            }
            catch (Exception)
            {
                throw new Exception("Error: field settings have not been parsed. Cannot initalize field");
            }

            ClearField();
        }

        public List<MoveType> Directions =
            new List<MoveType> {MoveType.Up, MoveType.Down, MoveType.Left, MoveType.Right};

        public Dictionary<MoveType, MoveType> Mirror = new Dictionary<MoveType, MoveType>
        {
            [MoveType.Up] = MoveType.Down,
            [MoveType.Down] = MoveType.Up,
            [MoveType.Left] = MoveType.Right,
            [MoveType.Right] = MoveType.Left
        };

        public List<MoveType> GetValidMoves(Point point)
        {
            var validMoves = new List<KeyValuePair<MoveType, Point>>
            {
                new KeyValuePair<MoveType, Point>(MoveType.Down, new Point(point.X, point.Y + 1)),
                new KeyValuePair<MoveType, Point>(MoveType.Up, new Point(point.X, point.Y -1)),
                new KeyValuePair<MoveType, Point>(MoveType.Left, new Point(point.X - 1, point.Y)),
                new KeyValuePair<MoveType, Point>(MoveType.Right, new Point(point.X + 1, point.Y)),
            };

            return validMoves.Where(i => IsValidPoint(i.Value)).Select(i => i.Key).ToList();
        }

        private bool IsValidPoint(Point point) 
            => ((point.X >= 0 && point.X < Width) &&  (point.Y >= 0 && point.Y < Height)) &&
                                                  FieldPositions[point.X][point.Y].Free();

        private void ClearField()
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    FieldPositions[x][y] = ".";

            MyPosition = null;
        }

        public void ParseFromString(string s)
        {
            ClearField();

            var split = s.Split(',');
            var x = 0;
            var y = 0;

            foreach (var value in split)
            {
                FieldPositions[x][y] = value;

                if (value != BotConstants.Wall && value != BotConstants.Free)
                {
                    if (value.Equals(MyId.ToString()))
                    {
                        MyPosition = new Point(x, y);
                    }
                    else
                    {
                        EnemyPosition = new Point(x, y);
                        EnId = Int32.Parse(value);
                    }
                }

                if (++x == Width)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }
}
