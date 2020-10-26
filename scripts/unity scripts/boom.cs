﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExplodeed = false;



    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExplodeed)
        {
            Explode();
            hasExplodeed = true;
        }
    }


    void Explode ()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            boxbreak dest = nearbyObject.GetComponent<boxbreak>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }    


        Destroy(gameObject);
    }
}
