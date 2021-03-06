using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PilesOfTiles.Input.Messages;
using PilesOfTiles.Tiles;

namespace PilesOfTiles.Bricks
{
    public class Brick
    {
        public Vector2 Position { get; private set; }
        public Direction PointsAt { get; private set; }
        public BrickMap BrickMap { get; private set; }

        public IEnumerable<ITile> Tiles
        {
            get { return BrickMap.GetTilesWhenPointingAt(PointsAt, Position); }
        }

        public Brick(Vector2 position, Direction pointsAt, BrickMap brickMap)
        {
            Position = position;
            PointsAt = pointsAt;
            BrickMap = brickMap;
        }

        public void Update(Action action)
        {
            switch (action)
            {
                case Action.RotateClockWise:
                    RotateClockWise();
                    break;
                case Action.RotateCounterClockWise:
                    RotateCounterClockWise();
                    break;
                case Action.MoveLeft:
                    Move(new Vector2(-1, 0));
                    break;
                case Action.MoveRight:
                    Move(new Vector2(1, 0));
                    break;
                case Action.MoveDown:
                    Move(new Vector2(0, 1));
                    break;
            }
        }

        public void Move(Vector2 position)
        {
            Position += position;
        }

        public void RotateClockWise()
        {
            switch (PointsAt)
            {
                case Direction.Up:
                    PointsAt = Direction.Right;
                    break;
                case Direction.Right:
                    PointsAt = Direction.Down;
                    break;
                case Direction.Down:
                    PointsAt = Direction.Left;
                    break;
                case Direction.Left:
                    PointsAt = Direction.Up;
                    break;
            }
        }

        public void RotateCounterClockWise()
        {
            switch (PointsAt)
            {
                case Direction.Up:
                    PointsAt = Direction.Left;
                    break;
                case Direction.Right:
                    PointsAt = Direction.Up;
                    break;
                case Direction.Down:
                    PointsAt = Direction.Right;
                    break;
                case Direction.Left:
                    PointsAt = Direction.Down;
                    break;
            }
        }

    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}