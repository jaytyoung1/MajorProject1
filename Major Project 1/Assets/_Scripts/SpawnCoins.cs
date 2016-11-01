using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour
{
    public int totalCoins = 3;
    public Transform coin1Left;
    public Transform coin1Right;
    public GameObject coin;

	// Use this for initialization
	void Start ()
    {
	    for (int i = 0; i < totalCoins; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(coin1Left.position.x, coin1Right.position.x), Random.Range(coin1Left.position.y, coin1Right.position.y));
            Instantiate(coin, randomPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
