using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public float frequencyEnemy;
    public GameObject[] enemy;
    [SerializeField] private int maxCountEnemyOnScreen;
    public int currentCountEnemy;
    public int setCurrentCount;
    public float timeCreate;
    public float plusTime;
    

    
    private void Update()
    {
        currentCountEnemy = setCurrentCount;
        print(setCurrentCount);
        if (currentCountEnemy < maxCountEnemyOnScreen && timeCreate < Time.time)
        {
            SpawnEnemy();
            
        }
    }

    public void SpawnEnemy()
    {
        int indInArray = Random.Range(0, enemy.Length);
        GameObject enemySpawner = Instantiate(enemy[indInArray]);
        setCurrentCount++; 
        timeCreate = Time.time + 0.5f;
        currentCountEnemy = setCurrentCount;
        Transform posEnemy = enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 30), 0);
    }

    

    public int UpdateCurrentCount()
    {            
       return (setCurrentCount--);
    }


    public void Test()
    {
        print("Test");
    }







}
