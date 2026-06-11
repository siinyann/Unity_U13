using System;
using UnityEngine;

public class sinkTrigger : MonoBehaviour
{
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action waterStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hi");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("tripped_sink");
            waterStart?.Invoke();
        }
    }

}
