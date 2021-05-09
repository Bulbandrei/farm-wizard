using UnityEngine;

public class Unit : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed = 2.0f;
    public float attackSpeed = 1f;

    [SerializeField] ParticleSystem targetParticles;

    private bool _attack = false;
    private float _timeToAttack = 0f;

    public void Initiate(Sprite p_sprite)
    {
        spriteRenderer.sprite = p_sprite;
    }

    private void Update()
    {
        if (GameCEO.State != GameState.PLAY)
            return;

        if (_attack)
        {
            if(Time.time >= _timeToAttack)
            {
                Player.TakeDamage();

                _timeToAttack = Time.time + attackSpeed;
            }
        }
        else
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);

            _attack = (transform.localPosition * -1).sqrMagnitude < 5f;
            _timeToAttack = Time.time + attackSpeed;
        }
    }

    public void SetAsTarget()
    {
        targetParticles.gameObject.SetActive(true);
    }
}
