using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeButton : MonoBehaviour
{
    Button beeButton;
    RectTransform beeButtonRect;
    public RectTransform canvas;


    // Start is called before the first frame update
    void Start()
    {
        beeButton = this.GetComponent<Button>();
        beeButtonRect = beeButton.GetComponent<RectTransform>();
        //Vector2 newPos;
        Vector3 worldPoint = GameObject.Find("InitialPoint").transform.position;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(beeButtonRect, worldPoint, Camera.main, out newPos);
        Vector2 initPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPoint);
        beeButtonRect.anchoredPosition = initPoint - canvas.sizeDelta / 2f;
        //beeButtonRect.position = newPos;
        //transform.position = GameObject.Find("InitialPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
