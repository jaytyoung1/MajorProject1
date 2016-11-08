using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoNotDestroyPlayer : MonoBehaviour {

	void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length > 1)
            Destroy(this.gameObject);
       
        if ((SceneManager.GetActiveScene().name == "Level 1") || (SceneManager.GetActiveScene().name == "Level 2"))
            DontDestroyOnLoad(this.gameObject);
    }
}
