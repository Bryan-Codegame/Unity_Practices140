using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class DigitalCountDown : MonoBehaviour
{
    // reference to UI Text object whose text we'll update with countdowm message
    private Text textClock;

    // how many seconds to count down from
    private CountDownTimer _countdownTimer;

    //---------------------------------
    void Awake()
    {
        // get reference to Text component inside our parent GameObject
        textClock = GetComponent<Text>();

        // get reference to CountdownTimer object
        _countdownTimer = GetComponent<CountDownTimer>();
    }

    //---------------------------------
    void Start()
    {
        // reset countdown timer to start from 30 seconds
        _countdownTimer.ResetTimer(10);
    }

    //---------------------------------
    void Update ()
    {
        // get seconds remaining (as a whole number)
        int timeRemaining = _countdownTimer.GetSecondsRemaining();

        // get message based on seconds left
        string message = TimerMessage(timeRemaining);

        // update 'text' componnent of our UI Text object with string message
        textClock.text = message;
    }

    //---------------------------------
    private string TimerMessage(int secondsLeft)
    {   
        // if no seconds left, return timer finished message
        if (secondsLeft < 0){
            return "countdown has finished";
        } else {
            // if 1 or more seconds left then build String message of seconds left
            return "Countdown seconds remaining = " + secondsLeft;
        }
    }
}
