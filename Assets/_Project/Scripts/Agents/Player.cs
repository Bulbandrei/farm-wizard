using UnityEngine;

public class Player : MonoBehaviour
{
    public static event System.Action onLifeUpdated;
    public static event System.Action onLifeReachsZero;

    private static int _Life;
    public static int Life
    {
        get { return _Life; }
        set
        {
            if (value >= 0)
            {
                _Life = value;

                if(_Life == 0) onLifeReachsZero?.Invoke();
                else onLifeUpdated?.Invoke();
            }
        }
    }

    private WordTyper _wordTyper;

    public void Initiate()
    {
        _wordTyper = GetComponent<WordTyper>();

        Life = GameConfig.PLAYER_MAX_HP;
    }

    private void Update()
    {
        if (GameCEO.State != GameState.PLAY)
            return;

        _wordTyper.CheckTyping();
    }

    public static void TakeDamage()
    {
        Life -= 1;
    }

    public void ResetPlayer()
    {
        Life = GameConfig.PLAYER_MAX_HP;
    }
}
