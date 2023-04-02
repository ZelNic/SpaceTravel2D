using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public static GameObjectManager GOM { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject[] m_enemy;
    [SerializeField] private GameObject[] m_bigEnemy;
    [SerializeField] private GameObject[] m_arrayPowerUP;
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject medKit;    
    [SerializeField] private BoundsCheck _boundsCheck;

    [Header("Set in Inspector")]
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float _startCreateEnemys;
    [SerializeField] private float _startCreateBigEnemys;
    [SerializeField] private float _chanceCreatePowerUp;
    private GameObject _enemySpawner;

    private float _timeCreate;
    [SerializeField] private float _plusTimeForEnemy;
    public float plusTimeForBigEnemy;

    private int _countBigEnemy;
    private int _countPowerUp;
    private int _countCrystal;
    private int _countMedKit;
    private int _countWeapon;
    private int _countEnemy;
    private float _timeDethBigEnemy;
    private int _countPartBigEnemy;
    private int _countAsteroid;
    private float _timeCreateAsteroid;
    private int _countWeaponsPlayer;


    #region get set

    public int CountWeaponsPlayer
    {
        get { return _countWeaponsPlayer; }
        set { _countWeaponsPlayer = value; }
    }



    public int CountPartBigEnemy
    {
        get { return _countPartBigEnemy; }
        set { _countPartBigEnemy = value; }
    }
    public int CountCrystal
    {
        get { return _countCrystal; }
        set
        {
            _countCrystal = value;
            if (_countCrystal < 0)
            {
                _countCrystal = 0;
            }
        }
    }
    public int CountPowerUp
    {
        get { return _countPowerUp; }
        set
        {
            _countPowerUp = value;
            if (_countPowerUp < 0)
            {
                _countPowerUp = 0;
            }
        }
    }
    public int CountMedKit
    {
        get { return _countMedKit; }
        set
        {
            _countMedKit = value;
            if (_countMedKit < 0)
            {
                _countMedKit = 0;
            }
        }
    }
    public int CountWeapon
    {
        get { return _countWeapon; }
        set
        {
            _countWeapon = value;
            if (_countWeapon < 0)
            {
                _countWeapon = 0;
            }
        }
    }
    public int CountEnemy
    {
        get { return _countEnemy; }
        set
        {
            _countEnemy = value;
            if (_countEnemy < 0)
            {
                _countEnemy = 0;
            }
        }
    }
    public int CountBigEnemy
    {
        get { return _countBigEnemy; }
        set { _countBigEnemy = value; }
    }
    public float TimeCreate
    {
        get { return _timeCreate; }
        set { _timeCreate = value; }
    }
    public float TimeDethBigEnemy
    {
        get { return _timeDethBigEnemy; }
        set { _timeDethBigEnemy = value; }
    }
    public float TimeCreateAsteroid
    {
        get { return _timeCreateAsteroid; }
        set 
        { 
            _timeCreateAsteroid = value;
        }
    }
    public int CountAsteroid
    {
        get { return _countAsteroid; }
        set 
        {
            _countAsteroid = value; 
            if( _countAsteroid < 0)
            { _countAsteroid = 0;}
        }
    }


    #endregion


    private void Awake()
    {
        GOM = this;
        _boundsCheck = GetComponent<BoundsCheck>();
    }

    public void FixedUpdate()
    {
        SpawnEnemy();
        SpawnAsteroid();
        SpawnBigEnemy();
    }

    public void CreatePowerUp(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && CountPowerUp < 1)
        {
            GameObject powerUpGO = Instantiate(m_arrayPowerUP[1]);
            powerUpGO.transform.position = transform.position;
            CountPowerUp++;
        }
        return;
    }

    public void CreateWeapon(GameObject gameObject, Transform transform)
    {        
        if (CountWeapon <= 1)
        {
            GameObject powerUpGO = Instantiate(m_arrayPowerUP[2]);
            powerUpGO.transform.position = transform.position;
            CountWeapon++;
        }
        return;
    }

    public void CreateCrystal(GameObject gameObject, Transform transform)
    {
        if (CountCrystal < 1)
        {
            CountCrystal++;
            GameObject powerUpGO = Instantiate(crystal);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
        }
        return;
    }

    public void CreateMedKit(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && CountPowerUp < 1)
        {
            GameObject powerUpGO = Instantiate(medKit);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
            CountMedKit++;
        }
        return;
    }

    public void SpawnEnemy()
    {
        if (CountEnemy < _maxCountEnemyOnScreen && TimeCreate < Time.timeSinceLevelLoad && _startCreateEnemys < Time.timeSinceLevelLoad)
        {
            int indInArray = Random.Range(1, m_enemy.Length);
            _enemySpawner = Instantiate(m_enemy[indInArray]);
            Transform posEnemy = _enemySpawner.GetComponent<Transform>();
            posEnemy.transform.position = new Vector3(Random.Range(-_boundsCheck.camWidth, _boundsCheck.camWidth), Random.Range(25, 45), 0);
            TimeCreate = Time.timeSinceLevelLoad + _plusTimeForEnemy;
            CountEnemy++;
        }
        return;
    }

    public void SpawnAsteroid()
    {
        if (CountAsteroid < 2 && TimeCreateAsteroid < Time.timeSinceLevelLoad)
        {
            _enemySpawner = Instantiate(m_enemy[0]);
            Transform posEnemy = _enemySpawner.GetComponent<Transform>();
            posEnemy.transform.position = new Vector3(Random.Range(-_boundsCheck.camWidth, _boundsCheck.camWidth), Random.Range(25, 45), 0);
            TimeCreateAsteroid = Time.timeSinceLevelLoad + 5f;
            CountAsteroid++;
        }
        return;
    }


    public void SpawnBigEnemy()
    {
        if (CountBigEnemy < _maxCountBigEnemy && TimeDethBigEnemy < Time.timeSinceLevelLoad && _startCreateBigEnemys < Time.timeSinceLevelLoad)
        {
            _countPartBigEnemy = 0;
            CountBigEnemy++;
            int indInArray = 59;
            indInArray = Random.Range(0, m_bigEnemy.Length);
            _enemySpawner = Instantiate(m_bigEnemy[indInArray]);
            Transform posEnemy = _enemySpawner.GetComponent<Transform>();
            posEnemy.transform.position = new Vector3(0, 25, 0);            
        }
        return;
    }

    public void DestroyGO(GameObject gameObject)
    {
        Destroy(gameObject);
        switch (gameObject.tag)
        {
            case "Enemy": CountEnemy--; break;
            case "BigEnemy": CountBigEnemy--; CountWeapon++; break;
            case "PartBigEnemy": CountPartBigEnemy++; break;
            case "PowerUp": CountPowerUp--; break;
            case "Crystal": CountCrystal--; break;
            case "HP": CountMedKit--; break;
            case "Weapon": CountWeapon--; break;
            case "Asteroid": CountAsteroid--; break;
        }        
    }
    
}
