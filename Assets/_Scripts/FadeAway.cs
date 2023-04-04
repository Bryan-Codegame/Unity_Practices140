using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (CountDownTimer))]
public class FadeAway : MonoBehaviour
{
    private CountDownTimer _countdownTimer;
    [SerializeField] Text textUI;

    // number of seconds before text completely fades away ...
    [SerializeField]private int startSeconds = 2;

    //---------------------------------
    void Awake ()
    {
    	// get reference to our screen text object & our scripted timer object
    	textUI = GetComponent<Text>();	
    	_countdownTimer = GetComponent<CountDownTimer>();
    }

    void Start()
    {
	    /*When we want to set the color of the material, it will change the general material
	     that was assigned to all of your UI components as default material which was created by Unity, 
	     therefore when you use textUI.material.color you are going to change the material color of all of your UI Components
	     regardless of where the script is instantiated, instead you have to use textUI.color to only change the text that you want 
	     */
	    
	    //We don't need this code, it´s just for demonstration.
	    //Try to change this code with another material color and will see that all of your components will set their color.
	    /*Color color = textUI.material.color;
	    color.a = 1.0f;
	    textUI.material.color = color;*/
	    
    	_countdownTimer.ResetTimer(startSeconds);
        
    }

    //---------------------------------
    void Update ()
    {
    	// get the time remaining as a float between 0.0 and 1.0
    	float alphaRemaining = _countdownTimer.GetProportionTimeRemaining();
    	print (alphaRemaining);
        //To change the color of the text that you want.
    	Color c = textUI.color;

    	// set alpha to our time remaining percentage
    	// so 1.0 means full text color, and 0.5 means half transparent and so on..
    	c.a = alphaRemaining;
    	textUI.color = c;
        
        
        int timeRemaining = _countdownTimer.GetSecondsRemaining();

        // get message based on seconds left
        string message = TimerMessage(timeRemaining);

        // update 'text' componnent of our UI Text object with string message
        textUI.text = message;
    }
    
    
    private string TimerMessage(int secondsLeft)
    {   
	    // if no seconds left, return timer finished message
	    if (secondsLeft < 0)
	    {
		    return "00";
	    } else {
		    // if 1 or more seconds left then build String message of seconds left
		    return secondsLeft.ToString();
	    }
    }
}
