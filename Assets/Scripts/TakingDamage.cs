using UnityEngine;

/// <summary>
/// ������ ������ ���������� �� 0.1 ��� ������� ������ � ������� ���� - ������ ��������� �����.
/// ��� ��� ������ ���������� ���������� ������� ������ � �������� �������, ������� ����� �������� ����.
/// � ������� �������� ������� ���������� �������� ���������� TakingDamage _takingDamage  � ��������� ������ ���� � ������ Awake.
/// ��� ��������� ���������� ������� ����� ChangeColorTakingDamage();. /// 
/// </summary>
public class TakingDamage : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;    
    private Color defultColor;
    private float startTime;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        defultColor = m_SpriteRenderer.color;
    }

    private void FixedUpdate()
    {
        OnDefultColor();
    }

    public void ChangeColorTakingDamage()
    {
        m_SpriteRenderer.color = Color.red;
        startTime = Time.time +.1f;
    }

    public void OnDefultColor()
    {
        if(startTime < Time.time)
        {
            m_SpriteRenderer.color = defultColor;
        }       
    }

}
