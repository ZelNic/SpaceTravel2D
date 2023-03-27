using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button pause;
    [SerializeField] private Button menu;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
        

   
    public void GoPlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitFromApp()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
    }

    public void Gameplay()
    {
        Time.timeScale = 1;
        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }
}
