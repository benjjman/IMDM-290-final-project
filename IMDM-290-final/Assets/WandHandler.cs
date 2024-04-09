using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class WandHandler : MonoBehaviour
{
    public GameObject Head;
    public GameObject LHand;
    public GameObject RHand;

    public InputActionReference triggerInputActionRefrence;
    public float prevValue = 0;

    public float rotationratio = 0.5f;
    public float projectileSpeed = 10f;

    private bool leftTriggerDown;
    private bool leftGripDown;
    
    private bool rightTriggerDown;
    private bool rightGripDown;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = triggerInputActionRefrence.action.ReadValue<float>();
        if((Input.GetKeyDown("space") || temp > 0 || Input.GetButtonDown("Fire1"))){
            GameObject newProjectile = Instantiate(projectile, RHand.transform.position, RHand.transform.rotation);
            Vector3 average = Vector3.Lerp(RHand.transform.forward, RHand.transform.up, rotationratio);
            newProjectile.GetComponent<Rigidbody>().AddForce(average*projectileSpeed, ForceMode.Force);
        }
        prevValue = temp;
    }

}
