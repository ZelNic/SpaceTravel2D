using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] bigEnemy;
    [SerializeField] private int _maxCountEnemyOnScreen;
    [SerializeField] private int _maxCountBigEnemy;
    [SerializeField] private float startCreateEnemys;
    [SerializeField] private float startCreateBigEnemys;
    private float _timeCreate;
    private float _timeCreateForBigEnemy;
    private GameObject _enemySpawner;
    public float plusTimeForEnemy;
    public float plusTimeForBigEnemy;    
    public static int countEnemy;
    public static int countBigEnemy;    

    private void Awake()
    {
        Application.targetFrameRate = 120;
        countBigEnemy = 0;
        countEnemy = 0;        
    }

    private void FixedUpdate()    {
        
        if (countEnemy < _maxCountEnemyOnScreen && _timeCreate < Time.time && startCreateEnemys < Time.time)
        {
            SpawnEnemy();
        }
       
        if (countBigEnemy < _maxCountBigEnemy && _timeCreateForBigEnemy < Time.time && startCreateBigEnemys < Time.time)
        {
            SpawnBigEnemy();
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
