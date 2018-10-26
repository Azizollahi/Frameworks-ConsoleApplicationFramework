namespace ConsoleApplicationFramework.Framework.Reading {
	public interface Reader {
		void Publish(KeyStroke newValue);
		void RemoveAllSubscribers();
		void RemoveSubscriber(Inputable subscriber);
		void AddSubscriber(Inputable subscriber);
	}
}