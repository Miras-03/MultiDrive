using System.Collections.Generic;

public sealed class FinishTrigger
{
    private List<IFinishObserver> observers = new List<IFinishObserver>();

    public void AddObservers(IFinishObserver observer) => observers.Add(observer);

    public void NotifyObserversAboutFinish()
    {
        foreach (IFinishObserver observer in observers)
            observer.Execute();
    }
}