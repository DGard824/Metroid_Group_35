using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: [Dillon Gard, Aga Megia]
 * Date: [5/12/23]
 * [Manages the UI text elements on screen]
 */
public class UIManager : MonoBehaviour
{
    //Defines health text
    public Text health_text;
    //Defines game over text
    public Text gameOver_text;
    //Defines the Press R text
    public Text returnText;
    //Defines jetpack alert text
    public Text jetpackText;


    // Start is called before the first frame update
    void Start()
    {
        //Display starting health and make everything else invisible
        health_text.text = "Health: 99";
        gameOver_text.text = "";
        returnText.text = "";
        jetpackText.text = "";
    }

    
}
