using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Prefab for instantiating apples
    public GameObject applePrefab;


    // Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change direction
    public float chanceToChangeDirection;

    //Rate at which Apples will instantiate
    public float secondsBetweenAppleDrop;

    void Start ()
    {
        //Dropping apples every second
    }

    void Update ()
    {
        //Basic Movement
        //Changing Direction

     
    }
}
