using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Color[] colors = { Color.green, Color.blue, Color.red };
    public Text uiLevel;
    public Text uiTime;
    public Text uiScore;
    public Slider slideScore; //Handle max score eventually
    public RawImage life1; // I imagine there's a better way to do this, with GetChild or something, but we'll brute force it here
    public RawImage life2;
    public RawImage life3;

    private int score = 0;
    private int sessionScore = 0;
    private int lives = 3;
    private int numBalloons;
    private int level = 1;
    private int timeLimit;
    private float startTime;
    private int poppedBalloons = 0;
    private string gameOverReason;


    //Set up a singleton here
    static public Main S;

    public GameObject beePrefab;
    public Button playButton;

    private GameObject[] balloons;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (Main.S != null)
        {
            Main temp = Main.S;
            S = this;
            // The following is necessary because I didn't think through the implications of singleton programming and multiple scenes
            level = temp.getLevel();
            print(level);
            sessionScore = temp.GetScore();
            //startTime = temp.getStartTime();
            Destroy(temp);
        }
        else S = this;
        //print(PlayerInfo.P.userID); // Just testing
        startTime = Time.time;
        timeLimit = 240; // 4 minute time limit per session
        //timeLimit = 10; // Test value
        randBalloonColor(); // Will have to reuse this each scene
        print(numBalloons);
        DontDestroyOnLoad(gameObject);
    }

    public int getLevel()
    {
        return level;
    }


    //Function randomized balloon color, and also stores the total number of balloons found in scene
    void randBalloonColor()
    {
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        numBalloons = balloons.Length;
        foreach (GameObject balloon in balloons)
        {
            GameObject sphere = balloon.transform.GetChild(0).gameObject;
            Renderer sphereRenderer = sphere.GetComponent<Renderer>();
            //Material balloonColor = sphere.GetComponent<Material>();
            //Material balloonColor = balloon.GetComponentInChildren<Material>();
            //balloonColor.color = colors[(int)Random.Range(0,colors.Length)];
            sphereRenderer.material.SetColor("_Color", colors[(int)Random.Range(0, colors.Length)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused() == 0) resumeGame();
            else pauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        UpdateGui();
    }

    void pauseGame()
    {
        Time.timeScale = 0;
    }

    void resumeGame()
    {
        Time.timeScale = 1;
    }

    int isPaused()
    {
        return (int)Time.timeScale;
    }

    public void BalloonPop()
    {
        //Handle balloon popping here
        score += 100 / numBalloons; // Could decide on different max score per level, undetermined
        poppedBalloons++;
        if (poppedBalloons == numBalloons)
        {
            score = 100;
            sessionScore += score;
            NextLevel();
        }
    }
    public void BeeDied()
    {
        //playButton.enabled = true;
        playButton.gameObject.SetActive(true);
        if(lives == 1)
        {
            lives--;
            UpdateGui();
            //Handle GameOver scene here
            gameOverReason = "Lives";
            SceneManager.LoadScene("_End_Screen");
        }
        else if(lives > 1 && lives <= 3)
        {
            lives--;
            UpdateGui();
        }
        else
        {
            print("Error with lives logic");
        }
    }

    public void CreateBee()
    {
        //Destroy(nb);
        //playButton.enabled = false;
        playButton.gameObject.SetActive(false);
        GameObject player = Instantiate(beePrefab);
        player.transform.position = GameObject.Find("InitialPoint").transform.position;
    }

    void UpdateGui()
    {
        uiScore.text = "" + score;
        slideScore.value = score;
        uiLevel.text = "Level " + level;
        float timeLeft = timeLimit - (Time.time - startTime);
        if (timeLeft < 0)
        {
            OutOfTime();
        }
        int minutes = (int)timeLeft / 60;
        int seconds = (int)timeLeft - 60 * minutes;
        uiTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        DrawLives();
    }

    void DrawLives()
    {
        switch (lives)
        {
            case 0:
                life1.enabled = false;
                life2.enabled = false;
                life3.enabled = false;
                break;
            case 1:
                life1.enabled = true;
                life2.enabled = false;
                life3.enabled = false;
                break;
            case 2:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = false;
                break;
            case 3:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = true;
                break;
            default:
                break;
        }
    }

    void NextLevel()
    {
        level++;
        if(level > 3)
        {
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            string newLevel = "_level_" + level;
            SceneManager.LoadScene(newLevel);
        }
    }

    void OutOfTime()
    {
        gameOverReason = "Time";
        SceneManager.LoadScene("_End_Screen"); // Doesn't need it's own function but didn't want to handle it in a GUI update
    }

    public int GetScore()
    {
        return sessionScore;
    }
    public string GameOverReason()
    {
        return gameOverReason;
    }
}
