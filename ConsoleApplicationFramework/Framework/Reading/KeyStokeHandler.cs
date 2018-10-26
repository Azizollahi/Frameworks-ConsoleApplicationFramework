namespace ConsoleApplicationFramework.Framework.Reading {
	public interface KeyStokeHandler {
		bool CanHandle(KeyStroke keyStroke);
		void SetSuccessor(KeyStokeHandler successor);
		void Handle(KeyStroke keyStroke);
	}
}