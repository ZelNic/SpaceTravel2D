using UnityEngine;

public class PartsBigEnemy : MonoBehaviour
{
    public GameObject projectileEnemyPrefab;
    [SerializeField] private int _health;
    [SerializeField] private GameObject bigEnemy;
    [SerializeField] private GameObject goScore;
    private Score _score;
    private TakingDamage _takingDamage;
    private float _timeCreateProjectile;
    private GameObject _proEnemy;
    public GameObject goBE;
    private BigEnemy _be;
    [SerializeField] private bool _rotationEnemy;
    [SerializeField] private bool _abilityToMove;
    [SerializeField] private float _speedRotation;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BoundsCheck _boundsCheck;
    [SerializeField] private float _speed;
    private bool iDestroyed = false;
    private Vector2 _halfHeight;
    private float _liveTime;






    private void Start()
    {
        _score = goScore.GetComponent<Score>();
        _takingDamage = GetComponent<TakingDamage>();

        if (_abilityToMove == true)
        {
            _rb = GetComponent<Rigidbody2D>();
            _boundsCheck = GetComponent<BoundsCheck>();
            _halfHeight.y = _boundsCheck.camHeight - 13f;
            _liveTime = Time.timeSinceLevelLoad + 15f;
        }
    }
    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            _takingDamage.ChangeColorTakingDamage();
            if (_health <= 0)
            {
                _score.UpdateScore(5);
                DestroyPart();
            }
        }
    }
    public void FixedUpdate()
    {
        CreateProjectile();
        Rotation();
        IGetAbilityToMove();

    }
    public void CreateProjectile()
    {
        if (_timeCreateProjectile < Time.time)
        {
            _proEnemy = Instantiate(projectileEnemyPrefab);
            _proEnemy.transform.position = transform.position;
            _timeCreateProjectile = Time.time + Random.Range(2f, 5f);
        }
    }
    public void Rotation()
    {
        if (_rotationEnemy == true)
        {
            transform.Rotate(Vector3.forward, _speedRotation * Time.deltaTime, Space.Self);
        }
    }
    public void DestroyPart()
    {
        if (iDestroyed == false)
        {
            iDestroyed = true;
            GameObjectManager.GOM.DestroyGO(gameObject);
        }

    }

    public void IGetAbilityToMove()
    {
        if (_abilityToMove == true)
        {

            if (_rb.position.y > _halfHeight.y)
            {
                _rb.position -= new Vector2(0, _speed * Time.deltaTime);

            }
            if(_rb.position.y < _halfHeight.y)
            {
                _rb.position += new Vector2(_speed * Time.deltaTime, 0);
                if (_boundsCheck.offRight)
                {
                    _speed = -Mathf.Abs(_speed);
                }
                if (_boundsCheck.offLeft)
                {
                    _speed = Mathf.Abs(_speed);
                }
                if (_liveTime < Time.timeSinceLevelLoad)
                {                   
                    if (_boundsCheck.offLeft)
                    {
                        GameObjectManager.GOM.DestroyGO(gameObject);
                    }
                }
            }   
            



        }


    }
}

