using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public int health = 99;
    public bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks to see if the player is already invincible
        if (isInvincible == false)
        {
            //If the player runs into a RegularEnemy...
            if (other.transform.tag == "RegularEnemy")
            {
                //Reduce health by 15 and activate the damage blink
                health = 15;
                StartCoroutine(damageBlink());

            }
        }
        
    }

    private IEnumerator damageBlink()
    {
        //Sets player as invincible
        isInvincible = true;

        for (int index = 0; index < 10; index++)
        {
            
            //If index is even, disable the players mesh renderer
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            //If index is odd, enable the player's mesh renderer
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            //Wait for specified amount of time, then continue and change state again
            yield return new WaitForSeconds(0.2f);
        }
        
        GetComponent<MeshRenderer>().enabled = true;
        //Resets isInvincible to false
        isInvincible = false;
    }
}
