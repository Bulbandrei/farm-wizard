using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage[] stages;

    public float dayNightDuration;

    public MonstersWorker monstersWorker;
    public AnimalsWorker animalsWorker;

    private bool _isDay;
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
        }

        if (_isDay)
        {
            if (Time.time >= _animalSpawnTime)
            {
                animalsWorker.SpawnRandomMonster(GetPointOnUnitCircleCircumference());

                _animalSpawnTime = Time.time + _currentStage.AnimalSpawnDelay;
            }
        }
        else
        {
            if (Time.time >= _monsterSpawnTime)
            {
                monstersWorker.SpawnRandomMonster(_currentStage.RandomSpawnPoint);

                _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
            }
        }
    }

    public Vector2 GetPointOnUnitCircleCircumference()
    {
        return Random.insideUnitCircle.normalized * 10f;
    }
}