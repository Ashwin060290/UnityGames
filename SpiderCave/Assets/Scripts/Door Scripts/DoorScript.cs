using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public static DoorScript instance;
    [HideInInspector]
    public int collectableCount;

    private Animator anim;
    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;

        anim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	public void DecrementCollectables()
    {
        collectableCount--;

        if(collectableCount <= 0)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("DoorOpen");

        yield return new WaitForSeconds(0.7f);
        boxCollider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Game Finished");
        }
    }
}
