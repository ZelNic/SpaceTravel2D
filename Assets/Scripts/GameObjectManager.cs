using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public GameObject[] enemy;
    [SerializeField] private int maxCountEnemyOnScreen;   
    public float timeCreate;
    public float plusTime;   
    private GameObject enemySpawner;
    public static int count;

    private void Update()
    {
        print(count + "GOM");  
        if (count < maxCountEnemyOnScreen && timeCreate < Time.time)
        {            
            SpawnEnemy();            
        }
    }
    public void SpawnEnemy()
    {
        int indInArray = Random.Range(0, enemy.Length);
        enemySpawner = Instantiate(enemy[indInArray]);       
        count++;        
        timeCreate = Time.time + plusTime;        
        Transform posEnemy = enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 30), 0);
    }


    public void UpdateCurrentCount()
    {
        print("Good");
        count--;        
    }










}
