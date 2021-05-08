using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static event Action onActionRequested;

    private void Update()
    {
        if (GameCEO.State != GameState.PLAY)
            return;
    }
}