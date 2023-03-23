using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    public GameObject gameObjectManager;
    public GameObject projectileHero;
    public GameObject pointCreateProjectile;
    public float rateOfFire;
    private Rigidbody2D _rb;
    private float _timeCreate;
    private GameObject _goScore;
    private Score _score;
    private Slider _slider;
    private HealthBar _healthBar;
    private TakingDamage _takingDamage;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.position = Vector2.zero;
        _score = _goScore.GetComponent<Score>();
        _currentHealth = _maxHealth;
        _healthBar = _slider.GetComponent<HealthBar>();
        _takingDamage = GetComponent<TakingDamage>();
    }

    public int health
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy")
        {
            health--;
            _takingDamage.ChangeColorTakingDamage();
            Enemy _enemy = other.GetComponent<Enemy>();
            _score.UpdateScore(10);
            _enemy.DestroyEnemy();

        }
        if (other.tag == "PartBigEnemy")
        {
            health--;
            _takingDamage.ChangeColorTakingDamage();
            PartsBigEnemy _pbe = other.GetComponent<PartsBigEnemy>();
            _score.UpdateScore(10);
            _pbe.DestroyPart();
        }
    }

    private void FixedUpdate()
    {
        GetDamage();
        UpdateHealthBar();
        MovePlayer();
        if (_timeCreate < Time.time)
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
            GameManager.Restart();
        }
    }
    private void UpdateHealthBar()
    {
        _healthBar.UpdateHealthBar(_maxHealth, health);
    }

    private void CreateProjectileHero()
    {
        _timeCreate = Time.time + rateOfFire;
        GameObject proje = Instantiate(projectileHero, pointCreateProjectile.transform);
        proje.transform.position = pointCreateProjectile.transform.position;

    }

}
