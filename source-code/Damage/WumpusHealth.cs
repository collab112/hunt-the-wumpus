using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WumpusHealth : MonoBehaviour
{
    
    public int wumpusHP; // The wumpus's health

    void Start() {
        
        wumpusHP = 2; // Set the Wumpus's health to 2 hit points

    }

    public void receiveDamage() {

        wumpusHP -= 1; 
        // Called on from BoltScript.cs if the collision 
        // with the rock is the Wumpus (If the rock hits the Wumpus, remove a hit point)

    }

    void Update() {

        if ( wumpusHP == 0 ) {

            SceneManager.LoadScene(1);

        }

    }

}
