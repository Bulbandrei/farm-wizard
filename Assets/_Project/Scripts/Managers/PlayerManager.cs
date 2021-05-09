using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public event Action onPlayerLifeUpdated;
    public event Action onPlayerLifeReachsZero;

    public Player player;

    public void Initate()
    {
        Player.onLifeUpdated += Player_onLifeUpdated;
        Player.onLifeReachsZero += Player_onLifeReachsZero;

        player.Initiate();
    }

    private void OnDisable()
    {
        Player.onLifeUpdated -= Player_onLifeUpdated;
        Player.onLifeReachsZero -= Player_onLifeReachsZero;
    }

    private void OnDestroy()
    {
        Player.onLifeUpdated -= Player_onLifeUpdated;
        Player.onLifeReachsZero -= Player_onLifeReachsZero;
    }

    private void Player_onLifeUpdated()
    {
        onPlayerLifeUpdated?.Invoke();
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
