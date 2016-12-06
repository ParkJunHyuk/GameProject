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
    public bool logined = false;
    public bool network = false;

    string url = "http://www.lnpj.nl:3000/";
    public static Client Socket {
        get; private set;
    }

    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {        
        StartCoroutine(LoadDataAndSet());

        if (!PlayerPrefs.HasKey("name"))
        {
            Socket = new Client(url);

            Socket.On("Login", (data) => {
                logined = true;

                Debug.Log("[RECIVE SUCCESS] Login User id : " + data.Json.args[0]);
                int a = int.Parse(data.Json.args[0].ToString());
                Global.userId = a;
                SocketClose();
            });
        }
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
            if (logined)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                if (network)
                {
                    //에러팝업
                    network = false;
                }

            }
        }
        yield return new WaitForSeconds(0.5f);
    }

    public void SetName()
    {
        Socket.Connect();

        Global.userName = name.text;        
        PlayerPrefs.SetString("name", name.text);
        Socket.Emit("Login", Global.userName);
        network = true;     
    }
}
