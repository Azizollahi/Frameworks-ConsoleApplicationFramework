using ConsoleApplicationFramework.Framework.Frames;

namespace ConsoleApplicationFramework.Components.ButtonComponent {
	public interface Button : Frame {
		void SetCaption(string name);
		string GetCaption();
	}
}