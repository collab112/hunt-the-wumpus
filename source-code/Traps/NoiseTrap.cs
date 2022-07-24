using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrap : MonoBehaviour
{

    public AudioClip hawkSounds; // Audio Clip to be playued
    public AudioSource trapSource; // Audio source where the sound comes from
    public GameObject enemy; // Wumpus object

    public GameObject randomPointHandler; // Receive random points 

    void Start() { 

        // On start, collect a random point from the randomPointHandler and set the location
        // of this gameobject to it.

        transform.position
         = 
        randomPointHandler.GetComponent<RoamHelper>().getRandomPointAwayFromPlayer();

    }

    void OnTriggerEnter(Collider other) {

        // Using OnTriggerEnter() to detect if the trap has collided with something

        if (other.gameObject.layer == 7) {
            
            // Check the layer of the collider. If it is 7 (Player) then run the code below

            trapSource.PlayOneShot(hawkSounds, 1f); // Play sound
            enemy.GetComponent<WumpusStates>().checkTrap(transform.position);
            // Send the wumpus to this location

        }    

    }

}