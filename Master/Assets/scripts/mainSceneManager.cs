﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class mainSceneManager : MonoBehaviour {

    public Text nameText;
    public Text energyText;
    public Text moneyText;
    public Text rubyText;

    // Use this for initialization
    void Start () {
        
        StartCoroutine(UserDataSave());    
        energyText.GetComponent<Text>().text = Global.energy.ToString();
        moneyText.GetComponent<Text>().text = Global.money.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        energyText.GetComponent<Text>().text = Global.energy.ToString();
        moneyText.GetComponent<Text>().text = Global.money.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
            

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                Global.playCharacter = hit.transform.gameObject.name;
            }
        }
    }

    public void StartGame()
    {
        if(Global.energy > 0)
        {
            Global.energy -= 1;
            SceneManager.LoadScene(2);
        }
        else
        {

        }        
        
    }
    public void ShowAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show("rewardedVideo",options);
        }
        else
        {
            Debug.LogWarning("rewardedVideo not Ready");
        }

        
    }

    public IEnumerator UserDataSave()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            PlayerPrefs.SetInt("id", Global.userId);
            PlayerPrefs.SetInt("energy", Global.energy);
            PlayerPrefs.SetInt("money", Global.money);
            PlayerPrefs.SetInt("ruby", Global.ruby);
            PlayerPrefs.Save();
        }       
    }

    public void UserDataDel()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Application.Quit();
    }

    private static void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown");
                Global.money += 1000;
                Global.ruby += 1;
                Global.energy += 1;
                PlayerPrefs.SetInt("energy", Global.energy);
                PlayerPrefs.SetInt("money", Global.money);
                PlayerPrefs.SetInt("ruby", Global.ruby);
                PlayerPrefs.Save();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("The ad was failed to be shown");
                break;
            default:
                break;
        }
    }
}
