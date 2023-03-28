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

    public void Reset()
    {
        GameObjectManager.GOM.CountBigEnemy = 0;
        GameObjectManager.GOM.CountEnemy = 0;
        GameObjectManager.GOM.CountCrystal = 0;
        GameObjectManager.GOM.CountPowerUp = 0;
        GameObjectManager.GOM.CountMedKit = 0;
        GameObjectManager.GOM.CountWeapon = 0;
        GameObjectManager.GOM.TimeCreate = 0;
        GameObjectManager.GOM.TimeDethBigEnemy = 0;
        GameObjectManager.GOM.CountPartBigEnemy = 0;        
    }

    public void Restart()
    {
        Reset();
        SceneManager.LoadScene("MainScene");
    }

    public void GoPlay()
    {
        Reset();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void ExitFromApp()
    {
        Reset();
        Application.Quit();
    }

    public void Menu()
    {
        Reset();
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
