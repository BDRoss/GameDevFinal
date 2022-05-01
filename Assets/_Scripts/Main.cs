using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Color[] colors = { Color.green, Color.blue, Color.red };
    
    //Set up a singleton here
    static public Main S;

    public GameObject beePrefab;
    public Button playButton;

    private GameObject[] balloons;
    

    // Start is called before the first frame update
    void Awake()
    {
        S = this;
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        foreach (GameObject balloon in balloons)
        {
            GameObject sphere = balloon.transform.GetChild(1).gameObject;
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
        
    }

    public void BeeDied()
    {
        //playButton.enabled = true;
        playButton.gameObject.SetActive(true);
        //Instantiate(playButtonPrefab);
        //GameObject player = Instantiate(beePrefab);
        //player.transform.position = GameObject.Find("InitialPoint").transform.position;
    }

    public void CreateBee()
    {
        //Destroy(nb);
        //playButton.enabled = false;
        playButton.gameObject.SetActive(false);
        GameObject player = Instantiate(beePrefab);
        player.transform.position = GameObject.Find("InitialPoint").transform.position;
    }
}
