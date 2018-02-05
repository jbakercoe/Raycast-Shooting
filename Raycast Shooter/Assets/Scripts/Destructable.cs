using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    [Range(0f, 3f)]
    public float timeDelay;

	// Use this for initialization
	void Start () {
        StartCoroutine(Shatter());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Shatter()
    {
        yield return new WaitForSeconds(timeDelay);
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //rb.isKinematic = true;
                //yield return new WaitForSeconds(.5f);
                //rb.isKinematic = false;
                rb.maxAngularVelocity = 0.0001f;
            }
        }
    }

}
