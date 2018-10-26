using ConsoleApplicationFramework.Framework.Frames;

namespace ConsoleApplicationFramework.Components.GridComponent {
	public interface Grid : Frame{
		void Add(int verticalNum, int horizontalNum, Frame frame);
	}
}