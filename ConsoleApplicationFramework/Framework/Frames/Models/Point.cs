namespace ConsoleApplicationFramework.Framework.Frames.Models
{
    public class Point
    {
        public Point() {
            XPosition = 0;
            YPosition = 0;
        }

        public Point(int xPos, int yPos) {
            XPosition = xPos;
            YPosition = yPos;
        }
        public int YPosition { get; set; }
        public int XPosition { get; set; }
    }
}