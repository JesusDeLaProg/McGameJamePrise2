using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger4 : MonoBehaviour {

    public GameObject building;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.localRotation.y == 180)
            {

            }
        }
    }
}
