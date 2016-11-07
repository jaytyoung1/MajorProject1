using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public void loadGameScene()
    {
        //PlayerPrefs.SetInt("Time", 10);
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Time", 0);
        SceneManager.LoadScene("Level 1");
    }

    public void loadHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void loadHighScoresScene()
    {
        SceneManager.LoadScene("HighScoresScene");
    }

    public void loadWelcomeScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
