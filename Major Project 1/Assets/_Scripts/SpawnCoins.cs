using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour
{
    private static int coinTotal; 

	// Use this for initialization
	void Start ()
    {
        coinTotal = PlayerPrefs.GetInt("Coins");

	    //for (int i = 0; i < totalCoins; i++)
     //   {
     //       Vector2 randomPosition = new Vector2(Random.Range(coin1Left.position.x, coin1Right.position.x), Random.Range(coin1Left.position.y, coin1Right.position.y));
     //       Instantiate(coin, randomPosition, Quaternion.identity);
     //   }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollissionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player collided with spawnde coin");
            //coinAudio.Play();
            //obj = GameObject.FindGameObjectWithTag("Player");
            //coinAudio = obj.GetComponent<AudioSource>();

            //coinAudio.Play();
            Destroy(gameObject);
            coinTotal = coinTotal + 1;
            PlayerPrefs.SetInt("Coins", coinTotal);
            //scoreTextBox.text = "" + PlayerPrefs.GetInt("Coins");
        }
    }
}
