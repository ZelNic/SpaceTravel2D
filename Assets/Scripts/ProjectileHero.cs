using UnityEngine;

public class ProjectileHero : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private BoundsCheck _boundsCheck;
    [SerializeField] private GameObject goScore;
    public Score _score;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boundsCheck = GetComponent<BoundsCheck>();       
        
    }

    public void FixedUpdate()
    {
        _score = GetComponent<Score>();
        GiveForceProjectile();
        if (_boundsCheck != null && _boundsCheck.offUp)
        {
            Destroy(gameObject);
        }
    }

    private void GiveForceProjectile()
    {
        _rb.velocity += new Vector2(0, Mathf.Abs(speed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemy.health -= 1;
            if (enemy.health < 0)
            {                 
                _score.UpdateScore(5);
                print(_score.score);
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }


}
