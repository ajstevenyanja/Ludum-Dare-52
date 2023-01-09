using UnityEngine;
using UnityEngine.Events;

// simple script to invoke an event with a delay when a scene loads

public class InvokeEventAfterSeconds : MonoBehaviour
{
    [SerializeField] UnityEvent EventToInvoke;
    [SerializeField] float seconds = 5f;

    private void Start()
    {
        Invoke(nameof(InvokeEvent), seconds);
    }

    void InvokeEvent()
    {
        EventToInvoke.Invoke();
    }
}
