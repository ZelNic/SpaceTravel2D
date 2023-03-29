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

    public int Crystal
    {
        get { return _crystal; }
        set 
        {
         _crystal = value;
        } 
    }
        

    public int HightScore
    {
        get { return _hightScore; }
        set
        {
            _hightScore = value;
        }
    }
    public static int ScoreGS
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
            HightScore = PlayerPrefs.GetInt("hightScore", HightScore);
            textHighScore.text = HightScore.ToString();
        }

        if (PlayerPrefs.HasKey("Crystal"))
        {
            Crystal = PlayerPrefs.GetInt("Crystal", Crystal);
            textCountCrystal.text = Crystal.ToString();
        }       

    }

    public void Update()
    {
        textScore.text = "s: " + ScoreGS.ToString();
        
        if (ScoreGS > HightScore)
        {
            HightScore = ScoreGS;
            PlayerPrefs.SetInt("hightScore", HightScore);
            PlayerPrefs.Save();            
        }
        textHighScore.text = HightScore.ToString();
        textCountCrystal.text = Crystal.ToString();

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }*/
    }
        

    public void UpdateScore(int value)
    {
        if(value > 102)
        {
            return;
        }
        else ScoreGS += value;       
    }

    public void UpdateCrystal(int value)
    {
        Crystal += value;
        PlayerPrefs.SetInt("Crystal", Crystal);
        PlayerPrefs.Save();
    }



}
