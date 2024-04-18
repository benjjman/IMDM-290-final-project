using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTimer : MonoBehaviour
{

    public float aliveTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenDelete());
    }

    private IEnumerator WaitThenDelete(){
        yield return new WaitForSeconds(aliveTime);
        Destroy(transform.gameObject);
    }

}
