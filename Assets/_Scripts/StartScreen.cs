using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public InputField userID;
    public Button startButton;
    public static string uID;

    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(userID.text != "")
        {
            startButton.interactable = true;
        }
    }

    public void StartGame()
    {
        PlayerInfo.P.setInfo(userID.text, Time.time);
        uID = userID.text;
        SceneManager.LoadScene("_Level_1");
    }
}
