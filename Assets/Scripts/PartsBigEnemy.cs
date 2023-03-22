using UnityEngine;

public class PartsBigEnemy : MonoBehaviour
{
    private int _health;
    [SerializeField] private GameObject bigEnemy;
    [SerializeField] private GameObject goScore;
    private Score _score;
    private void Start()
    {
        _score = goScore.GetComponent<Score>();
        health = 2;
    }
        

    public int health
    {
        get { return _health; }
        set { _health = value; }
    }


    public void DestroyPart()
    {
        int healthBE = BigEnemy.healthBigEnemy;        
        healthBE--;
        BigEnemy.healthBigEnemy = healthBE;
        Destroy(gameObject);
    }
}
