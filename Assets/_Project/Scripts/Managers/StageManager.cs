using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage[] stages;

    public float dayNightDuration;

    public MonstersWorker monstersWorker;
    public AnimalsWorker animalsWorker;

    private bool _isDay = true;
    private float _changeDayNightTime;
    private float _monsterSpawnTime;
    private float _animalSpawnTime;
    private Stage _currentStage;

    public void Initiate()
    {
        _currentStage = stages[0];

        _changeDayNightTime = Time.time + dayNightDuration;
        _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
        _animalSpawnTime = Time.time + _currentStage.AnimalSpawnDelay;
    }

    public void Update()
    {
        if (Time.time >= _changeDayNightTime)
        {
            _isDay = !_isDay;
            _changeDayNightTime = Time.time + dayNightDuration;
        }

        if (_isDay)
        {
            if (Time.time >= _animalSpawnTime)
            {
                animalsWorker.SpawnRandomUnit(GetPointOutOfScreen());

                _animalSpawnTime = Time.time + _currentStage.AnimalSpawnDelay;
            }
        }
        else
        {
            if (Time.time >= _monsterSpawnTime)
            {
                monstersWorker.SpawnRandomUnit(GetPointOutOfScreen());

                _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
            }
        }
    }

    public Vector2 GetPointOutOfScreen()
    {
        bool _isY = Random.Range(0, 2) == 1;
        float __x = 0f, __y = 0f;

        if(_isY)
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
}