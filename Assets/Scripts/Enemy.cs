using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 5;
    public GameObject gameObjectManager;
    private GameObjectManager _gom;
    private BoundsCheck boundsCheck;
    private Rigidbody2D rb;
    public float speed;
    public bool signal;

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
            health -= 200;
            
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
            health--;
            if(health <= 0)
            {
                _gom.UpdateCurrentCount();
                Destroy(gameObject);
            }
        }
       
    }



    /*public void GetDamage()
    {
        health=-4;
        if (health < 0)
        {
            DestroyEnemy();
        }
        
    }
    public void DestroyEnemy()
    {
        _gom.UpdateCurrentCount();        
        Destroy(gameObject);
    }*/

}
