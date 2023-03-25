using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] bigEnemy;
    public GameObject[] arrayPowerUP;
    public GameObject crystal;
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float _startCreateEnemys;
    [SerializeField] private float _startCreateBigEnemys;
    [SerializeField] private float _chanceCreatePowerUp;
    private float _timeCreate;
    private float _timeCreateForBigEnemy;
    private GameObject _enemySpawner;
    public float plusTimeForEnemy;
    public float plusTimeForBigEnemy;
    public static int countEnemy;
    public static int countBigEnemy;
    public static int scoreKillEnemys;
    public static int scoreKillBigEnemys = 1;
    public static int scoreForBoss;
    public static int countPowerUp;

    private void Awake()
    {
        countBigEnemy = 0;
        countEnemy = 0;
        scoreForBoss = 70;
    }

    private void FixedUpdate()
    {
        if (countEnemy < _maxCountEnemyOnScreen && _timeCreate < Time.time && _startCreateEnemys < Time.time)
        {
            SpawnEnemy();
        }

        if (countBigEnemy < _maxCountBigEnemy && Score.score == scoreForBoss)
        {
            SpawnBigEnemy();
        }
    }

    public void CreatePowerUp(Enemy enemy, Transform transform)
    {
        if (_chanceCreatePowerUp < Random.Range(0, 11))
        {
            int indInArray = 59;
            indInArray = Random.Range(0, arrayPowerUP.Length);
            GameObject powerUpGO = Instantiate(arrayPowerUP[indInArray]);
            powerUpGO.transform.position = transform.position;
            return;
        }
    }
    public void CreateCrystal(Enemy enemy, Transform transform)
    {

        GameObject powerUpGO = Instantiate(crystal);
        powerUpGO.transform.position = transform.position;
        powerUpGO.transform.position += new Vector3(1, 0, 0);
        return;
    }

    public void CreateCrystal(BigEnemy bigEnemy, Transform transform)
    {
        GameObject powerUpGO = Instantiate(crystal);
        powerUpGO.transform.position = transform.position;
        powerUpGO.transform.position += new Vector3(1, 0, 0);
        return;
    }

    public void SpawnEnemy()
    {
        int indInArray = Random.Range(0, enemy.Length);
        _enemySpawner = Instantiate(enemy[indInArray]);
        countEnemy++;
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 35), 0);
        _timeCreate = Time.time + plusTimeForEnemy;
    }
    
    public void SpawnBigEnemy()
    {
        int indInArray = Random.Range(0, bigEnemy.Length);
        _enemySpawner = Instantiate(bigEnemy[indInArray]);
        countBigEnemy++;
        Transform posEnemy = _enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(0, 25, 0);
        _timeCreateForBigEnemy = Time.time + plusTimeForBigEnemy;
    }
    public static void ScoreForBoss()
    {
        scoreForBoss = scoreKillBigEnemys * 70;
    }










}
