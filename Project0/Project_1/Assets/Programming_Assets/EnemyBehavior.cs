using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    //Stats
    public int health = 50;
    public int speed;
	public int omega;
	public GameObject targetWaypoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		move ();
        Live();

	}

	void move() {
		transform.Translate (transform.forward * speed * Time.deltaTime);
		Vector3 target = targetWaypoint.transform.position;
		Vector2 deltaDist = new Vector2 (target.z - transform.position.z, target.x - transform.position.x);
		float angle = Mathf.Atan2 (deltaDist.x, deltaDist.y);
		float deltaTheta = omega * Time.deltaTime * angle * Mathf.Abs (angle);
		if (Mathf.Abs (deltaTheta) > Mathf.Abs (angle)) {
			deltaTheta = angle;
		}

		transform.Rotate (transform.up * deltaTheta);
	}

    void Live() {
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(this.transform.gameObject);
    }

    void Damage(int amt) {
        if (amt < 0) {
            return;
        }
        health -= amt;

        Debug.Log("");
    }
}
