using UnityEngine;

/// <summary>
/// Данный скрипт окрашивает на 0.1 сек игровой объект в красный цвет - сигнал получения урона.
/// Для его работы необходимо прикрепить даннный скрипт в игровому объекту, который будет получать урон.
/// В скрипте игрового объекта необходимо объявить переменную TakingDamage _takingDamage  и заполнить данное поле в методе Awake.
/// При получение необходимо вызвать метод ChangeColorTakingDamage();. /// 
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
