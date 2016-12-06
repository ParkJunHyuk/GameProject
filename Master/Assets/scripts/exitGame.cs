using UnityEngine;
using UnityEngine.SceneManagement;
using SocketIOClient;
using System.Collections;

class Data {
    public float score;
    public int id = 0;
}

public class exitGame : MonoBehaviour {

    Data data;

    string url = "http://www.lnpj.nl:3000/";
    public static Client Socket {
        get; private set;
    }

    public float score = .0f;

    private void Awake() {
        
    }

    // Use this for initialization
    void Start() {
        Socket = new Client(url);

        Socket.On("saved", (data) => {
            Debug.Log("[RECIVE SUCCESS] saved score Data : " + data.Json.args[0]);
            SocketClose();
        });
        setJson();
    }

    // Update is called once per frame
    void Update() {
        score += 0.01f;
    }

    public void setJson()
    {
       var json = @"{""score"":""0"", ""id"":" + Global.userId + "}";
       data = JsonUtility.FromJson<Data>(json);
    }

    public void SocketClose() {
        Socket.Close();
        Socket = null;
    }

    public void BackButtonClick()
    {
        Socket.Connect();

        data.score = score;
        Debug.Log("[DEBUG] send score data : "+data.score);
        Debug.Log("[DEBUG] send id data : " + data.id);
        Socket.Emit("savescore", data);
        SceneManager.LoadScene(1);
    }
}
