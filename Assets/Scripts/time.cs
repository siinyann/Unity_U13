using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public float maxTime = 10f;
    public static float timeLeft;
    bool countdown= false;

    public GameObject s; 
    [SerializeField]
    private Slider sl;

    void Start()
    {
        timeLeft=maxTime;
        s.SetActive(false);

        sl.minValue = 0;
        sl.maxValue = maxTime;
        sl.value = maxTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown==true)
        {
            sl.value=timeLeft;
            timeLeft-=Time.deltaTime;
            if (timeLeft==0)
            {
                playerController.PlayerDie();
            }
        }
    }

    void OnEnable()
    {
        sinkTrigger.waterStart += timeshow;
        playerController.playerDie += timestop;
    } 

    void timeshow()
    {
        s.SetActive(true);
        countdown=true;
    }

    void timestop()
    {
        countdown=false;
    }
}
