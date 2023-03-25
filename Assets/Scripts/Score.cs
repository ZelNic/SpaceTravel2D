using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController _pc;

    [SerializeField] private Text textScore;
    private static int _score;

    [SerializeField] private Text textHighScore;
    private int _hightScore;


    public int hightScore
    {
        get { return _hightScore; }
        set
        {
            _hightScore = value;
        }
    }
    public static int score
    {
        get { return _score; }
        set
        {
            _score = value;
        }
    }

    private void Awake()
    {
        _score = 0;
        _pc = player.GetComponent<PlayerController>();
        textScore.text = "0";
        

        if (PlayerPrefs.HasKey("hightScore"))
        {
            hightScore = PlayerPrefs.GetInt("hightScore", hightScore);
            textHighScore.text = hightScore.ToString();
        }

    }

    public void Update()
    {
        textScore.text = score.ToString();
        
        if (score > hightScore)
        {
            hightScore = score;
            PlayerPrefs.SetInt("hightScore", hightScore);
            PlayerPrefs.Save();            
        }
        textHighScore.text = hightScore.ToString();


        if (Input.GetKey(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey("hightScore");
            hightScore = 0;
        }
    }
        

    public void UpdateScore(int value)
    {
        score += value;       
    }

   

}
