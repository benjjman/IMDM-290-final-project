//ben
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRippleController : MonoBehaviour
{
    public ParticleSystem ripple;


    // Start is called before the first frame update
    void Start()
    {
        //initialize rotation/position perpendicular to the spot that was shot
    }

    //start at impact and stop at ~ 8-9 s (fade out for like ~1 sec so it's not abrupt)

    // Update is called once per frame
    void Update()
    {
        //? anything else? 
    }

    private void OnTriggerEnter()
    {
        //pasted from WandHandler (then edited)
        Debug.Log(XRCharacterData.RightController.Grip);
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")))
        {
            GameObject newProjectile = Instantiate(projectile, RHand.transform.position, RHand.transform.rotation);
            Vector3 average = Vector3.Lerp(RHand.transform.forward, RHand.transform.up, rotationratio);
            newProjectile.GetComponent<Rigidbody>().AddForce(average * projectileSpeed, ForceMode.Force);
        }



        ripple.transform.rotation = Quaternion.LookRotation(-hit.normal, transform.up);



        ripple.Play();
    }
}

