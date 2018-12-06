using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimerScript : MonoBehaviour {

    private Slider airSlider;
    private GameObject player;

    public float air = 10f;

    private float airBurn = 1f;
	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        airSlider = GameObject.Find("AirSlider").GetComponent<Slider>();

        airSlider.maxValue = air;
        airSlider.minValue = 0f;
        airSlider.value = airSlider.maxValue;
	}
	
	// Update is called once per frame
	void Update () {

        if (player == null)
            return;

        if(air > 0)
        {
            air -= airBurn * Time.deltaTime;
            airSlider.value = air;
        }
        else
        {
            GetComponent<GamePlayScript>().PlayerDied();
            Destroy(player);
        }
       
	}
}
