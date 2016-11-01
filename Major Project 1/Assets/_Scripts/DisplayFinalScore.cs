using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayFinalScore : MonoBehaviour
{
    public InputField initialsInputField;
    public Text timeRemainingtextBox;
    public Text coinsCollectedTextBox;
    public Text totalScoreTextBox;
    public Text highScoreTextBox;

    //public Text displayHighScoresTextBox;

    private float totalScore;
    public const int highScoreCount = 10;


    // Use this for initialization
    void Start ()
    {
        initialsInputField.gameObject.SetActive(false);
        //Debug.Log("coin count " + PlayerPrefs.GetInt("Coins"));
        //textBox = GetComponent<Text>();
        //textBox.text = "Coins: " + PlayerPrefs.GetInt("Coins") + "\nTime Remaining: " + PlayerPrefs.GetInt("Time");
        timeRemainingtextBox.text = "=  " + PlayerPrefs.GetInt("Time");
        coinsCollectedTextBox.text = "=  " + PlayerPrefs.GetInt("Coins");

        if (PlayerPrefs.GetInt("Coins") == 0)
            totalScore = PlayerPrefs.GetInt("Time");
        
        else if (PlayerPrefs.GetInt("Coins") > 0)
        {
            float multiplier = (0.1f * (float)PlayerPrefs.GetInt("Coins")) + 1.0f;
            totalScore = (PlayerPrefs.GetInt("Time")) * multiplier;
        }
        PlayerPrefs.SetFloat("totalScore", totalScore);
        totalScoreTextBox.text = "=  " + PlayerPrefs.GetInt("Time") + "  x 1." + PlayerPrefs.GetInt("Coins") + "  (coin multiplier)\n\n=  " + totalScore;

        if (isHighScore(totalScore))
        {
            highScoreTextBox.text = ("You earned a high score! Type your initials and press ENTER.");
            initialsInputField.gameObject.SetActive(true);

            //if (isHighScoresUpdated(playerInitials, totalScore))
            //{
            //    displayHighScoresTextBox.gameObject.SetActive(true);
            //    displayScores();
            //}
        }
        else
        {
            highScoreTextBox.text = ("\t\t\t\tTry again. You did not earn a high score.");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void intialsEntered()
    {
        string playerName = initialsInputField.text;
        string playerInitials = "";

        if (playerName.Length >= 3)
            playerInitials = playerName.Substring(0, 3);
        else
            playerInitials = playerName.Substring(0, playerName.Length);

        PlayerPrefs.SetString("InitialsEntered", playerInitials);
        //Debug.Log(playerInitials);
        //Debug.Log("final score: " + PlayerPrefs.GetFloat("totalScore"));
        SceneManager.LoadScene("HighScoresScene");

        //totalScore = PlayerPrefs.GetFloat("totalScore");
        //if (isHighScoresUpdated(playerInitials, totalScore))
        //{
        //    //displayHighScoresTextBox.gameObject.SetActive(true);
        //    displayScores();
        //}
    }

    public bool isHighScore(double yourScore)
    {
        string lowestScoreKey = "highScore" + (highScoreCount - 1);
        float lowestScore = PlayerPrefs.GetFloat(lowestScoreKey);
        if (yourScore >= lowestScore)
            return true;
        else
            return false;
    }

}
