using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    public float timeRemaining = 360.0f;

    public Text timeTextBox;

    public static int countDown;


    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update ()
    {
        //Debug.Log("this is the game scene. countdown should begin");
        //float delta = Time.deltaTime * 10;
        //countDown = (int)(timeRemaining - delta);
        //Debug.Log("timeRemaining: " + timeRemaining);

        countDown = (int)(timeRemaining - 0.037f);
        //Debug.Log("countdow: " + countDown);

        PlayerPrefs.SetInt("Time", countDown);
        if (countDown > 10)
            timeTextBox.text = "Time: " + PlayerPrefs.GetInt("Time");
        else if (countDown > 0)
            timeTextBox.text = "Time: " + PlayerPrefs.GetInt("Time") + " Hurry!";
        else if (countDown == 0)
            SceneManager.LoadScene("DisplayFinalScoreScene");
        timeRemaining = timeRemaining - 0.037f;
    }
}
