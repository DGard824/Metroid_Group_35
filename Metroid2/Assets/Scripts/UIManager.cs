using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text health_text;
    public Text gameOver_text;


    // Start is called before the first frame update
    void Start()
    {
        health_text.text = "Health: 99";
        gameOver_text.text = "";
    }

    
}
