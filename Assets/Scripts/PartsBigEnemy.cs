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
    [SerializeField] private float _speedRotation;
    private bool iDestroyed = false;


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
}
