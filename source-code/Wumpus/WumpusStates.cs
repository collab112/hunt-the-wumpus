using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Needed for working with AI

public class WumpusStates : MonoBehaviour
{
  
    public int wumpusState; // State variable

    public Transform player; // Player position variable

    public NavMeshAgent navAgent; // Navmesh agent for pathfinding

    public LayerMask playerMask; // Boxcast variables
    public float rangeOfWumpus;
    public RaycastHit castHitInfo; 

    public float chasingTime; // Chasing variables
    float remainingTime;

    public Vector3 wumpusTrapPos; // Trap position

    public Vector3 roamingPoint; // Roam points

    public GameObject randomPointHandler;

    void Start() {

      wumpusState = 0;
      remainingTime = chasingTime;
      // Set the wumpus to roam

      transform.position
       = 
      randomPointHandler.GetComponent<RoamHelper>().getRandomPointAwayFromPlayer();
      // Assign a random position to the wumpus on spawn

    }

    public void checkTrap(Vector3 trapPos) { 

      // A function called from NoiseTrap.cs and the position of the trap is passed
      // and stored in this script, where the Wumpus will pathfind to

      wumpusTrapPos = trapPos;
      wumpusState = 2; 

    }

    public void outOfAmmo() {

      wumpusState = 1;
      remainingTime = Mathf.Infinity; 
      // If the player is out of ammo, set the Wumpus to chase and set the time to
      // infinity

    } 

    public void roamPoints(Vector3 roamingPointPos) {
      
      roamingPoint = roamingPointPos;
      // Contian the position of the next roam point

    }

    public void chasePlayer() {

      wumpusState = 1;
      remainingTime = chasingTime;

    }

    void Update() {

      // Boxcast is a function similar to a raycast but it sends a box out rather than
      // a single ray. I used this to detect the player.

      if ( Physics.BoxCast (

          transform.position, // Where the boxcast is shot from
          new Vector3(5, 2, 1), // Dimensions of box
          transform.forward, // Direction the box is shot in
          out castHitInfo, // Return info on what was hit
          transform.rotation, // Rotation of the box
          rangeOfWumpus, // Max range the box is shot to
          playerMask // LayerMask to avoid hitting walls
        
        ) ) {

          chasePlayer();

          // If the player was hit with the boxcast, set the wumpus to its chasing state

        }

      switch(wumpusState) {

            // A switch and case for the 3 states of the wumpus

            /*/ / / / / / / / / / / / / / / / / / /
            *
            * 0 = Roaming
            *
            * 1 = Chasing
            *
            * 2 = Noise trap triggered
            *
            / / / / / / / / / / / / / / / / / / /*/

        case 0:

          navAgent.SetDestination(roamingPoint);
          navAgent.speed = 7f;

          // Set the destination of the navmesh agent to the next roam point

          break; 

        case 1:

          remainingTime -= Time.deltaTime;

          navAgent.SetDestination(player.position);
          navAgent.speed = 15.0f;

          if ( remainingTime <= 0 ) {

            wumpusState = 0;

          }

          // Set the destination of the navmesh agent to the player position and make
          // it go back to roaming after chasing time has finished.

          break;

        case 2:

          navAgent.SetDestination(wumpusTrapPos);
          navAgent.speed = 15.0f; 

          // Set the destination of the navmesh agent to the trap position

          break;
      
      }

    }

}
