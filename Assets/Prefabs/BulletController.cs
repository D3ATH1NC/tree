using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
public float speed = 200f;
public float timeTilDeath = 5f;
public int damage = 40;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    
    {
    transform.Translate(Vector3.forward * Time.deltaTime * speed);


    {

        Debug.Log("Entering collision");

        HealthController healthController = gameObject.GetComponent<HealthController>();

        if (healthController != null)
        {
            healthController.DealDamage(damage);
        }

            Destroy(this.gameObject, timeTilDeath);

    }
}}
