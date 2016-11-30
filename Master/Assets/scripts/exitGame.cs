using UnityEngine;
using UnityEngine.SceneManagement;
using SocketIOClient;
using System.Collections;

class Data {
    public float score;
    public int id;
}

public class exitGame : MonoBehaviour {

    Data data;

    string url = "http://52.79.59.114:3000/";
    public static Client Socket {
        get; private set;
    }

    public float score = .0f;

    private void Awake() {
        Socket = new Client(url);
        Socket.Connect();

        Socket.On("saved", (data) => {
            Debug.Log("[RECIVE SUCCESS] saved score Data : " + data.Json.args[0]);
            SocketClose();
        });
    }

    // Use this for initialization
    void Start() {
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
        data.score = score;
        Debug.Log("[DEBUG] send score data : "+data.score);
        Debug.Log("[DEBUG] send id data : " + data.id);
        Socket.Emit("savescore", data);
        SceneManager.LoadScene(1);
    }
}
