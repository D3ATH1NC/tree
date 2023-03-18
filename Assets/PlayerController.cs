using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{public int health = 5;
public float moveSpeed = 30f;
public float rotationSpeed = 200f;
public GameObject bulletPrefab;
public float firingCountdown;
public float firingWaitTime = 0.5f;
public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firingCountdown <= 1)
        {
        }
        else
        {
            firingCountdown = firingCountdown - Time.deltaTime;
        }
        if (Input.GetKey("space") && firingCountdown <=0)
    {
    Debug.Log("the space bar has been pressed");
    Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    firingCountdown = firingWaitTime;
    }

        if (Input.GetKey("w"))
        {
           // Debug.Log("this is a test for w");
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey("a"))
        {
            //Debug.Log("this is a test for a");
            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKey("s"))
        {
            //Debug.Log("this is a test for s");
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey("d"))
        {
            //Debug.Log("this is a test for d");
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }

}

