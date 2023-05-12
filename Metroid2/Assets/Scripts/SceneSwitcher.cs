using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Author: [Dillon Gard, Aga Megia]
 * Date: [5/12/23]
 * [Scene switcher script for main menu]
 */
public class SceneSwitcher : MonoBehaviour
{
    //When button is pressed, the button will execute this function to switch the scene
    public void ButtonMoveScene(string screen)
    {
        SceneManager.LoadScene(screen);
    }
}
