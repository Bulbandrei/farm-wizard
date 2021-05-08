using UnityEngine;

public class Stage : MonoBehaviour
{
    public Transform topSpawn, botSpawn;

    public Vector2 monsterSpawnTime;
    public Vector2 animalSpawnTime;

    public float MonsterSpawnDelay { get { return Random.Range(monsterSpawnTime.x, monsterSpawnTime.y); } }
    public float AnimalSpawnDelay { get { return Random.Range(animalSpawnTime.x, animalSpawnTime.y); } }
    public Vector2 RandomSpawnPoint { get { return new Vector2(Random.Range(botSpawn.localPosition.x, topSpawn.localPosition.x), Random.Range(botSpawn.localPosition.y, topSpawn.localPosition.y)); } }
}
