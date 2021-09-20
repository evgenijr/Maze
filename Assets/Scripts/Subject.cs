using System.Collections.Generic;
public static class Subject
{
    private static List<Observer> observers = new List<Observer>();
    public static void Notify(Notifications notification)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify(notification);
        }
    }
    public static void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }
    public static void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }
}