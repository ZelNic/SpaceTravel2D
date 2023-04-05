using UnityEngine;

public class E_Fast : Enemy
{
    private Vector2 _startPos;    
    private Vector2 _endPos;
    private Rigidbody2D _rbe;
    private BoundsCheck _boundsCheckE;
    public float speedE;

    public void Start()
    {
        _rbe = GetComponent<Rigidbody2D>();
        _boundsCheckE = GetComponent<BoundsCheck>();
        _startPos = _rbe.position;       
        _endPos = new Vector2(Random.Range(-_boundsCheckE.camWidth, _boundsCheckE.camWidth), -_boundsCheckE.camHeight + 3f);
    }

    private void FixedUpdate()
    {
        CheckBound();
        MoveEnemy();
    }

    private void CheckBound()
    {
        if (_boundsCheckE.offLeft || _boundsCheckE.offDown || _boundsCheckE.offRight)
        {
            DestroyEnemy();
        }
    }

    public override void MoveEnemy()
    {
        _rbe.position += Vector2.Lerp(_startPos, _endPos, speedE) * Time.deltaTime;
    }

}
