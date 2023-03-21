using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController _pc;
    
    [SerializeField] private Text textScore;
    private float _score;

    private void Awake()
    {
        _pc = player.GetComponent<PlayerController>();
        textScore.text = "0";

    }

    public void Update()
    {
        textScore.text = _score.ToString();
        print(_score);
    }

    public void UpdateScore(int value)
    {
        _score += value;        
    }



}
