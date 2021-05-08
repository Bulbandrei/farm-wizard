using UnityEngine;

public class AnimalsWorker : MonoBehaviour
{
    public Sprite[] animalsSprites;

    public Animal animalsPrefab;

    public void SpawnRandomMonster(Vector2 p_position)
    {
        Sprite __selectedSprite = animalsSprites[Random.Range(0, animalsSprites.Length)];

        Instantiate(animalsPrefab, p_position, Quaternion.identity).Initiate("", __selectedSprite);
    }
}
