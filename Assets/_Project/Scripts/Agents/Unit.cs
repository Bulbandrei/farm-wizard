using UnityEngine;

public class Unit : MonoBehaviour
{
    public string word;
    public SpriteRenderer spriteRenderer;

    public void Initiate(string p_word, Sprite p_sprite)
    {
        word = p_word;
        spriteRenderer.sprite = p_sprite;
    }

    private void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, Vector3.zero, 10f * Time.deltaTime);
    }


}
