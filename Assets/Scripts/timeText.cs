using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;


//make sure that the specified fields are filled and basically 
public class timeText : MonoBehaviour
{
    public TextMeshProUGUI tex; 
    public GameObject t; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t.SetActive(false);
        tex.text=$"{Math.Round(time.timeLeft,2)}s";
    }

    // Update is called once per frame
    void Update()
    {
        tex.text=$"{Math.Round(time.timeLeft,2)}s";
    }

    void OnEnable()
    {
        sinkTrigger.waterStart += textshow;
    } 

    void textshow()
    {
        t.SetActive(true);
    }
}
