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

    private TeleportationModule _teleportationModule;

    private void Start() {
        _teleportationModule = GameObject.FindGameObjectWithTag("Building").GetComponent<TeleportationModule>() as TeleportationModule;
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("w"))
            {
                pd.Play();
                pd2.Play();
                FindObjectOfType<audioclipmanager>().Play("door");
                Debug.Log("New pos: " + point.position);
                Debug.Log("Direction to look at: " + 
                    Vector3.Normalize(GameObject.FindGameObjectWithTag("Building").GetComponent<Transform>().position
                     - point.position));
                _teleportationModule.TeleportObjectTo(other.transform, point.position);
            }
        }
    }

}
