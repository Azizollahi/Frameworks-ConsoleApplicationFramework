using ConsoleApplicationFramework.Framework.Drawing;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Frames.Content {
	public interface Cell {
		void Draw(Point point, Drawer drawable);

		byte GetChar();
	}
}