using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scooterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] scooters; 
    public float minDelay;
    public float maxDelay;
    public bool leftSide = true;
    public float speedToSet = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnScooterStart());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnScooterStart(){
        yield return new WaitForSeconds(Random.Range(0,2));
        spawnScooterMethod();

         StartCoroutine(spawnScooter());
    }

    private IEnumerator spawnScooter(){
        yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
        spawnScooterMethod();
        StartCoroutine(spawnScooter());
    }

    private void spawnScooterMethod(){
        int scooterNum = Random.Range(0,scooters.Length-1);
        GameObject newScooter = Instantiate(scooters[scooterNum],transform.position,transform.rotation);
        newScooter.GetComponent<scooterDriveForwards>().goingRight = leftSide;
         newScooter.GetComponent<scooterDriveForwards>().speed = speedToSet;
    }
    
}
