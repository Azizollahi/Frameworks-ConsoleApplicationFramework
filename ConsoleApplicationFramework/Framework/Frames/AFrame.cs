using ConsoleApplicationFramework.Framework.Drawing;
using ConsoleApplicationFramework.Framework.Frames.Content;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Frames {

    public abstract class AFrame : Frame {
        protected Point Point;
        protected Size Size;
        protected Map Map;
        protected AFrame(Point point, Size size) {
            Point = point;
            Size = size;
            ConstructMap();
        }
        protected AFrame(Size size) {
            Point = new Point();
            Size = size;
            ConstructMap();
        }

        protected abstract void ConstructMap();
        
        public virtual void Draw(Drawer drawer) {
            for (var yIndex = 0; yIndex < Map.YLength(); yIndex++) {
                for (var xIndex = 0; xIndex < Map.XLength(); xIndex++) {
                    var drawingPoint = new Point(Point.XPosition + xIndex, Point.YPosition + yIndex);
                    var cellPoint = new Point(xIndex,yIndex);
                    Map.GetCell(cellPoint).Draw(drawingPoint,drawer);
                }
            }
        }

        public void SetPosition(Point point) {
            Point = point;
        }

        public Size GetSize() {
            return Size;
        }
    }
}