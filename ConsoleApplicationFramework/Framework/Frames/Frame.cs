using ConsoleApplicationFramework.Framework.Drawing;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Frames {
	public interface Frame {
		void Draw(Drawer drawer);
		void SetPosition(Point point);
		Size GetSize();
	}
}