using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts;
    public int startingLives;
    private int lifeCounter;

    // Use this for initialization
    void Start ()
    {
        lifeCounter = startingLives;
        PlayerPrefs.SetInt("Lives", lifeCounter);

        for (int i = lifeCounter; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseLives(int lives)
    {
        switch (lives)
        {
            case 6:
                break;
            case 5:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                // Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 4:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                // Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 3:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
               // Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 2:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 1:
                hearts[lives].SetActive(true);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("goToFinalScoreScene", delay);
                break;
        }
    }

    public void decreaseLives(int lives)
    {
        //int decLives = lives;
        switch (lives)
        {
            case 6:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 5:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 4:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 3:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 2:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 1:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter--;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("goToFinalScoreScene", delay);
                break;
        }
    }
}
