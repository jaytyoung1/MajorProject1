using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgroundTransforms; //array of transform positions
    private float[] parallaxScales;          //amount of movement for each layer that is moving as camera moves
    public float smoothing;
    private Vector3 previousCameraPosition;                 

	// Use this for initialization
	void Start ()
    {
        //set previousCameraPosition to current position
        previousCameraPosition = transform.position;

        parallaxScales = new float[backgroundTransforms.Length];

        //set parallaxScales[i] to background[i]'s negative z transform 
        for (int i = 0; i < parallaxScales.Length; i++)
            parallaxScales[i] = backgroundTransforms[i].position.z * -1;
	}

    void LateUpdate()
    {
        for (int i = 0; i < backgroundTransforms.Length; i++)
        {
            //how much movement we need to happen based on parallax scales & smoothing amount
            Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);  

            //add it on to current position for each background layer
            backgroundTransforms[i].position = new Vector3(backgroundTransforms[i].position.x + parallax.x, backgroundTransforms[i].position.y + parallax.y, backgroundTransforms[i].position.z);
        }

        //update camera position
        previousCameraPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
