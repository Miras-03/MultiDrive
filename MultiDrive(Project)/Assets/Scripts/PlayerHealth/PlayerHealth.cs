using System.Collections.Generic;

namespace Health
{
    public sealed class PlayerHealth
    {
        private int health;
        private List<IHealthObserver> healthChangeObservers = new List<IHealthObserver>();
        private List<IDieableObserver> dieableObservers = new List<IDieableObserver>();

        private const int healthOverValue = 0;

        public int Health
        {
            get => health;
            set
            {
                if (value >= healthOverValue)
                {
                    health = value;
                    NotifyObserversAboutChange();
                }
                else
                    NotifyObserversAboutDie();
            }
        }

        public void AddChangeObserver(IHealthObserver observer) => healthChangeObservers.Add(observer);

        public void AddDieableObserver(IDieableObserver observer) => dieableObservers.Add(observer);

        private void NotifyObserversAboutChange()
        {
            foreach (IHealthObserver observer in healthChangeObservers)
                observer.OnHealthChanged(health);
        }

        private void NotifyObserversAboutDie()
        {
            foreach (IDieableObserver observer in dieableObservers)
                observer.OnHealthOver();
        }
    }
}