using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float speed;
    private BoundsCheck _boundsCheck;
    private float timeLive = 5f;
    private float startLive;

    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
        startLive = Time.realtimeSinceStartup + timeLive;
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime, Space.Self);
        transform.position -= new Vector3(0, 2 * Time.deltaTime);


        if (_boundsCheck.offDown || startLive < Time.time)
        {
            Destroy(gameObject);
        }

    }

}
