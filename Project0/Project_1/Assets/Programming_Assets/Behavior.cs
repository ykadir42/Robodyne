using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {

    //stats
    protected int health;
    protected int speed;
    protected int rotationSpeed;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Live();
	}

    void Live() {
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("You ded");
    }

    void Damage(int amt) {
        if (amt < 0) {
            return;
        }
        health -= amt;

		Debug.Log ("");
    }
}
