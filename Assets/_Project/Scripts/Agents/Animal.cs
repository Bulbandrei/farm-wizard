using UnityEngine;

public class Animal : MonoBehaviour
{
    public string word;
    public SpriteRenderer spriteRenderer;

    public void Initiate(string p_word, Sprite p_sprite)
    {
        word = p_word;
        spriteRenderer.sprite = p_sprite;
    }
}
