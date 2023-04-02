using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _goScore;
    [SerializeField] private Slider _slider;

    public GameObject gm;
    private GameManager _gm;

    public GameObject projectileHero;
    public GameObject pointCreateProjectile;
    public GameObject pointCPLeft;
    public GameObject pointCPRight;
    private int _countWepons;


    private Rigidbody2D _rb;
    private float _timeCreate;
    private Score _score;
    private HealthBar _healthBar;
    private int _currentHealth;
    private TakingDamage _takingDamage;

    private bool activeSpeedModForFire = false;
    private float timerForModForFire;
    [SerializeField] private float timeActiveFireMod;
    [SerializeField] private float _rateOfFire;
    private float defultRateOfFire;


    private Vector2 touchStartPosition;
    private float movementSpeed = 2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _score = _goScore.GetComponent<Score>();
        _healthBar = _slider.GetComponent<HealthBar>();
        _takingDamage = GetComponent<TakingDamage>();
        _gm = gm.GetComponent<GameManager>();
        _currentHealth = _maxHealth;
        _rb.position = Vector2.zero;
        defultRateOfFire = _rateOfFire;
        _countWepons = 0;
    }

    private void FixedUpdate()
    {
        UpdateHealthBar();
        MovePlayer();
        CreateProjectileHero();
        BonusSpeedFire();
        IGetUWeapons();
    }

    private void IGetUWeapons()
    {
        if (GameObjectManager.GOM.CountWeapon == 1)
        {
            pointCPLeft.SetActive(true);
        }
        if (GameObjectManager.GOM.CountWeapon == 2)
        {
            pointCPRight.SetActive(true);
        }

    }


    public int CountWepons
    {
        get { return _countWepons; }
        set
        {
            _countWepons = value;
            if (_countWepons < 0)
            {
                _countWepons = 0;
            }
            if (_countWepons > 2)
            {
                _countWepons = 2;
            }

        }
    }


    public int Health
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                _gm.Restart();
            }
        }
    }
    public float RateOfFire
    {
        get { return _rateOfFire; }
        set
        {
            _rateOfFire = value;
        }
    }


    public void BonusSpeedFire()
    {
        if (Time.time > timerForModForFire)
        {

            activeSpeedModForFire = false;
        }

        if (activeSpeedModForFire == false)
        {
            _rateOfFire = defultRateOfFire;
        }
        if (activeSpeedModForFire == true)
        {
            RateOfFire = 0.2f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        switch (other.tag)
        {
            case "Enemy":
                Health--;
                _takingDamage.ChangeColorTakingDamage();
                GameObjectManager.GOM.DestroyGO(other);
                _score.UpdateScore(10);
                break;
            case "PartBigEnemy":
                Health--;
                _takingDamage.ChangeColorTakingDamage();
                PartsBigEnemy _pbe = other.GetComponent<PartsBigEnemy>();
                _pbe.DestroyPart();
                _score.UpdateScore(10);
                break;
            case "ProjectileEnemy":
                Health--;
                _takingDamage.ChangeColorTakingDamage();
                Destroy(other);
                break;
            case "HP":
                Health++;
                GameObjectManager.GOM.DestroyGO(other);
                break;
            case "PowerUp":
                timerForModForFire = Time.time + timeActiveFireMod;
                activeSpeedModForFire = true;
                GameObjectManager.GOM.DestroyGO(other);
                break;
            case "Crystal":
                GameObjectManager.GOM.DestroyGO(other);
                _score.UpdateCrystal(10);
                break;
            case "Asteroid":
                Health--;
                _takingDamage.ChangeColorTakingDamage();
                GameObjectManager.GOM.DestroyGO(other);
                _score.UpdateScore(10);
                break;
        }
    }


    private void MovePlayer()
    {
        Vector3 pos2DMouse = Input.mousePosition;
        pos2DMouse.z = -Camera.main.transform.position.z;
        Vector3 pos3DMouse = Camera.main.ScreenToWorldPoint(pos2DMouse);

        float xAxis = pos3DMouse.x;
        float yAxis = pos3DMouse.y;
        Vector3 currentPos = transform.position;
        Vector3 targetPos = new Vector3(xAxis, yAxis + 3f, currentPos.z);
        float movingTime = 0.5f;
        transform.position = Vector3.Lerp(currentPos, targetPos, movingTime);
    }

    private void UpdateHealthBar()
    {
        _healthBar.UpdateHealthBar(_maxHealth, Health);
    }

    private void CreateProjectileHero()
    {
        if (_timeCreate < Time.time)
        {
            _timeCreate = Time.time + RateOfFire;
            GameObject proje = Instantiate(projectileHero, pointCreateProjectile.transform);
            proje.transform.position = pointCreateProjectile.transform.position;

            GameObject proje1 = Instantiate(projectileHero, pointCPLeft.transform);
            proje1.transform.position = pointCPLeft.transform.position;

            GameObject proje2 = Instantiate(projectileHero, pointCPRight.transform);
            proje2.transform.position = pointCPRight.transform.position;
        }
    }


}
