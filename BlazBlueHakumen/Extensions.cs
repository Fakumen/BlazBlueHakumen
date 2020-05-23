using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BlazBlueFighter
{
    public static class Extensions
    {
        public static PointF Add(this PointF point1, PointF point2) => new PointF(point1.X + point2.X, point1.Y + point2.Y);

        public static PointF AddX(this PointF point, float dx) => new PointF(point.X + dx, point.Y);
        public static PointF AddY(this PointF point, float dy) => new PointF(point.X, point.Y + dy);
        public static PointF SetX(this PointF point, float x) => new PointF(x, point.Y);
        public static PointF SetY(this PointF point, float y) => new PointF(point.X, y);

        public static PointF Substract(this PointF point1, PointF point2) => new PointF(point1.X - point2.X, point1.Y - point2.Y);

        public static Point ToIntPoint(this PointF point) => new Point((int)point.X, (int)point.Y);
        
        public static Arrows Turn(this Arrows arrow, bool facingLeft)
        {
            if (arrow == Arrows.Up || arrow == Arrows.Neutral || arrow == Arrows.Down)
                return arrow;
            if (arrow == Arrows.Left)
                return facingLeft ? arrow : Arrows.Right;
            if (arrow == Arrows.UpLeft)
                return facingLeft ? arrow : Arrows.UpRight;
            if (arrow == Arrows.DownLeft)
                return facingLeft ? arrow : Arrows.DownRight;
            if (arrow == Arrows.Right)
                return facingLeft ? arrow : Arrows.Left;
            if (arrow == Arrows.UpRight)
                return facingLeft ? arrow : Arrows.UpLeft;
            return facingLeft ? arrow : Arrows.DownLeft;
        }
    }
}
