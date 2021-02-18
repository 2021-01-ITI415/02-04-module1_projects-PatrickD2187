using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prototype1 : MonoBehaviour
{
    public int numLives = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDestroyed()
    {
        // Destroy all of the falling players
        GameObject[] tProjectileArray = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject tGO in tProjectileArray)
        {
            Destroy(tGO);
        }

        numLives = numLives - 1;

        if(numLives == 0)
        {
            SceneManager.LoadScene("Main-Prototype 1");
        }
        
    }
}
