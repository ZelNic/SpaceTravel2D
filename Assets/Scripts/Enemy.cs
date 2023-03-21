using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 5;
    public GameObject gameObjectManager;
    private GameObjectManager _gom;
    private BoundsCheck boundsCheck;
    private Rigidbody2D rb;
    public float speed;
    private int countEnemyInList;

    public void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
        rb = GetComponent<Rigidbody2D>();
        _gom = gameObjectManager.GetComponent<GameObjectManager>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (collision.gameObject.tag == "ProjectileHero")
        {
            Destroy(collision.gameObject);
            health--;
            if (health <= 0)
            {
                countEnemyInList = GameObjectManager.count;
                countEnemyInList--;
                GameObjectManager.count = countEnemyInList;

                Destroy(gameObject);
            }
        }
    }


    public virtual void GetDamage()
    {
        health = -4;
        if (health < 0)
        {
            DestroyEnemy();
        }

    }
    public virtual void DestroyEnemy()
    {

        countEnemyInList = GameObjectManager.count;
        countEnemyInList--;
        GameObjectManager.count = countEnemyInList;
        Destroy(gameObject);
    }

}
