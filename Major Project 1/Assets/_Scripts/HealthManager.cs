using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts;
    public int startingLives;
    private int lifeCounter;
    private float delay = 1.0f;

    // Use this for initialization
    void Start ()
    {
        lifeCounter = startingLives;
        PlayerPrefs.SetInt("Lives", lifeCounter);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseLives(int lives)
    {
        switch (lives)
        {
            case 3:
                //hearts[lives - 1].gameObject.SetActive(false);
                Vector2 newHeartPosition = hearts[0].transform.position;
                newHeartPosition.y = newHeartPosition.y - 75.0f;
                //Instantiate(hearts[0], newHeartPosition, Quaternion.identity);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
               // Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 2:
                hearts[lives - 1].gameObject.SetActive(false);
                lifeCounter++;
                PlayerPrefs.SetInt("Lives", lifeCounter);
                //Invoke("deathRestart", delay);
                //Invoke("restartScene", delay);
                break;
            case 1:
                hearts[lives - 1].gameObject.SetActive(false);
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
