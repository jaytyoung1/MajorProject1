using UnityEngine;
using System.Collections;

public class PlatformMove : MonoBehaviour
{
    private float leftLimit = -1.9f;
    private float rightLimit = 1.9f;
    public float speed = 1.5f;
    private int direction = 1;
    private Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > rightLimit)
            direction = -1;
        else if (transform.position.x < leftLimit)
            direction = 1;

        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
	}
}
