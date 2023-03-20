using System.Collections.Generic;
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
    public List<GameObject> enemyList = new List<GameObject>();
    private GameObject enemySpawner;



    private void Update()
    {
        print(enemyList.Count);    
        if (enemyList.Count < maxCountEnemyOnScreen && timeCreate < Time.time)
        {            
            SpawnEnemy();            
        }
    }

    public void SpawnEnemy()
    {
        int indInArray = Random.Range(0, enemy.Length);
        enemySpawner = Instantiate(enemy[indInArray]);
        enemyList.Add(enemySpawner);
        timeCreate = Time.time + 0.5f;        
        Transform posEnemy = enemySpawner.GetComponent<Transform>();
        posEnemy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(25, 30), 0);
    }        

    public void UpdateCurrentCount()
    {
        enemyList.Remove(enemySpawner);
    }


    







}
