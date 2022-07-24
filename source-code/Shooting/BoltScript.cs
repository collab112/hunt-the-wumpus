using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    public float life = 3.0f; // Setting lifetime of the bolt
    public GameObject WumpusHealthHandler; // Allow this script to access the Wumpus's health
    public GameObject wumpusObj;

    void Awake() {

        Destroy(gameObject, life); // Giving lifetime to the bolt
        WumpusHealthHandler = GameObject.Find("WorldHandler"); // Find the World Handler
        wumpusObj = GameObject.Find("Wumpus");

    }

    private void OnCollisionEnter(Collision collisionVariable) { // Remove the projectile upon collision

        if ( collisionVariable.gameObject.layer == 9) { 
            
        // If the object the rock has collided with is of layer 9 (Wumpus)

            WumpusHealthHandler.GetComponent<WumpusHealth>().receiveDamage();
            wumpusObj.GetComponent<WumpusStates>().chasePlayer();

            // Call a function from the handler script that removes the health of the wumpus

        }

    }
}
