using UnityEngine;
using System.Collections;

public class modeCube : MonoBehaviour {

    public Transform cube;
    public GameObject[] clone;
    public int Speed=3;
    public static int NUM = 13;
    
	// Use this for initialization
	void Start () {
        clone = new GameObject[NUM];
        for(int i=0; i< NUM; i++) {
            Transform temp;
            temp = Instantiate(cube, new Vector3(0, i * 0.5f, i * 0.5f), Quaternion.identity) as Transform;
            clone[i] = temp.gameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < NUM; i++) {
            clone[i].transform.localPosition = new Vector3(0.0f, clone[i].transform.localPosition.y + 0.008f, clone[i].transform.localPosition.z + 0.008f);
            if (clone[i].transform.localPosition.y > 4.5f)
            {
                clone[i].transform.localScale = new Vector3(clone[i].transform.localScale.x, clone[i].transform.localScale.y - 0.002f, clone[i].transform.localScale.z);
            }
            else if (clone[i].transform.localPosition.y < 0.5f)
            {
                clone[i].transform.localScale = new Vector3(clone[i].transform.localScale.x, clone[i].transform.localScale.y + 0.002f, clone[i].transform.localScale.z);
            }
            if (clone[i].transform.localPosition.y > 5.0f) {
                clone[i].transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
