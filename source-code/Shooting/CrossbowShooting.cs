using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Needed for working with TextMeshPro

public class CrossbowShooting : MonoBehaviour
{
    public Transform boltSpawnPoint; // Set the spawn point of the projectile
    public GameObject boltObject; // Set the projectile object  
    public float boltVelocityMultiplier = 30; // Set the velocity of the projectile
    public int ammoCount = 4; // Set the ammo count
    public GameObject wumpusObj; // Set the wumpus object

    public TMP_Text ammoCounter; // Ammo count display

    void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0) { 
        // If left mouse is clicked and the ammo is above 0, run the script

            var bolt = Instantiate(boltObject, boltSpawnPoint.position, boltSpawnPoint.rotation);
            // Instantiate a prefab "boltObject" and spawn it at the position contained in
            // boltSpawnPoint and the rotation in boltSpawnPoint

            bolt.GetComponent<Rigidbody>().velocity = boltSpawnPoint.forward * boltVelocityMultiplier;
            // Set the velocity of the projectile

            ammoCount -= 1;

        }

        if ( ammoCount <= 0) {

            wumpusObj.GetComponent<WumpusStates>().outOfAmmo(); 
            // Call a function that alerts the wumpus to your location at all times
            // if the player were to run out of ammo

        }

        ammoCounter.SetText("Ammo: " + ammoCount);
        // Display the ammo counter

    }
}
