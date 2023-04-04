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

    public void Start()
    {
        _score = goScore.GetComponent<Score>();
    }

    public void FixedUpdate()
    {
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


        switch (other.tag)
        {
            case "EnemyWithWeapon":

                PartsBigEnemy _pbeWithWeapon = other.GetComponent<PartsBigEnemy>();
                _pbeWithWeapon.health -= 1;
                Destroy(this.gameObject);
                break;
            case "Enemy":
                Enemy _enemy = other.GetComponent<Enemy>();
                _enemy.health -= 1;
                Destroy(this.gameObject);
                break;
            case "PartBigEnemy":
                PartsBigEnemy _pbe = other.GetComponent<PartsBigEnemy>();
                _pbe.health -= 1;
                Destroy(this.gameObject);
                break;
            case "Asteroid":
                Enemy _astro = other.GetComponent<Enemy>();
                _astro.health -= 1;
                Destroy(this.gameObject);
                break;
        }     

    }
}



