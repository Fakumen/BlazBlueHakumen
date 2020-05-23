using System.Drawing;

namespace BlazBlueFighter
{
    public class Sprite
    {
        public readonly Image Image;
        public readonly Point Root;

        public Sprite(Image image, Point root)
        {
            Image = image;
            Root = root;
        }

        //public Sprite(Image image) : this(image, new Point(0, 0)) { }
    }
}
