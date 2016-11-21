using UnityEngine;
using SocketIOClient;
using System.Collections;

public class server : MonoBehaviour {

    string url = "http://127.0.0.1:3000/";
    public static Client Socket {
        get; private set;
    }

    private void Awake() {
        Socket = new Client(url);
        Socket.Connect();
    }

	// Use this for initialization
	void Start () {
        Socket.On("MsgRes", (data) =>
        {
            Debug.Log(data.Json.args[0]);
        });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnApplicationQuit()
    {
        Socket.Close();
        Socket = null;
    }

    public void serverTest() {
        Socket.Emit("Msg", "I can send data to nodejs server");
    } 
}
