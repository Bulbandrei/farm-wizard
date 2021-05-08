using UnityEngine;

public class MonstersWorker : MonoBehaviour
{
    public Sprite[] monstersSprites;

    public Monster monsterPrefab;

    public void SpawnRandomMonster(string p_word, Vector2 p_position)
    {
        Sprite __selectedSprite = monstersSprites[Random.Range(0, monstersSprites.Length)];

        Instantiate(monsterPrefab, p_position, Quaternion.identity).Initiate(p_word, __selectedSprite);
    }
}