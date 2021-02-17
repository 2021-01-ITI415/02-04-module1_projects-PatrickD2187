using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static float bottomY = -20f;
    private int count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Get a reference to the ApplePicker component of Main Camera
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