using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
        _rb = GetComponent<Rigidbody2D>();
        _takingDamage = GetComponent<TakingDamage>();
        _score = goScore.GetComponent<Score>();       
    }

    [SerializeField] private int _health = 5;
    private BoundsCheck _boundsCheck;
    private Rigidbody2D _rb;
    public float speed;
    private TakingDamage _takingDamage;
    [SerializeField] private GameObject goScore;
    public Score _score;
    public bool rotationEnemy;
    public float speedRotation;
    public bool createPowerUp;
    public bool createCrystal;
    public bool createMedKit;
    
    private bool _destroyed = false;
    

    

    private void Update()
    {
        PositionCheck();
        MoveEnemy();
    }

    private void PositionCheck()
    {
        if (_boundsCheck.offDown)
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
                _score.UpdateScore(5);
                DestroyEnemy();                
            }
        }
    }

    public virtual void DestroyEnemy()
    {
        if(createCrystal == true)
        {
            GameObjectManager.GOM.CreateCrystal(gameObject, transform);
        }
        if(createMedKit == true)
        {
            GameObjectManager.GOM.CreatePowerUp(gameObject, transform);
        }
        if(createPowerUp == true)
        {
            GameObjectManager.GOM.CreatePowerUp(gameObject, transform);
        }

        GameObjectManager.GOM.DestroyGO(gameObject);        
    }


    
}
