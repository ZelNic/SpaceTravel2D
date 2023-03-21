using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject gameObjectManager;
    private GameObjectManager _gom;
    private BoundsCheck boundsCheck;
    private Rigidbody2D rb;
    public float speed;
    private int countEnemyInList;
    [SerializeField] private GameObject goScore;
    private Score _score;
    public void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
        rb = GetComponent<Rigidbody2D>();
        _gom = gameObjectManager.GetComponent<GameObjectManager>();
        _score = goScore.GetComponent<Score>();
    }

    private void FixedUpdate()
    {
        PositionCheck();
        MoveEnemy();
    }

    private void PositionCheck()
    {
        if (boundsCheck != null && boundsCheck.offDown)
        {
            DestroyEnemy();
        }
    }

    public virtual void MoveEnemy()
    {
        rb.AddForce(new Vector2(0, -Mathf.Abs(speed * Time.deltaTime)));
    }

    [SerializeField] private int _health = 5;
    public int health
    {
        get { return _health; }
        set { _health = value;}
    }

    public void GetDamage(int value)
    {

    }

    public virtual void DestroyEnemy()
    {
        countEnemyInList = GameObjectManager.count;
        countEnemyInList--;
        GameObjectManager.count = countEnemyInList;
        Destroy(gameObject);
    }

}
