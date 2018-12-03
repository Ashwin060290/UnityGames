using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{


    void Start()
    {
        if (DoorScript.instance != null)
            DoorScript.instance.collectableCount++;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            if (DoorScript.instance != null)
            {
                DoorScript.instance.DecrementCollectables();
            }
        }
    }
}
