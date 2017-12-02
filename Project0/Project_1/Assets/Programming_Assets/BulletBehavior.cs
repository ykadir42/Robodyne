using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    Collider coll;
    public GameObject emitter;

	// Use this for initialization
	void Start () {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        try {
            other.GetComponent<EnemyBehavior>().health -= 40;
        }
        catch (System.Exception) {
            
        }
        Explode();
    }

    private void Explode() {
        Debug.Log("BOOM!");
        Instantiate(emitter, transform.position, transform.rotation);
        //Destroy(this.transform.gameObject);
    }
}
