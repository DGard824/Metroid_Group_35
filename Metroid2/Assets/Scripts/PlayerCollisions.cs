using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Author: [Dillon Gard, Aga Megia]
 * Date: [5/12/23]
 * [Manages the collisions between the player and enemies/items]
 */
public class PlayerCollisions : MonoBehaviour
{
    //Defines the health of the player
    public int health = 99;
    //Bool for damageBlink function
    public bool isInvincible;
    //Defines the Canvas UI
    public UIManager uimanager;
    //Defines the visor of the player model
    public GameObject visor;
    //Defines the body of the player model
    public GameObject body;
    //Defines the head of the player model
    public GameObject head;
    //Defines the gun of the player model
    public GameObject gun;
    //Defines the portal at the end of the levels
    public GameObject levelPortal;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //If R is pushed...
        if (Input.GetKey("r"))
        {
            //Take the player back to the main menu
            SceneManager.LoadScene(0);
        }

        //If health is 0...
        if (health <= 0)
        {
            //Display 0 health on screen
            uimanager.health_text.text = "Health: 0";
            //Disable movement of player
            GetComponent<Playermovement>().enabled = false;
            //Disable the mesh renderers of the player model
            visor.GetComponent<MeshRenderer>().enabled = false;
            head.GetComponent<MeshRenderer>().enabled = false;
            gun.GetComponent<MeshRenderer>().enabled = false;
            body.GetComponent<MeshRenderer>().enabled = false;
            //Display Game Over text
            uimanager.gameOver_text.text = "Game Over";
            //Display Return text
            uimanager.returnText.text = "R - Main Menu";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player collides with a portal...
        if (other.transform.tag == "Portal")
        {
            //Take player to next level
            levelPortal.GetComponent<DoorManager>().LoadNextScene();
        }


        //Checks to see if the player is already invincible
        if (isInvincible == false)
        {
            //If the player runs into a Enemy...
            if (other.transform.tag == "Enemy")
            {
                //Reduce health by 15 and activate the damage blink
                health -= 15;
                updateHealth();
                StartCoroutine(damageBlink());

            }
            //If player runs into HardEnemy...
            if (other.transform.tag == "HardEnemy")
            {
                //Reduce health by 65 and activate the damage blink
                health -= 65;
                updateHealth();
                StartCoroutine(damageBlink());

            }
        }
        
    }

    private IEnumerator damageBlink()
    {
        //Sets player as invincible
        isInvincible = true;

        //For 10 instances...
        for (int index = 0; index < 10; index++)
        {
            
            //If index is even, disable the players mesh renderer
            if (index % 2 == 0)
            {
                //Disables mesh renders of each body part
                visor.GetComponent<MeshRenderer>().enabled = false;
                head.GetComponent<MeshRenderer>().enabled = false;
                gun.GetComponent<MeshRenderer>().enabled = false;
                body.GetComponent<MeshRenderer>().enabled = false;
            }
            //If index is odd, enable the player's mesh renderer
            else
            {
                //Enable mesh renderers of each body part
                visor.GetComponent<MeshRenderer>().enabled = true;
                head.GetComponent<MeshRenderer>().enabled = true;
                gun.GetComponent<MeshRenderer>().enabled = true;
                body.GetComponent<MeshRenderer>().enabled = true;
            }
            //Wait for specified amount of time, then continue and change state again
            yield return new WaitForSeconds(0.2f);
        }
        //Ensure that mesh renderer ends up activated
        GetComponent<MeshRenderer>().enabled = true;
        //Resets isInvincible to false
        isInvincible = false;
    }
    //Updates health display on screen
    private void updateHealth()
    {
        uimanager.health_text.text = "Health:" + health;

    }

    
}
