using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogHop : MonoBehaviour
{
    public float jumpLength = 5;
    private bool moving = false;
    public SpriteRenderer deathScreen;
    public AudioSource walkingNoise;
    public AudioSource deathNoise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) && moving == false && transform.position.z < 90f){
            moving = true;
            StartCoroutine(move());
            
        }
    }

    private IEnumerator move(){
        walkingNoise.mute = false;
        for(int i = 0; i < 10; i++){
            if(moving == false){
                yield break;
            }
            Debug.Log(jumpLength / 10);
            transform.position += new Vector3(0,0,jumpLength/10);
            yield return new WaitForSeconds(0.01f);
        }
        walkingNoise.mute = true;
        moving = false;
        yield break;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "scooter"){
            Debug.Log("Player Hit!");
            moving = false;
            walkingNoise.mute = true;
            //trigger death and respawn
            StartCoroutine(deathFade());
            transform.position = new Vector3(0,0,0);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator deathFade(){
        deathScreen.color = new Color(0,0,0,1);
        deathNoise.Play();
        yield return new WaitForSeconds(1f);
        for(float i = 1; i > 0; i = i -= 0.1f){
            deathScreen.color = new Color(0,0,0,i);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
}
