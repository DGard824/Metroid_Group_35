using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
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
        if (other.transform.tag == "PlayerProjectile")
        {
            gameObject.SetActive(false);
        }
        if (other.transform.tag == "PlayerProjectileHeavy")
        {
            gameObject.SetActive(false);
        }
    }
}
