namespace LibraryManagementSystemBackend.Core.Entities
{
    using LibraryManagementSystemBackend.Observer;
    using System.Collections.Generic;
        public class Observable : IObservable
    {
            private List<IObserver> observers = new List<IObserver>();

            public void RegisterObserver(IObserver observer)
            {
                if (!observers.Contains(observer))
                {
                    observers.Add(observer);
                }
            }

            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }

            public void NotifyObservers(string message)
            {
                foreach (var observer in observers)
                {
                    observer.Update(message);
                }
            }
        }
}

