using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print("Death");

        Prototype1 apScript = Camera.main.GetComponent<Prototype1>();

        // Call the public PlayerDestroyed() method of apScript
        apScript.PlayerDestroyed();

    }

}
