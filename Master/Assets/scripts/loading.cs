using UnityEngine;
using System;
using System.Collections;
using SocketIOClient;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour {

    public Text loadingText;
    public InputField name;
    public Canvas setNameCanvas;

    string url = "http://game-server-parkjunhyuk.c9users.io:8080/";
    public static Client Socket {
        get; private set;
    }

    private void Awake() {
        if (!PlayerPrefs.HasKey("name")) {
            Socket = new Client(url);
            Socket.Connect();

            Socket.On("Login", (data) => {
                Debug.Log("[RECIVE SUCCESS] Login User id : " + data.Json.args[0]);
                int a = int.Parse(data.Json.args[0].ToString());
                Global.userId = a;
                SocketClose();
            });
        }
    }

    // Use this for initialization
    void Start () {        
        StartCoroutine(LoadDataAndSet());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SocketClose() {
        Socket.Close();
        Socket = null;
    }

    IEnumerator LoadDataAndSet()
    {
        if (PlayerPrefs.HasKey("name"))
        {
            setNameCanvas.GetComponent<Canvas>().enabled = false;
            Global.userId = PlayerPrefs.GetInt("id");
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
        Socket.Emit("Login", Global.userName);        
        SceneManager.LoadScene(1);
    }
}
