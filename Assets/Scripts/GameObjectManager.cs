using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] bigEnemy;
    [SerializeField] private int maxCountEnemyOnScreen;
    [SerializeField] private int maxCountBigEnemy;
    public float timeCreate;
    public float plusTimeForEnemy;
    public float plusTimeForBigEnemy;
    private GameObject enemySpawner;    
    public static int count;
    public static int countBigEnemy;

    private void FixedUpdate()
    {
        if (count < maxCountEnemyOnScreen && timeCreate < Time.time)
        {
            SpawnEnemy();
        }
       
        if (countBigEnemy < maxCountBigEnemy && timeCreate < Time.time)
        {
            SpawnBigEnemy();
        }
    }
    public void SpawnEnemy()
    {
        int indInArray = Random.Range(0, enemy.Length);
        enemySpawner = Instantiate(enemy[indInArray]);
        count++;
        Transform posEnemy = enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 35), 0);
        timeCreate = Time.time + plusTimeForEnemy;
    }
    public void SpawnBigEnemy()
    {
        int indInArray = Random.Range(0, bigEnemy.Length);
        enemySpawner = Instantiate(bigEnemy[indInArray]);
        countBigEnemy++;
        Transform posEnemy = enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(0, 25, 0);
        timeCreate = Time.time + plusTimeForBigEnemy;
    }


    public void UpdateCurrentCount()
    {
        count--;
    }










}
