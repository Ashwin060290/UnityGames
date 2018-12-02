using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterScript : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;


    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.RandomRange(2, 7));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
        }
    }
}
    