using UnityEngine;

public class PartsBigEnemy : MonoBehaviour
{
    private int health;
    [SerializeField] private GameObject bigEnemy;
    [SerializeField] private GameObject goScore;
    private Score _score;
    private void Start()
    {
        _score = goScore.GetComponent<Score>();
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
