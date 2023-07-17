namespace Health
{
    public interface IHealthObserver
    {
        void OnHealthChanged(int newHealth); 
    }
}