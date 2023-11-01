using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify();
        });
    }
    public void NotifyObservers(string _value)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(_value);
        });
    }
    public void NotifyObservers(int _value)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(_value);
        });
    }
    public void NotifyObservers(float _value)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(_value);
        });
    }

    public void NotifyObservers(ShoutWords _shoutWord)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(_shoutWord);
        });
    }
}
