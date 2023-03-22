using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController _pc;

    [SerializeField] private Text textScore;
    private static int _score;

    private void Awake()
    {
        _score = 0;
        _pc = player.GetComponent<PlayerController>();
        textScore.text = "0";

    }

    public void Update()
    {
        textScore.text = score.ToString();

    }

    public static int score
    {
        get { return _score; }
        set 
        {
           _score = value;           
        }
    }

    public void UpdateScore(int value)
    {        
        score += value;
    }



}
