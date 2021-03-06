using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over_Script : MonoBehaviour
{
    public Text GameOverText;
    public Text feedbackText;
    string savePath = @".\SaveData\data.txt";
    string feedback = "";
    string reason = "Lives";
    int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (Main.S != null)
        {
            reason = Main.S.GameOverReason();
            score = Main.S.GetScore();
            Destroy(Main.S.gameObject); // Again, Singleton problems - reset with new game
        }
        //int score = Main.S.GetScore();
        //int score = 0;
        int hi = 0;
        
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hi = PlayerPrefs.GetInt("HighScore");
            if (score > hi) PlayerPrefs.SetInt("HighScore", score);
        }
        else PlayerPrefs.SetInt("HighScore", score);
        if (reason == "Win") 
        {
            Camera cam = GetComponent<Camera>();
            cam.backgroundColor = Color.green;
            GameOverText.text = "You've won! You have the biggest brain! You scored " + score + " points! The highest score was " + hi + "!";
        }
        else if (reason == "Lives")
        {
            GameOverText.text = "You've run out of lives. Too bad! You scored " + score + " points! The highest score was " + hi + "!";
        }
        else
        {
            GameOverText.text = "You've run out of time. Too bad! You scored " + score + " points! The highest score was " + hi + "!";
            //GameOverText.text = "You've run out of time. Too bad! You scored " + 0 + " points! The highest score was " + hi + "!";

        }
        if (score > hi)
        {
            GameOverText.text = GameOverText.text + " You beat the previous high score!\n";
        }
        if(!Directory.Exists(@".\SaveData\"))
        {
            Directory.CreateDirectory(@".\SaveData\"); // Probably a way to parse directory from save path buuuut...
        }
        if (!File.Exists(savePath))
        {
            using (StreamWriter sw = File.CreateText(savePath))
            {
                sw.WriteLine("uID: " + PlayerInfo.P.userID + " TimeOfDayPlayed: " + PlayerInfo.P.playTime + " Score: " + score);
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(savePath))
            {
                sw.WriteLine("uID: " + PlayerInfo.P.userID + " TimeOfDayPlayed: " + PlayerInfo.P.playTime + " Score: " + score);
            }
        }
    }

    public void submitFeedback()
    {
        feedback = feedbackText.text;
        if (!File.Exists(savePath))
        {
            using (StreamWriter sw = File.CreateText(savePath))
            {
                sw.WriteLine("uID: " + PlayerInfo.P.userID + " Feedback: " + feedback);
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(savePath))
            {
                sw.WriteLine("uID: " + PlayerInfo.P.userID + " Feedback: " + feedback);
            }
        }
    }


    public void NewGame()
    {

        SceneManager.LoadScene("_Start_Scene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
