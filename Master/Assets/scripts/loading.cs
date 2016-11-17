using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class loading : MonoBehaviour {

    public Text loadingText;
    
    // Use this for initialization
    void Start () {
        StartCoroutine(Progress());
        StartCoroutine(ChangeScene());
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

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}
