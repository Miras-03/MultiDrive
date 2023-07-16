using System.Collections.Generic;

namespace Health
{
    public class PlayerHealth
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
                if (value >= healthOverValue && value != health)
                {
                    health = value;
                    NotifyObserversAboutChange();
                }
                else
                    NotifyObserversAboutDie();
            }
        }

        public void AddChangeObserver(IHealthObserver observer) => healthChangeObservers.Add(observer);
        public void RemoveChangeObserver(IHealthObserver observer) => healthChangeObservers.Remove(observer);

        public void AddDieObserver(IDieableObserver observer) => dieableObservers.Add(observer);
        public void RemoveDieObserver(IDieableObserver observer) => dieableObservers.Remove(observer);

        private void NotifyObserversAboutChange()
        {
            foreach (var observer in healthChangeObservers)
                observer.OnHealthChanged(health);
        }

        private void NotifyObserversAboutDie()
        {
            foreach (var observer in dieableObservers)
                observer.OnHealthOver();
        }
    }
}