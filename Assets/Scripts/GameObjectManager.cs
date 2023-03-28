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

    [Header("Set in Inspector")]
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float _startCreateEnemys;
    [SerializeField] private float _startCreateBigEnemys;
    [SerializeField] private float _chanceCreatePowerUp;
    private GameObject _enemySpawner;

    private float _timeCreate;
    [SerializeField] private float _plusTimeForEnemy;
    [SerializeField] private float _plusTimeForBigEnemy;

    private int _countBigEnemy;
    private int _countPowerUp;
    private int _countCrystal;
    private int _countMedKit;
    private int _countWeapon;
    private int _countEnemy;
    private float _timeDethBigEnemy;
    private int _countPartBigEnemy;



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
            if (_countCrystal <= 0)
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
            if (_countPowerUp <= 0)
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
            if (_countMedKit <= 0)
            {
                _countMedKit = 0;
            }
        }
    }

    public int CountWeapon
    {
        get { return _countWeapon; }
        set 
        { _countWeapon = value; 
            if (_countWeapon <= 0)
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

    private void Awake()
    {
        if (GOM == null)
        {
            GOM = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this.gameObject);



    }

    public void FixedUpdate()
    {   
        if (CountEnemy < _maxCountEnemyOnScreen && TimeCreate < Time.timeSinceLevelLoad && _startCreateEnemys < Time.timeSinceLevelLoad)
        {
            SpawnEnemy();

        }
        if (CountBigEnemy < _maxCountBigEnemy && TimeDethBigEnemy < Time.timeSinceLevelLoad && _startCreateBigEnemys < Time.timeSinceLevelLoad)
        {
            SpawnBigEnemy();
        }
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
    }

    public void CreateWeapon(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && CountWeapon < 1)
        {
            GameObject powerUpGO = Instantiate(m_arrayPowerUP[2]);
            powerUpGO.transform.position = transform.position;
            CountWeapon++;
        }
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
    }

    public void SpawnEnemy()
    {

        int indInArray = Random.Range(0, m_enemy.Length);
        _enemySpawner = Instantiate(m_enemy[indInArray]);
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 45), 0);

        TimeCreate = Time.timeSinceLevelLoad + _plusTimeForEnemy;
        CountEnemy++;
    }

    public void SpawnBigEnemy()
    {
        int indInArray = 59;
        indInArray = Random.Range(0, m_bigEnemy.Length);
        _enemySpawner = Instantiate(m_bigEnemy[indInArray]);
        CountBigEnemy++;
        _countPartBigEnemy = 0;
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(0, 25, 0);
        return;
    }

    public void DestroyGO(GameObject gameObject)
    {
        switch (gameObject.tag)
        {
            case "Enemy": CountEnemy--; break;
            case "BigEnemy": CountBigEnemy--; break;
            case "PowerUp": CountPowerUp--; break;
            case "Crystal": CountCrystal--; break;
            case "HP": CountMedKit--; break;
            case "Weapon": CountWeapon--; break;
        }
        Destroy(gameObject);
    }
}
