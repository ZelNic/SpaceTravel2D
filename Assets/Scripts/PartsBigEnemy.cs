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

    private void Start()
    {
        _score = goScore.GetComponent<Score>();
        _takingDamage = GetComponent<TakingDamage>();
    }

    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            _takingDamage.ChangeColorTakingDamage();
            if (_health < 0f)
            {
                _score.UpdateScore(5);
                DestroyPart();
            }
        }
    }

    public void FixedUpdate()
    {
        CreateProjectile();
        
    }
    

    public void CreateProjectile()
    {        
        if (_timeCreateProjectile < Time.time)
        {
           _proEnemy = Instantiate(projectileEnemyPrefab);
           _proEnemy.transform.position = this.transform.position;
           _timeCreateProjectile = Time.time + Random.Range(2f,5f);
        }
    }  


    public void DestroyPart()
    {
        int healthBE = BigEnemy.healthBigEnemy;
        healthBE--;
        BigEnemy.healthBigEnemy = healthBE;

        Destroy(gameObject);
    }
}
