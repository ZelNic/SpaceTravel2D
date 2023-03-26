using UnityEditor.PackageManager;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] bigEnemy;
    public GameObject[] arrayPowerUP;
    public GameObject crystal;
    public GameObject medKit;
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float _startCreateEnemys;
    [SerializeField] private float _startCreateBigEnemys;
    [SerializeField] private float _chanceCreatePowerUp;
    private float _timeCreate;    
    private GameObject _enemySpawner;
    public float plusTimeForEnemy;
    public float plusTimeForBigEnemy;
    public static int countEnemy;
    public static int countBigEnemy;
    public static int scoreKillEnemys;
    public static int scoreKillBigEnemys = 1;
    public static int scoreForBoss;
    public static int countPowerUp;
    public static int countCrystal;
    public static int counMedKit;
    public static float timeDethBigEnemy;
    public int countPUp;
    public int countCral;

    private void Awake()
    {
        countBigEnemy = 0;
        countEnemy = 0;        
        countPowerUp = 0;
        countCrystal = 0;
    }

    private void Update()
    {
        print(timeDethBigEnemy);
    }

    private void LateUpdate()
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

    public void CreatePowerUp(Enemy enemy, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && countPowerUp < 1)
        {
            int indInArray = 59;
            indInArray = Random.Range(0, arrayPowerUP.Length);
            GameObject powerUpGO = Instantiate(arrayPowerUP[indInArray]);
            powerUpGO.transform.position = transform.position;
            countPowerUp++;            
            return;
        }

    }
    public void CreateCrystal(Enemy enemy, Transform transform)
    {
        if (countCrystal < 1)
        {
            countCrystal++;
            GameObject powerUpGO = Instantiate(crystal);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
            return;
        }
    }

    public void CreateCrystal(BigEnemy bigEnemy, Transform transform)
    {
        if (countCrystal < 1)
        {
            countCrystal++;
            GameObject powerUpGO = Instantiate(crystal);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
            return;
        }

    }

    public void CreateMedKit(Enemy enemy, Transform transform)
    {
        int rand = Random.Range(0, 11);
        if (8 < rand && countPowerUp < 1)
        {
            GameObject powerUpGO = Instantiate(medKit);
            powerUpGO.transform.position = transform.position;
            powerUpGO.transform.position += new Vector3(1, 0, 0);
            countPowerUp++;
            return;
        }

    }

    public void SpawnEnemy()
    {
        int indInArray = 59;
        indInArray = Random.Range(0, enemy.Length);
        _enemySpawner = Instantiate(enemy[indInArray]);
        countEnemy++;
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 45), 0);
        _timeCreate = Time.time + plusTimeForEnemy;
        return;
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
    










}
