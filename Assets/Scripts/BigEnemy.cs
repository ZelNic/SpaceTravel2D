using System.Collections.Generic;
using UnityEngine;


public class BigEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> part;
    [SerializeField] private float _speedBigEnemy;   
    private BoundsCheck _boundsCheck;
    private Rigidbody2D _rb;
    public  int healthBigEnemy;
    private Vector2 _halfHeight;

    private void Awake()
    {   
        healthBigEnemy = 5;
        _boundsCheck = GetComponent<BoundsCheck>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _halfHeight.y = _boundsCheck.camHeight - 10f;
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
        if (GameObjectManager.GOM.CountPartBigEnemy == 5)
        {
            Destroy(gameObject);
            GameObjectManager.GOM.TimeDethBigEnemy = Time.timeSinceLevelLoad + 30f;
            GameObjectManager.GOM.CreateCrystal(gameObject, transform);
            GameObjectManager.GOM.DestroyGO(gameObject);
        }
        
    }

   



}
