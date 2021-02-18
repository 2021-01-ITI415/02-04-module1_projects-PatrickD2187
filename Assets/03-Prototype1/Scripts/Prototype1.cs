using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prototype1 : MonoBehaviour
{
    
    [Header("Set Dynamically")]
    public Text livesGT;
    public int numLives = 3;
    public int tnumLives = 3;
    // Start is called before the first frame update
    void Start()
    {

        GameObject livesGO = GameObject.Find("Lives");
        livesGT = livesGO.GetComponent<Text>();
        livesGT.text = "3";
        
    }

    public void PlayerDestroyed()
    {
        // Destroy all of the falling players
        GameObject[] tProjectileArray = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject tGO in tProjectileArray)
        {
            Destroy(tGO);
            
            int tnumLives = int.Parse(livesGT.text);
            numLives = numLives - 1;
            tnumLives = tnumLives - 1;
            livesGT.text = tnumLives.ToString();
        }

        if(numLives <= 0)
        {
            
            SceneManager.LoadScene("Main-Prototype 1");
            
        }
        
    }
}
