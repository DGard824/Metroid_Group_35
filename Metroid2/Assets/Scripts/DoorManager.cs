using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Author: [Gard, Dillon]
 * Date: [5/12/23]
 * [Handles scene transitions when door is collided with]
 */
public class DoorManager : MonoBehaviour
{
    //Defines the desired scene to be switched to
    public int sceneIndex;
    
    //Function for loading next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    
}
