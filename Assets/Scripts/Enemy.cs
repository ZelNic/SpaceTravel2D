using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    private BoundsCheck _boundsCheck;
    private Rigidbody2D _rb;
    public float speed;
    private TakingDamage _takingDamage;
    [SerializeField] private GameObject goScore;
    public Score _score;
    public bool rotationEnemy;
    public float speedRotation;

    public void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
        _rb = GetComponent<Rigidbody2D>();
        _takingDamage = GetComponent<TakingDamage>();
        _score = goScore.GetComponent<Score>();
    }

    private void FixedUpdate()
    {
        PositionCheck();
        MoveEnemy();
    }

    private void PositionCheck()
    {
        if (_boundsCheck != null && _boundsCheck.offDown)
        {
            DestroyEnemy();
        }
    }

    public virtual void MoveEnemy()
    {
        _rb.position -= new Vector2(0, speed * Time.deltaTime);

        if(rotationEnemy == true)
        {
            transform.Rotate(Vector3.forward, speedRotation * Time.deltaTime, Space.Self);
        }
    }


    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            _takingDamage.ChangeColorTakingDamage();
            if (_health < 0.5f)
            {
                DestroyEnemy();
                _score.UpdateScore(5);
            }
        }
    }

    public virtual void DestroyEnemy()
    {
        GameObjectManager.countEnemy--;
        Destroy(gameObject);
    }

    
}
