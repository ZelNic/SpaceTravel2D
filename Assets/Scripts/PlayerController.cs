using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float health;
    private Rigidbody2D _rb;
    public GameObject gOM;
    private GameObjectManager _gom;
    public GameObject projectileHero;
    public GameObject pointCreateProjectile;
    public float timeCreate;
    public float rateOfFire;
    [SerializeField] private GameObject goScore;
    private Score _score;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.position = Vector2.zero;        
        _score = goScore.GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy")
        {
            health--;
            Enemy _enemy = other.GetComponent<Enemy>();                    
            _score.UpdateScore(10);
            _enemy.DestroyEnemy();

        }
        if (other.tag == "PartBigEnemy")
        {
            health--;
            PartsBigEnemy _pbe = other.GetComponent<PartsBigEnemy>();
            _score.UpdateScore(10);
            _pbe.DestroyPart();
        }
    }
    
    private void FixedUpdate()
    {
        GetDamage();
        MovePlayer();
        if (timeCreate < Time.time)
        {
            CreateProjectileHero();
        }
    }

    private void MovePlayer()
    {
        Vector3 pos2DMouse = Input.mousePosition;
        pos2DMouse.z = -Camera.main.transform.position.z;
        Vector3 pos3DMouse = Camera.main.ScreenToWorldPoint(pos2DMouse);

        float xAxis = pos3DMouse.x;
        float yAxis = pos3DMouse.y;

        Vector3 pos = transform.position;
        pos.x = xAxis;
        pos.y = yAxis + 4f;
        transform.position = pos;
    }

    public void GetDamage()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void CreateProjectileHero()
    {
        timeCreate = Time.time + rateOfFire;
        GameObject proje = Instantiate(projectileHero, pointCreateProjectile.transform);
        proje.transform.position = pointCreateProjectile.transform.position;

    }

}
