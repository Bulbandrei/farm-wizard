using UnityEngine;

public class Stage : MonoBehaviour
{
    public Vector2 monsterSpawnTime;
    public Vector2 animalSpawnTime;

    public float MonsterSpawnDelay { get { return Random.Range(monsterSpawnTime.x, monsterSpawnTime.y); } }
    public float AnimalSpawnDelay { get { return Random.Range(animalSpawnTime.x, animalSpawnTime.y); } }
}
