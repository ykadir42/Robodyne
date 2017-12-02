using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : Behavior{

    //Stats

    Rigidbody rb;
    public GameObject bullet;
    private float cooldown;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 3;
        health = 500;
    }

	// Update is called once per frame
	void Update () {
        if(cooldown > 0)
            cooldown -= Time.deltaTime;
        Rotate();
        Move();
        Live();
        Shoot();

	}

    private void Move()
    {
        if (Input.GetKey("w")){
            transform.Translate(Vector3.forward * speed * Time.deltaTime, transform);
            
            //rb.AddForce(speed * Vector3.forward * Time.deltaTime);
        }
        //if (Input.GetKey("a"))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime, transform);
        //    //rb.AddForce(speed * Vector3.left);
        //}
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, transform);
            //rb.AddForce(speed * Vector3.back);
        }
        //if (Input.GetKey("d"))
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime, transform);
        //    //rb.AddForce(speed * Vector3.right);
        //}
    }

    private void Rotate() {
        float rotateY = Input.GetAxis("Mouse X");
        float rotateX = Input.GetAxis("Mouse Y");
        transform.Rotate(rotateY * Vector3.up);

        Transform cameratransform = transform.GetChild(1).transform;
        cameratransform.Rotate(rotateX * Vector3.left);
        cameratransform.eulerAngles = new Vector3(WorkingClamp(cameratransform.eulerAngles.x, -45, 0), cameratransform.eulerAngles.y, cameratransform.eulerAngles.z);
    }

    private void Live()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You ded"); 
    }

    private void Shoot() {
        if (Input.GetKey("space") && cooldown <= 0) {
            GameObject shotBullet = Instantiate(bullet, transform.GetChild(1).GetChild(1).transform.position, transform.GetChild(1).GetChild(1).transform.rotation);
            shotBullet.GetComponent<Rigidbody>().AddForce(transform.GetChild(1).GetChild(1).transform.up * 1000);
            cooldown = 3;
        }
    }

    float WorkingClamp(float val,float min, float max) {

        if(val <= 180) {
            if (val > max) {
                val = max;
            }
        }

        else {
            if (val < min + 360) {
                val = min;
            }
            
        }
        

        return val;
    }
}
