using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    static public GameObjectManager GOM;

    [Header("Prefabs")]
    public GameObject[] enemy;
    public GameObject[] bigEnemy;
    public GameObject[] arrayPowerUP;
    public GameObject crystal;
    public GameObject medKit;

    [Header("Set in Inspector")]
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float _startCreateEnemys;
    [SerializeField] private float _startCreateBigEnemys;
    [SerializeField] private float _chanceCreatePowerUp;
    private GameObject _enemySpawner;

    private float _timeCreate;
    public float plusTimeForEnemy;
    public float plusTimeForBigEnemy;
       
    public int countBigEnemy;
    public int countPowerUp;
    public int countCrystal;
    public float timeDethBigEnemy;


    
    public int _countEnemy;

    public void Update()
    {
        
    }

    public int countEnemy
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


    private void Awake()
    {
        GOM = this;
        timeDethBigEnemy = 0;
    }


    public void FixedUpdate()
    {

        if (countPowerUp < 0)
        {
            countPowerUp = 0;
        }

        if (countCrystal < 0)
        {
            countCrystal = 0;
        }

        if (countEnemy < _maxCountEnemyOnScreen && _timeCreate < Time.time && _startCreateEnemys < Time.time)
        {
            SpawnEnemy();
        }
        if (countBigEnemy < _maxCountBigEnemy && _startCreateBigEnemys < Time.time && timeDethBigEnemy < Time.time)
        {
            SpawnBigEnemy();
        }
    }

    public void CreatePowerUp(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && countPowerUp < 1)
        {
            int indInArray = 59;
            indInArray = Random.Range(0, arrayPowerUP.Length);
            GameObject powerUpGO = Instantiate(arrayPowerUP[indInArray]);
            powerUpGO.transform.position = transform.position;
            countPowerUp++;
            
        }

    }    

    public void CreateCrystal(GameObject gameObject, Transform transform)
    {
        if (countCrystal < 1)
        {
            countCrystal++;
            GameObject powerUpGO = Instantiate(crystal);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);            
        }        
    }
    
    public void CreateMedKit(GameObject gameObject, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && countPowerUp < 1)
        {
            GameObject powerUpGO = Instantiate(medKit);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
            countPowerUp++;            
        }
    }

    public void SpawnEnemy()
    {
       
        int indInArray = Random.Range(0, enemy.Length);
        _enemySpawner = Instantiate(enemy[indInArray]);
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 45), 0);
        
        _timeCreate = Time.time + plusTimeForEnemy;
        countEnemy++;       
    }

    public void SpawnBigEnemy()
    {
        int indInArray = 59;
        indInArray = Random.Range(0, bigEnemy.Length);
        _enemySpawner = Instantiate(bigEnemy[indInArray]);
        countBigEnemy++;
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(0, 25, 0);
        return;
    }

    public void DestroyGO(GameObject gameObject)
    {
        Destroy(gameObject);
        switch (gameObject.tag)
        {
            case "Enemy": countEnemy--; break;
            case "BigEnemy": countBigEnemy--; break;
            case "PowerUp": countPowerUp--; break;
            case "Crystal": countCrystal--; break;
        }

        
    }







}
