using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private Transform[] transformsPointSpawn;
    [SerializeField] public List<GameObject> part;
    [SerializeField] private float speedBigEnemy;    
    private BoundsCheck _boundsCheck;
    private Rigidbody2D _rb;
    public static int healthBigEnemy;
    private Vector2 _halfHeight;

    private void Awake()
    {
        healthBigEnemy = 5;
        CreateBigEnemy();
        _boundsCheck = GetComponent<BoundsCheck>();
        _rb = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        _halfHeight.y = _boundsCheck.camHeight - 10f;        
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
        if (_boundsCheck.offDown)
        {
            DestroyEnemy();
        }
    }
    public void MoveEnemy()
    {
        if (_rb.position.y > _halfHeight.y)
        {
            _rb.position -= new Vector2(0, speedBigEnemy * Time.deltaTime);
        }
        else _rb.position += new Vector2(speedBigEnemy * Time.deltaTime, 0);              
        
        
        if (_boundsCheck.offRight)
        {
            speedBigEnemy = -Mathf.Abs(speedBigEnemy);
        }
        if (_boundsCheck.offLeft)
        {
            speedBigEnemy = Mathf.Abs(speedBigEnemy);
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
        GameObjectManager.countBigEnemy--;
        Destroy(gameObject);
    }







}
