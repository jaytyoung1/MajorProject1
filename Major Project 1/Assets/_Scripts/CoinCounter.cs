using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    public Text scoreTextBox;
    private static int coinCount;

    //public AudioSource coinAudio;

    // Use this for initialization
    void Start ()
    {
        coinCount = 0;
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteKey("Coins");
        //maxTime = Time.time;
    }

    // Update is called once per frame
    void Update ()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //coinAudio.Play();
            //obj = GameObject.FindGameObjectWithTag("Player");
            //coinAudio = obj.GetComponent<AudioSource>();

            //coinAudio.Play();
            Destroy(gameObject);
            coinCount = coinCount + 1;
            PlayerPrefs.SetInt("Coins", coinCount);
            scoreTextBox.text = "" + PlayerPrefs.GetInt("Coins");
        }
    }

    public void resetCoins()
    {
        coinCount = 0;
        PlayerPrefs.SetInt("Coins", 0);
    }
}
