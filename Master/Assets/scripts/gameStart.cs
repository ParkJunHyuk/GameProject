using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class gameStart : MonoBehaviour {

    public Text nameText;

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.HasKey("name"))
        {
            string test = PlayerPrefs.GetString("name");
            nameText.GetComponent<Text>().text = test;
        }
        int a = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
