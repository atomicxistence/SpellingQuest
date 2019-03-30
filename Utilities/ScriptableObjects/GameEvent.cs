using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Game Event", menuName = "Utility/Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterEventListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterEventListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
