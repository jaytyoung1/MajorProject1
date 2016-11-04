using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public Text levelText;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Fade");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator Fade()
    {
        for (float f = 3f; f >= 0; f -= 0.01f)
        {
            Color c = levelText.color;
            //Color c = renderer.material.color;
            c.a = f;
            levelText.color = c;
            yield return null;
        }
    }
}
