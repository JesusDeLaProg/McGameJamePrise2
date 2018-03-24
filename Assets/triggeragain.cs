using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeragain : MonoBehaviour
{

    public Transform building;
    private Vector3 face1 = new Vector3(0f, 0f, 0f);
    private Vector3 face4 = new Vector3(0f, -90f, 0f);
    public float rotation = 3;
    public bool speedrotate = true;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speedrotate == false)
        {
            building.eulerAngles = Vector3.Lerp(building.localEulerAngles, face1, Time.deltaTime * rotation);
        }
        if (building.transform.eulerAngles.y < 5)
        {

            speedrotate = true;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (building.transform.eulerAngles.y > 250 )
            {

                speedrotate = false;
              

            }
            

        }
    }
}
