using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage[] stages;

    public static float dayNightDuration = 20;
    public static bool isDay = true;
    public static Unit target;
    #region Stats
    public static List<string> wordsTyped = new List<string>(); // All words typed
    public static Dictionary<float, string> wpmList = new Dictionary<float, string>(); // Dictionary with timestamp and word typed, should contain only words typed in the last minute to calculate WPM
    public static int maxWpm;
    public static int avgWpm;
    public static int accuracy;
    #endregion

    public MonstersWorker monstersWorker;
    public AnimalsWorker animalsWorker;

    public static WordOnEnemy targetWord
    {
        get
        {
            return target.GetComponent<WordOnEnemy>();
        }
    }

    public event System.Action<float> onTimeUpdated;

    private float _changeDayNightTime;
    private float _monsterSpawnTime;
    private float _animalSpawnTime;
    private Stage _currentStage;
    private List<Unit> _unitsOnScreen = new List<Unit>();

    public void Initiate()
    {
        WordTyper.OnTargetDestroyed += SetNewTarget;
    }

    private void OnDisable()
    {
        WordTyper.OnTargetDestroyed -= SetNewTarget;
    }

    private void OnDestroy()
    {
        WordTyper.OnTargetDestroyed -= SetNewTarget;
    }

    public void Initalize()
    {
        
    }

    public void Update()
    {
        if (GameCEO.State != GameState.PLAY)
            return;

        if (Time.time >= _changeDayNightTime)
        {
            isDay = !isDay;
            _changeDayNightTime = Time.time + dayNightDuration;
        }
        else
        {
            onTimeUpdated?.Invoke(_changeDayNightTime - dayNightDuration);
        }

        if (isDay)
        {
            if (Time.time >= _animalSpawnTime)
            {
                _unitsOnScreen.Add(animalsWorker.SpawnRandomUnit(GetPointOutOfScreen()));

                _animalSpawnTime = Time.time + _currentStage.AnimalSpawnDelay;
            }
        }
        else
        {
            if (Time.time >= _monsterSpawnTime)
            {
                _unitsOnScreen.Add(monstersWorker.SpawnRandomUnit(GetPointOutOfScreen()));

                _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
            }
        }
    }

    public void InitalizeStage()
    {
        _currentStage = stages[0];

        _changeDayNightTime = Time.time + dayNightDuration;
        _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
        _animalSpawnTime = Time.time + _currentStage.AnimalSpawnDelay;

        target = animalsWorker.SpawnRandomUnit(GetPointOutOfScreen()); // First spawn to set initial target
        target.SetAsTarget();

        _unitsOnScreen.Add(target);
        wordsTyped = new List<string>();
        wpmList = new Dictionary<float, string>();
        maxWpm = 0;
        avgWpm = 0;
    }

    public Vector2 GetPointOutOfScreen()
    {
        bool _isY = Random.Range(0, 2) == 1;
        float __x = 0f, __y = 0f;

        if (_isY)
        {
            __x = Random.Range(0f, 1f);
            __y = Random.Range(0, 2) == 1 ? -.1f : 1.1f;
        }
        else
        {
            __x = Random.Range(0, 2) == 1 ? -.1f : 1.1f;
            __y = Random.Range(0f, 1f);
        }

        Vector3 v3Pos = new Vector3(__x, __y, 0);
        v3Pos = Camera.main.ViewportToWorldPoint(v3Pos);

        return v3Pos;
    }

    public void ResetStage()
    {
        isDay = true;
        
        foreach(Unit __unit in _unitsOnScreen)
        {
            Destroy(__unit.gameObject);
        }

        _unitsOnScreen.Clear();
    }

    public void SetNewTarget()
    {
        CalculateWpm();
        _unitsOnScreen.Remove(target);
        // TODO Avisar target pra ele se matar e spawnar efeitinhos
        Destroy(target.gameObject);
        target = getClosestEnemyToPlayer();
        target.SetAsTarget();
    }

    public Unit getClosestEnemyToPlayer()
    {
        return _unitsOnScreen.OrderBy(u => (u.transform.localPosition - Vector3.zero).sqrMagnitude).First();
    }

    private void CalculateWpm()
    {
        wordsTyped.Add(targetWord.Word);
        wpmList.Add(Time.time, targetWord.Word.Replace(" ", ""));
        var toRemove = wpmList.Where(r => r.Key < Time.time - 60).Select(pair => pair.Key).ToList();
        foreach (var key in toRemove)
            wpmList.Remove(key);

        string totalCharacters = "";
        wpmList.Values.ToList().ForEach(w => totalCharacters += w);
        avgWpm = totalCharacters.Count() / 5;
        if (avgWpm > maxWpm)
            maxWpm = avgWpm;
    }
}