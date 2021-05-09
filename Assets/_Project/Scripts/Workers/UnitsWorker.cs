using UnityEngine;

public class UnitsWorker : MonoBehaviour
{
    public Sprite[] sprites;

    public Unit unitPrefab;

    public void SpawnRandomUnit(Vector2 p_position)
    {
        Sprite __selectedSprite = sprites[Random.Range(0, sprites.Length)];

        Instantiate(unitPrefab, p_position, Quaternion.identity).Initiate("", __selectedSprite);
    }
}
