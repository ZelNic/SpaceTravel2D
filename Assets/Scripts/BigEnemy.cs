using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private Transform[] transformsPointSpawn;
    [SerializeField] public List<GameObject> part;
    [SerializeField] private float _speedBigEnemy;
    [SerializeField] private GameObject _gameObM;
    [SerializeField] private GameObjectManager _gom;
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
        _gom = _gameObM.GetComponent<GameObjectManager>();
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
            _rb.position -= new Vector2(0, _speedBigEnemy * Time.deltaTime);
        }
        else _rb.position += new Vector2(_speedBigEnemy * Time.deltaTime, 0);


        if (_boundsCheck.offRight)
        {
            _speedBigEnemy = -Mathf.Abs(_speedBigEnemy);
        }
        if (_boundsCheck.offLeft)
        {
            _speedBigEnemy = Mathf.Abs(_speedBigEnemy);
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
        GameObjectManager.scoreKillBigEnemys++;
        GameObjectManager.ScoreForBoss();
        _gom.CreateCrystal(this, transform);
        Destroy(gameObject);
    }







}
