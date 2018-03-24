using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{

    public Transform building;
    private Vector3 face1 = new Vector3(0f, 0f, 0f);
    private Vector3 face4 = new Vector3(0f, 270f, 0f);
    public float rotation = 3;
    public bool isrotating = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isrotating == true)
        {
            building.eulerAngles = Vector3.Lerp(building.localEulerAngles, face4, Time.deltaTime * rotation);
        }
        if (building.transform.eulerAngles.y > 265)
        {

            isrotating = false;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (building.transform.eulerAngles.y < 100)
            {

                isrotating = true;
             
              
            }

            

        }
    }
}
