using UnityEngine;

public class ProjectileHero : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private BoundsCheck _boundsCheck;
    public GameObject gameObjectManager;
    private GameObjectManager _gom;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boundsCheck = GetComponent<BoundsCheck>();
        _gom = gameObjectManager.GetComponent<GameObjectManager>();
    }

    private void FixedUpdate()
    {
        GiveForceProjectile();

        if (_boundsCheck != null && _boundsCheck.offUp)
        {
            Destroy(gameObject);
        }
    }

    private void GiveForceProjectile()
    {
        _rb.velocity += new Vector2(0, Mathf.Abs(speed));
    }

    


}
