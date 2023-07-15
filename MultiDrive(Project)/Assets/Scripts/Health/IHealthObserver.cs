namespace Health
{
    public interface IHealthObserver
    {
        void SetMaxValue(int newHealth);
        void OnHealthChanged(int newHealth);
    }
}