using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour {

    public Text loadingText;
    public InputField name;
    public Canvas setNameCanvas;
    
    // Use this for initialization
    void Start () {        
        StartCoroutine(Progress());
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("name"))
        {
            setNameCanvas.GetComponent<Canvas>().enabled = false;
            SceneManager.LoadScene(1);
        }
        else
        {
            // nothing
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Progress()
    {
        while(true)
        {
            loadingText.GetComponent<Text>().text = loadingText.GetComponent<Text>().text+".";
            yield return new WaitForSeconds(1);
        }
       
    }

    public void SetName()
    {
        PlayerPrefs.SetString("name", name.ToString());
        SceneManager.LoadScene(1);
    }
}
