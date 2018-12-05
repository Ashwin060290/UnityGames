using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAirScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(gameObject.tag == "Air")
            {
                GameObject.Find("GamePlayController").GetComponent<AirTimerScript>().air += 15f;               
            }
            if(gameObject.tag == "Time")
            {
                GameObject.Find("GamePlayController").GetComponent<LevelTimerScript>().time += 15f;
            }
            Destroy(gameObject);
        }
    }
}
