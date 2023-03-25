using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] bigEnemy;
    public GameObject[] arrayPowerUP;
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float startCreateEnemys;
    [SerializeField] private float startCreateBigEnemys;
    [SerializeField] private float chanceCreatePowerUp;
    private float _timeCreate;
    private float _timeCreateForBigEnemy;
    private GameObject _enemySpawner;
    public float plusTimeForEnemy;
    public float plusTimeForBigEnemy;
    public static int countEnemy;
    public static int countBigEnemy;
    public static int scoreKillEnemys;


    private void Awake()
    {        
        countBigEnemy = 0;
        countEnemy = 0;
    }

    private void FixedUpdate()
    {

        if (countEnemy < _maxCountEnemyOnScreen && _timeCreate < Time.time && startCreateEnemys < Time.time)
        {
            SpawnEnemy();
        }

        if (countBigEnemy < _maxCountBigEnemy && _timeCreateForBigEnemy < Time.time && startCreateBigEnemys < Time.time)
        {
            SpawnBigEnemy();
        }
    }


    public void CreatePowerUp(bool value, Transform transform)
    {
        if (value == true && chanceCreatePowerUp < Random.Range(0, 11))
        {
            int indInArray = Random.Range(0, arrayPowerUP.Length);
            GameObject powerUpGO = Instantiate(arrayPowerUP[indInArray]);
            powerUpGO.transform.position = transform.position;
        }
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











}
