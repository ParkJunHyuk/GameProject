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
        StartCoroutine(LoadDataAndSet());        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator LoadDataAndSet()
    {
        if (PlayerPrefs.HasKey("name"))
        {
            setNameCanvas.GetComponent<Canvas>().enabled = false;
            Global.userName = PlayerPrefs.GetString("name");
            Global.money = PlayerPrefs.GetInt("money");
            Global.energy = PlayerPrefs.GetInt("energy");
            Global.ruby = PlayerPrefs.GetInt("ruby");
            SceneManager.LoadScene(1);
        }
        else
        {
            Global.energy = 5;
            Global.money = 0;
            Global.ruby = 0;
        }
        yield return new WaitForSeconds(1);
    }

    public void SetName()
    {
        Global.userName = name.text;
        PlayerPrefs.SetString("name", name.text);
        SceneManager.LoadScene(1);
    }
}
