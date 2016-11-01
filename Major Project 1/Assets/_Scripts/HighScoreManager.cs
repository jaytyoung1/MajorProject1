using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    private float finalScore;
    public const int highScoreCount = 10;

    //public InputField initialsInputField;
    public Text highScoreTextBox;

    // Use this for initialization
    void Start ()
    {
        displayScores();
        //Debug.Log("final score: " + PlayerPrefs.GetFloat("totalScore"));
        finalScore = PlayerPrefs.GetFloat("totalScore");
        string initialsEntered = PlayerPrefs.GetString("InitialsEntered");

        //Debug.Log("final score: " + finalScore + "\ninitials: " + initialsEntered);
        if (isHighScoresUpdated(initialsEntered, finalScore))
        {
            Debug.Log("isHighScoreUpdated = true");
            //displayHighScoresTextBox.gameObject.SetActive(true);
            displayScores();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public bool isHighScoresUpdated(string yourInitials, float yourScore)
    {
        float scoreInTopTen = 0.0f;
        string scoreKey = "";
        string initialsKey = "";
        for (int i = 0; i < highScoreCount; i++)
        {
            scoreKey = "highScore" + i;
            initialsKey = "initials" + i;
            scoreInTopTen = PlayerPrefs.GetFloat(scoreKey);
            if (yourScore >= scoreInTopTen)
            {
                insertYourScore(yourScore, i, scoreKey, initialsKey, yourInitials);
                return true;
            }
        }
        return false;
    }

    public void insertYourScore(float yourScore, int index, string scoreKey, string initialsKey, string initials)
    {
        string tempInitialsKey = "";
        string tempInitialsVal = "";
        string tempInitialsKey2 = "";
        string tempInitialsVal2 = "";

        string tempStringKey = "";
        float tempStringVal = 0.0f;
        string tempStringKey2 = "";
        float tempStringVal2 = 0.0f;

        for (int i = index; i < highScoreCount; i++)
        {
            tempStringKey = "highScore" + i;
            tempInitialsKey = "initials" + i;
            //int tempStringVal;
            if (i == index)
            {
                tempStringVal = PlayerPrefs.GetFloat(tempStringKey);
                tempInitialsVal = PlayerPrefs.GetString(tempInitialsKey);

            }
            else
            {
                tempStringVal = tempStringVal2;
                tempInitialsVal = tempInitialsVal2;
            }

            tempStringKey2 = "highScore" + (i + 1);
            tempStringVal2 = PlayerPrefs.GetFloat(tempStringKey2);

            tempInitialsKey2 = "initials" + (i + 1);
            tempInitialsVal2 = PlayerPrefs.GetString(tempInitialsKey2);

            PlayerPrefs.SetFloat(tempStringKey2, tempStringVal);
            PlayerPrefs.SetString(tempInitialsKey2, tempInitialsVal);
        }
        PlayerPrefs.SetFloat(scoreKey, yourScore);
        PlayerPrefs.SetString(initialsKey, initials);
    }

    public void displayScores()
    {
        string scoreStr = "";
        for (int i = 0; i < highScoreCount; i++)
        {
            string scoreKey = "highScore" + i;
            string initialsKey = "initials" + i;

            //string initials = PlayerPrefs.GetString(initialsKey);
            //int initialsLength = initials.Length;

            if (i == 0)
                scoreStr = scoreStr + (string.Format("{0, 13}", (i + 1))) + "." + (string.Format("{0, 12}", PlayerPrefs.GetString(initialsKey))) + (string.Format("{0, 12}", PlayerPrefs.GetFloat(scoreKey))) + "\n";
            else
                scoreStr = scoreStr + (string.Format("{0, 12}", (i + 1))) + "." + (string.Format("{0, 12}", PlayerPrefs.GetString(initialsKey))) + (string.Format("{0, 12}", PlayerPrefs.GetFloat(scoreKey))) + "\n";
        }
        highScoreTextBox.text = scoreStr;
        //highScoresTextBox.text = scoreStr;
    }

    public void restartGame()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("totalScore");
        PlayerPrefs.DeleteKey("InitialsEntered");
        SceneManager.LoadScene("Demo3_GameScene");
    }

    public void goToMainMenu()
    {
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("totalScore");
        PlayerPrefs.DeleteKey("InitialsEntered");
        SceneManager.LoadScene("WelcomeScene");
    }

    public void resetHighScores()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("HighScoresScene");
    }






    //public void intialsEntered()
    //{
    //    string playerName = initialsInputField.text;
    //    string playerInitials = "";
    //    if (playerName.Length >= 3)
    //        playerInitials = playerName.Substring(0, 3);
    //    else
    //        playerInitials = playerName.Substring(0, playerName.Length);

    //    Debug.Log(playerInitials);
    //    Debug.Log("final score: " + PlayerPrefs.GetFloat("totalScore"));

    //if (isHighScore(finalScore))
    //{
    //    if (isHighScoresUpdated(playerInitials, finalScore))
    //    {
    //        displayHighScoresTextBox.gameObject.SetActive(true);
    //        displayScores();
    //    }
    //}
    //}

    //public bool isHighScore(int yourScore)
    //{
    //    string lowestScoreKey = "highScore" + (highScoreCount - 1);
    //    int lowestScore = PlayerPrefs.GetInt(lowestScoreKey);
    //    if (yourScore >= lowestScore)
    //        return true;
    //    else
    //        return false;
    //}
}

