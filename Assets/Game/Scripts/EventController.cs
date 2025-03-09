using System;
using UnityEngine;

public static class EventController
{
    public static event Action OnVictory;

    public static event Action OnDefeat;

    public static void InvokeVictory()
    {
        Debug.Log("Victory");

        OnVictory?.Invoke();
    }

    public static void InvokeDefeat() 
    {
        Debug.Log("Defeat");

        OnDefeat?.Invoke();
    }
}
