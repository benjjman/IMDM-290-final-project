using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scooterDriveForwards : MonoBehaviour
{
    public float speed = 5f;
    private float deleteTime = 9;
    public bool goingRight = true;
    // Start is called before the first frame update
    void Start()
    {   
        if(goingRight == true){
            transform.GetComponent<Rigidbody>().velocity = new Vector3(speed,0,0);
        }else{
            transform.GetComponent<Rigidbody>().velocity = new Vector3(-speed,0,0);
        }
        
        StartCoroutine(deleteTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator deleteTimer(){
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
