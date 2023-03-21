using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private Transform[] transformsPointSpawn;
    [SerializeField] public List<GameObject> part;
    [SerializeField] private float speedBigEnemy;
    [SerializeField] private GameObject gameObjectManager;
    private BoundsCheck boundsCheck;
    private Rigidbody2D _rb;
    public static int healthBigEnemy;
    private Vector2 halfCamHeight = new Vector2(0,15f);
    [SerializeField] private GameObject goScore;
    private Score _score;

    private void Awake()
    {
        healthBigEnemy = 5;
        CreateBigEnemy();
        boundsCheck = GetComponent<BoundsCheck>();
        _rb = GetComponent<Rigidbody2D>();
        _score = goScore.GetComponent<Score>();
        
    }

    public void CreateBigEnemy()
    {
        for (int i = 0; i < transformsPointSpawn.Length; i++)
        {
            var child = Instantiate(prefabs, transformsPointSpawn[i]);
            part.Add(child);
        }
    }
    private void FixedUpdate()
    {
        PositionCheck();
        MoveEnemy();
        UpdateHealthBigEnemy();
        
    }
    private void PositionCheck()
    {
        if (boundsCheck.offDown)
        {
            DestroyEnemy();
        }
    }
    public void MoveEnemy()
    {
        _rb.position -= new Vector2(0, speedBigEnemy * Time.deltaTime);

        if (_rb.position.y == halfCamHeight.y)
        {
            print("iam here");
        }
       


    }
    public void UpdateHealthBigEnemy()
    {
        if (healthBigEnemy == 0)
        {
            DestroyEnemy();
        }
    }
    public void DestroyEnemy()
    {        
        int bEcount = GameObjectManager.countBigEnemy;
        bEcount--;
        GameObjectManager.countBigEnemy = bEcount;
        Destroy(gameObject);
    }







}
