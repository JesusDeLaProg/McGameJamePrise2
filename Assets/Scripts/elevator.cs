using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class elevator : MonoBehaviour {

    public Transform point;
    public PlayableDirector pd;
    public PlayableDirector pd2;

    private TeleportationModule _teleportationModule;

    public void Start()
    {
        _teleportationModule = GameObject.FindGameObjectWithTag("Building").GetComponent<TeleportationModule>() as TeleportationModule;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("w"))
            {
                pd.Play();
                pd2.Play();
                FindObjectOfType<audioclipmanager>().Play("elevator");
                _teleportationModule.TeleportObjectTo(other.transform, point.position);
            }
        }
    }
}
