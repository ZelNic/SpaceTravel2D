using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    private BoundsCheck _boundCheck;
    public float speedProjectile;
    private void Start()
    {
        _boundCheck = GetComponent<BoundsCheck>();
    }



    private void LateUpdate()
    {
        MoveProjectile();
        OnDestroy();

    }

    private void MoveProjectile()
    {
       transform.position -= new Vector3(0, speedProjectile, 0) * Time.deltaTime;       
    }

    private void OnDestroy()
    {
        if (_boundCheck.offDown)
        {
            Destroy(gameObject);
        }
    }
}
