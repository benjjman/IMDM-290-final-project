using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class AsteroidController : MonoBehaviour
{
    //pick point in distance, all at same dist. from player
    //randomize size slightly (& shape? how?)
    //initialize asteroid in distance (fade into view)
    //make path toward *1-2 u from player *

    public float speed = 10f;
    public float sizeScale = 0.75f; //sets max size (*1) 
    //public GameObject rock;
    public float frequency = 3f;
    public float amplitude = 10f;
    public float rockAmount = 5f; //1-10 scale?
    public Vector3 playerNear = new Vector3(0, 0, 1);
    public float playerNearUL = 0.5f; //UL/upper limit
    public float fadeAfter = 10f;

    public List<GameObject> rocksList;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rand = UnityEngine.Random.Range(0, 100);    //every frame / how often rly ? 
        if (rand < rockAmount)
        {
            StartCoroutine(Shoot());      
        }
    }

    private IEnumerator Shoot()
    {
        GameObject nRock = CreateRock();
        
        Vector3 startPos = nRock.transform.position;
        playerNear = new Vector3(UnityEngine.Random.Range(0, playerNearUL), UnityEngine.Random.Range(0, playerNearUL), UnityEngine.Random.Range(0, playerNearUL));
        var mX = startPos.x - playerNear.x;
        var mY = startPos.y - playerNear.y;


        for(int i = 0;i<fadeAfter; i++)
        {
            -= 0.1f;
            
            yield return new WaitForEndOfFrame();
        }




        var randRotation = new Quaternion(1, 1, 1, 1);
        GameObject projectile = Instantiate(nRock, startPos, randRotation);
        
        Vector3 average = Vector3.Lerp(startPos, playerNear, 0.5f);
        projectile.GetComponent<Rigidbody>().AddForce(average * speed, ForceMode.Force);
        //StartCoroutine(FadeIn(projectile));

        yield return new WaitForSeconds(fadeAfter);
        StartCoroutine(FadeOut(projectile));
    }

    private IEnumerator FadeOut(GameObject obj)
    {
        yield return new WaitForSeconds(fadeAfter);
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        UnityEngine.Color colour = meshRenderer.materials[0].color;

        while (colour.a > 0)
        {
            colour.a -= 0.1f;
            meshRenderer.materials[0].color = colour;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitUntil(() => meshRenderer.materials[0].color.a <= 0f);
        Destroy(obj); 
    }

    private IEnumerator FadeIn(GameObject obj)
    {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        UnityEngine.Color colour = meshRenderer.materials[0].color;

        while (colour.a < 1)
        {
            colour.a += 0.1f;
            meshRenderer.materials[0].color = colour;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitUntil(() => meshRenderer.materials[0].color.a >= 1f);
    }

    private GameObject CreateRock()     //randomizes size and start location
    {
        float size = sizeScale * UnityEngine.Random.Range((float).7, 1); //random range determines how much size variation there will be
        GameObject newRock = rocksList[UnityEngine.Random.Range(0, rocksList.Count)];    //pick random rock from folder
        newRock.transform.localScale.Set(size, size, size);

        float x = Mathf.Cos(Time.time * frequency) * amplitude;
        float z = Mathf.Sin(Time.time * frequency) * amplitude;
        float y = UnityEngine.Random.Range(0, 10);  //height
        newRock.transform.position = new Vector3(x, y, z);
        return newRock;
    }   
}
