using UnityEngine;

public class UnitsWorker : MonoBehaviour
{
    public Sprite[] sprites;

    public Unit unitPrefab;

    public Unit SpawnRandomUnit(Vector2 p_position)
    {
        Sprite __selectedSprite = sprites[Random.Range(0, sprites.Length)];

        var t = Instantiate(unitPrefab, p_position, Quaternion.identity);
        t.Initiate(__selectedSprite);
        return t;
    }
}
