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
        if (count < maxCountEnemyOnScreen && timeCreate < Time.time)
        {            
            SpawnEnemy();            
        }
    }
    public void SpawnEnemy()
    {
        int indInArray = Random.Range(0, enemy.Length);
        enemySpawner = Instantiate(enemy[indInArray]);
        if (enemySpawner.tag == "BigEnemy")
        {
            count = +5;
        }
        else
        {
            count++;
        }
              
        timeCreate = Time.time + plusTime;        
        Transform posEnemy = enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 35), 0);
    }


    public void UpdateCurrentCount()
    {        
        count--;        
    }










}
