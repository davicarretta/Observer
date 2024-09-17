using System;

public class Monitor : IObserver
{
  public void Update(float temperature)
  {
    Console.WriteLine($"Temperatura atual da estação: {temperature}ºC");
  }
}