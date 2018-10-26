using System.Collections.Generic;

namespace ConsoleApplicationFramework.Framework.Reading {
	public class KeyReader : Reader {
		private readonly List<Inputable> _subscribers;
		private readonly KeyStokeHandler _keyStokeHandler;
		
		public KeyReader() {
			_subscribers = new List<Inputable>();
			_keyStokeHandler = new KeyStrokeBackspaceSuccessor(_subscribers);
			_keyStokeHandler.SetSuccessor(new KeyStrokeBackspaceSuccessor(_subscribers));
		}

		public void AddSubscriber(Inputable subscriber) {
			lock (_subscribers) {
				_subscribers.Add(subscriber);
			}
		}

		public void RemoveSubscriber(Inputable subscriber) {
			lock (_subscribers) {
				_subscribers.Remove(subscriber);
			}
		}

		public void RemoveAllSubscribers() {
			lock (_subscribers) {
				_subscribers.Clear();
			}
		}

		public void Publish(KeyStroke newValue) {
			_keyStokeHandler.Handle(newValue);
		}
	}
}