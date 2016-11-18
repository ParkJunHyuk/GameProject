using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class exitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
