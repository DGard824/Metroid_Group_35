using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    //GameObject for the player projectile
    public GameObject playerProjectile;
    //Bool to define shot cooldown
    public bool ableToShoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            SpawnProjectile();

        }
    }

    //Spawns the player projectile
    private void SpawnProjectile()
    {
        //If the player is able to shoot after the cooldown...
        if (ableToShoot)
        {
            //Spawns the player projectile
            Instantiate(playerProjectile, transform.position, playerProjectile.transform.rotation);
            //Makes it so the player can't shoot again until cooldown is over
            ableToShoot = false;
            //Starts cooldown
            StartCoroutine(ProjectileCooldown());
            
        }

        



    }
    //Once a projectile is shot, they player must wait 1 second before shooting again
    private IEnumerator ProjectileCooldown()
    {



        yield return new WaitForSeconds(1);
        ableToShoot = true;


    }
}
