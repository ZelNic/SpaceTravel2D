using UnityEngine;

public class E_Fast : Enemy
{
    private Vector2 startPos;
    private Vector2 currentPos;
    private Vector2 endPos;
    private Rigidbody2D _rb;
    private BoundsCheck boundsCheckE;
    public float speedE;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        boundsCheckE = GetComponent<BoundsCheck>();
        startPos = _rb.position;
        currentPos = startPos;
        endPos = new Vector2(Random.Range(-boundsCheckE.camWidth, boundsCheckE.camWidth), -boundsCheckE.camHeight + 3f);

    }

    private void FixedUpdate()
    {
        if (boundsCheckE.offLeft || boundsCheckE.offDown || boundsCheckE.offRight)
        {
            DestroyEnemy();
        }
        MoveEnemy();
    }

    public override void MoveEnemy()
    {
        _rb.position += Vector2.Lerp(startPos, endPos, speedE) * Time.deltaTime;
    }

}
