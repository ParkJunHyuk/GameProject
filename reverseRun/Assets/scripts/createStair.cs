using UnityEngine;
using System.Collections;

public class createStair : MonoBehaviour {

    public Transform stair;
    public GameObject[] rightStairArray;
    public GameObject[] leftStairArray;
    public Transform temp;

    public static int STAIR_NUM = 20;
    public float waitingTime;
    public bool live = true;

    const float STAIR_HIGHT = 0.006f;
    const float STAIR_WIDTH = 0.01f;
    const float LEFT_STAIR_START_Z = 0.034f;

    // Use this for initialization
    void Start () {
        rightStairArray = new GameObject[STAIR_NUM];
        leftStairArray = new GameObject[STAIR_NUM];        

        for (int x = 0; x < STAIR_NUM; x++)
        {
            temp = Instantiate(stair, new Vector3( x * STAIR_WIDTH, x * STAIR_HIGHT, 0 ), Quaternion.identity) as Transform;
            rightStairArray[x] = temp.gameObject;
            rightStairArray[x].transform.Rotate(new Vector3(-90, 0, 0));
        }

        for (int x = STAIR_NUM - 1 ; x >= 0; x--)
        {
            temp = Instantiate(stair, new Vector3(x * STAIR_WIDTH, x * STAIR_HIGHT, LEFT_STAIR_START_Z), Quaternion.identity) as Transform;
            leftStairArray[x] = temp.gameObject;
            leftStairArray[x].transform.Rotate(new Vector3(-90, 0, 0));
        }

        StartCoroutine(MoveRightStair());
        StartCoroutine(MoveLeftStair());
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator MoveRightStair()
    {
        while(live)
        {
            for (int x = 0; x < STAIR_NUM; x++)
            {
                rightStairArray[x].transform.localPosition = new Vector3(rightStairArray[x].transform.localPosition.x + (STAIR_WIDTH / 10), rightStairArray[x].transform.localPosition.y + (STAIR_HIGHT / 10), 0.0f);
                if (rightStairArray[x].transform.localPosition.y > STAIR_NUM * STAIR_HIGHT)
                {
                    rightStairArray[x].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }          
            yield return new WaitForSeconds(waitingTime);
        }
    }
    IEnumerator MoveLeftStair()
    {
        while (live)
        {
            for (int x = 0; x < STAIR_NUM; x++)
            {
                leftStairArray[x].transform.localPosition = new Vector3(leftStairArray[x].transform.localPosition.x - (STAIR_WIDTH / 10), leftStairArray[x].transform.localPosition.y - (STAIR_HIGHT / 10), 0.034f);
                if (leftStairArray[x].transform.localPosition.y < 0)
                {
                    leftStairArray[x].transform.localPosition = new Vector3((STAIR_NUM - 1) * STAIR_WIDTH, (STAIR_NUM-1) * STAIR_HIGHT, LEFT_STAIR_START_Z);
                }
            }
            yield return new WaitForSeconds(waitingTime);
        }

    }
}
