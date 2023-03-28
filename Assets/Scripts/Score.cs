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

    [SerializeField] private Text textCountCrystal;
    private int _crystal;

    public int crystal
    {
        get { return _crystal; }
        set 
        {
         _crystal = value;
        } 
    }
        

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
        textScore.text = "0";
                
        if (PlayerPrefs.HasKey("hightScore"))
        {
            hightScore = PlayerPrefs.GetInt("hightScore", hightScore);
            textHighScore.text = hightScore.ToString();
        }

        if (PlayerPrefs.HasKey("Crystal"))
        {
            crystal = PlayerPrefs.GetInt("Crystal", crystal);
            textCountCrystal.text = crystal.ToString();
        }       

    }

    public void Update()
    {
        textScore.text = "s: " + score.ToString();
        
        if (score > hightScore)
        {
            hightScore = score;
            PlayerPrefs.SetInt("hightScore", hightScore);
            PlayerPrefs.Save();            
        }
        textHighScore.text = hightScore.ToString();
        textCountCrystal.text = crystal.ToString();


       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }*/
    }
        

    public void UpdateScore(int value)
    {
        score += value;       
    }

    public void UpdateCrystal(int value)
    {
        crystal += value;
        PlayerPrefs.SetInt("Crystal", crystal);
        PlayerPrefs.Save();
    }



}
