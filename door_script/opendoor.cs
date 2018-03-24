﻿//Mettre le script dans le G.O. de la porte. Étiquetter le tag du player: "Player"   

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {

    /*  test
    
    public Transform door; 
    public Vector3 openedRotate = new Vector3(0f, 45f, 0f);
    private float openSpeed = 3;
    */

    private bool triggerEntered = false;


    // Update is called once per frame

    //si le Player entre dans le collider et il presse sur W
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && triggerEntered == true)
        {
            //door.Rotate = Vector3.Lerp(door.Rotate, openedPosition, Time.deltaTime * openSpeed);
            print("enter");
            FindObjectOfType<audioclipmanager>().Play("open");
        }  
    }

    // si le player entre dans le collider, le triggerEntered est vrai si le player a le tag player.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerEntered = true;
            Debug.Log("trigger entered");
        }

    }

}