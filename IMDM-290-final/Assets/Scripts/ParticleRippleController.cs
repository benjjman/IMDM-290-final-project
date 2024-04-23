//ben
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRippleController : MonoBehaviour
{
    public ParticleSystem ripple;
    public GameObject player;   //to reference player's position 
    public GameObject hit; //the star or planet or wtv that you hit
    //public GameObject collisionPoint;


    public void Update() //OnTriggerEnter()   //when star is hit 
    {
<<<<<<< Updated upstream
        if (Input.anyKey){
            
=======
    }

    private void OnTriggerEnter()//(Collider collide)   //when star is hit 
    {       

            //collisionPoint.transform.position = collide.transform.position; 
            //var collision = Collider.ClosestPoint(collisionPoint.transform.position);
         
>>>>>>> Stashed changes
            //initialize rotation/position perpendicular to the spot that was shot
            ripple.transform.position = hit.transform.position;
            var direction = player.transform.position - ripple.transform.position;
            // ? direction.y = 0;
            var rotation = Quaternion.LookRotation(transform.position, direction);
            //rotation.z = rotation.z * -1;
            ripple.transform.rotation = rotation; 
            ripple.Play();
<<<<<<< Updated upstream
        }
=======

>>>>>>> Stashed changes
    }
}

