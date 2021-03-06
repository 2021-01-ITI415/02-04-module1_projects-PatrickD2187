﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static float bottomY = -20f;
    public float speed = 20f;
    public Rigidbody rigid;
    public float horizontal;
    public float vertical;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 15)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0.0f, vertical);

            rigid.AddForce(direction * speed);
        }
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Get a reference to the Prototype1 component of Main Camera
            Prototype1 apScript = Camera.main.GetComponent<Prototype1>();

            // Call the public PlayerDestroyed() method of apScript
            apScript.PlayerDestroyed();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

        }
    }
}