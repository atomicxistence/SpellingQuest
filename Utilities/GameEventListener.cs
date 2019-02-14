using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterEventListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterEventListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
