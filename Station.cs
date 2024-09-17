using System.Collections.Generic;

public class Station : ISubject
{
    private List<IObserver> _observers;
    public string UF { get; private set; }
    private float _temperature;

    // Construtor atualizado para aceitar apenas o UF
    public Station(string uf)
    {
        _observers = new List<IObserver>();
        UF = uf;
    }

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
        foreach (IObserver observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public void SetTemperature(float temperature)
    {
        _temperature = temperature;
        NotifyObservers();
    }

    // Método para obter a temperatura
    public float GetTemperature()
    {
        return _temperature;
    }
}
