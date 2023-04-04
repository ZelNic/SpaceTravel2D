using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField] private float _speedBigEnemy;
    [SerializeField] private GameObject goScore;
    private Score _score;
    private BoundsCheck _boundsCheck;
    private Rigidbody2D _rb;
    private Vector2 _halfHeight;


    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
        _rb = GetComponent<Rigidbody2D>();
        _score = goScore.GetComponent<Score>();
        _halfHeight.y = _halfHeight.y +15;
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
        if (GameObjectManager.GOM.CountPartBigEnemy == 5)
        {
            DestroyEnemy();
        }
    }
    public void DestroyEnemy()
    {
        GameObjectManager.GOM.TimeDethBigEnemy = Time.timeSinceLevelLoad + GameObjectManager.GOM.plusTimeForBigEnemy;
        GameObjectManager.GOM.CountPartBigEnemy = 0;        
        GameObjectManager.GOM.DestroyGO(gameObject);
    }





}
