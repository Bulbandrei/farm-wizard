using UnityEngine;

public class Player : MonoBehaviour
{
    public static event System.Action onLifeReachsZero;

    public static Player Instance;

    public int life = GameConfig.PLAYER_MAX_HP;

    public void Initiate()
    {
        Instance = this;
    }

    public void TakeDamage()
    {
        if (life <= 0)
            return;

        life -= 1;

        if(life <= 0)
        {
            onLifeReachsZero?.Invoke();
        }
    }

    public void ResetPlayer()
    {
        life = GameConfig.PLAYER_MAX_HP;
    }
}
