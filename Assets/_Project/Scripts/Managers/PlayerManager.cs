using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public event Action onPlayerLifeReachsZero;

    public Player player;

    public void Initate()
    {
        Player.onLifeReachsZero += Player_onLifeReachsZero;

        player.Initiate();
    }

    private void OnDisable()
    {
        Player.onLifeReachsZero -= Player_onLifeReachsZero;
    }

    private void OnDestroy()
    {
        Player.onLifeReachsZero -= Player_onLifeReachsZero;
    }

    private void Player_onLifeReachsZero()
    {
        onPlayerLifeReachsZero?.Invoke();
    }

    public void ResetPlayer()
    {
        player.ResetPlayer();
    }
}
