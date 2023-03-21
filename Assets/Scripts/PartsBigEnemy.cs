using UnityEngine;

public class PartsBigEnemy : MonoBehaviour
{
    private int health;
    [SerializeField] private GameObject bigEnemy;

    private void Start()
    {
        health = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Hero")
        {
            DestroyPart();            
        }
        if (collision.gameObject.tag == "ProjectileHero")
        {            
            health--;
            Destroy(collision.gameObject);
            if (health == 0)
            {
                DestroyPart();                
            }
        }
    }

    private void DestroyPart()
    {  
        int healthBE = BigEnemy.healthBigEnemy;        
        healthBE--;
        BigEnemy.healthBigEnemy = healthBE;
        Destroy(gameObject);
    }
}
