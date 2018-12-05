using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerScript : MonoBehaviour {

    private Slider timeSlider;
    private GameObject player;

    public float time = 10f;

    private float timeBurn = 1f;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("Player");
        timeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();

        timeSlider.maxValue = time;
        timeSlider.minValue = 0f;
        timeSlider.value = timeSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
            return;

        if (time > 0)
        {
            time -= timeBurn * Time.deltaTime;
            timeSlider.value = time;
        }
        else
        {
            Destroy(player);
        }

    }
}
