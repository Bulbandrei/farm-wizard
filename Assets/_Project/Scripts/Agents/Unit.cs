using UnityEngine;

public class Unit : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed = 2.0f;

    [SerializeField] ParticleSystem targetParticles;

    public void Initiate(Sprite p_sprite)
    {
        spriteRenderer.sprite = p_sprite;
    }

    private void Update()
    {
        if((transform.localPosition * -1).sqrMagnitude >= 2f)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, Vector3.zero, 10f * Time.deltaTime);
        }
    }

    public void SetAsTarget()
    {
        targetParticles.gameObject.SetActive(true);
    }
}
