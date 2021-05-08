using UnityEngine;

public class MonstersWorker : MonoBehaviour
{
    public Sprite[] monstersSprites;

    public Monster monsterPrefab;

    public void SpawnRandomMonster(Vector2 p_position)
    {
        Sprite __selectedSprite = monstersSprites[Random.Range(0, monstersSprites.Length)];

        Instantiate(monsterPrefab, p_position, Quaternion.identity).Initiate("", __selectedSprite);
    }
}