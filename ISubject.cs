using System;
using System.Collections.Generic;

//Interface para sujeitos
public interface ISubject
{
  void AddObserver(IObserver observer);
  void RemoveObserver(IObserver observer);
  void NotifyObservers();
}