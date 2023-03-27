using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float speed;
    private BoundsCheck _boundsCheck;
    private float timeLive = 5f;
    private float startLive;

    public bool powerUp;
    public bool crystal;
    public bool medKit;



    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
        startLive = Time.time + timeLive;
    }   

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime, Space.Self);
        transform.position -= new Vector3(0, 2 * Time.deltaTime);


        if (_boundsCheck.offDown || startLive < Time.time)
        {
            if(medKit == true)
            {
                GameObjectManager.GOM.DestroyGO(gameObject);
                Destroy(gameObject);
            }
            if(crystal == true)
            {
                GameObjectManager.GOM.DestroyGO(gameObject);
                Destroy(gameObject);
            }
            if (powerUp == true) 
            {
                GameObjectManager.GOM.DestroyGO(gameObject);
                Destroy(gameObject);
            }          
            
        }

    }

}
