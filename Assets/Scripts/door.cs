using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class door : MonoBehaviour
{

    public Transform point;
    public PlayableDirector pd;

    public PlayableDirector pd2;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("w"))
            {
                pd.Play();
                pd2.Play();
                other.gameObject.transform.position = point.position;
            }
        }
    }
}
