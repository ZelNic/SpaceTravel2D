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
    public int countPartBigEnemy;

    [SerializeField] private int _countPowerUp;
    [SerializeField] private int _countCrystal;    
    private int _countEnemy;
    public float timeDethBigEnemy;

    public int CountEnemy
    {
        get { return _countEnemy = 0; }
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
        get { return _timeCreate = 0f; }
        set { _timeCreate = value; }
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
        
        timeDethBigEnemy = 0f;
       
    }

    private void Start()
    {
        CountBigEnemy = 0;
        CountBigEnemy = 0;
    }

    public void FixedUpdate()
    {
        if (_countPowerUp < 0)
        {
            _countPowerUp = 0;
        }

        if (_countCrystal < 0)
        {
            _countCrystal = 0;
        }

        if (CountEnemy < _maxCountEnemyOnScreen && TimeCreate < Time.timeSinceLevelLoad && _startCreateEnemys < Time.timeSinceLevelLoad)
        {
            SpawnEnemy();

        }
        if (CountBigEnemy < _maxCountBigEnemy && timeDethBigEnemy < Time.timeSinceLevelLoad && _startCreateBigEnemys < Time.timeSinceLevelLoad)
        {
            SpawnBigEnemy();
        }

    }

    public void CreatePowerUp(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && _countPowerUp < 1)
        {
            int indInArray = 59;
            indInArray = Random.Range(0, m_arrayPowerUP.Length);
            GameObject powerUpGO = Instantiate(m_arrayPowerUP[indInArray]);
            powerUpGO.transform.position = transform.position;
            _countPowerUp++;
        }
    }

    public void CreateCrystal(GameObject gameObject, Transform transform)
    {
        if (_countCrystal < 1)
        {
            _countCrystal++;
            GameObject powerUpGO = Instantiate(crystal);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
        }
    }

    public void CreateMedKit(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && _countPowerUp < 1)
        {
            GameObject powerUpGO = Instantiate(medKit);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
            _countPowerUp++;
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
        countPartBigEnemy = 0;
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
            case "PowerUp": _countPowerUp--; break;
            case "Crystal": _countCrystal--; break;
        }
        Destroy(gameObject);
    }
}
