using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over_Time : MonoBehaviour
{
    public Text GameOverText;

    // Start is called before the first frame update
    void Awake()
    {
        GameOverText.text = "You've run out of time. Too bad! You scored " + Main.S.GetScore() +" points!";
    }

    public void NewGame()
    {
        SceneManager.LoadScene("_Start_Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
