using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField ]private float speed;



    private void FixedUpdate()
    {        
        transform.Rotate(Vector3.forward, speed * Time.deltaTime, Space.Self);       
    }

}
