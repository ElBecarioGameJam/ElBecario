using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float secondsCount;
    private int minuteCount;
   
    //call this on update
    public void Update()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text =  minuteCount + "m: " + (int)secondsCount + " s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}
