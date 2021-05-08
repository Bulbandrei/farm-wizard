using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage[] stages;

    public MonstersWorker monstersWorker;

    private float _monsterSpawnTime;
    private Stage _currentStage;

    public void Initiate()
    {
        _currentStage = stages[0];

        _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
    }

    public void Update()
    {
        if(Time.time == _monsterSpawnTime)
        {
            Debug.Log("Spawn Monster");

            _monsterSpawnTime = Time.time + _currentStage.MonsterSpawnDelay;
        }
    }
}
