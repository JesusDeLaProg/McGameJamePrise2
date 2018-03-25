using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class elevator : MonoBehaviour {

    private bool _wPressed;

    public Transform point;
    public PlayableDirector pd;
    public PlayableDirector pd2;

    private TeleportationModule _teleportationModule;

    public void Start()
    {
        _teleportationModule = GameObject.FindGameObjectWithTag("Building").GetComponent<TeleportationModule>() as TeleportationModule;
        _wPressed = false;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    public void FixedUpdate()
    {
        _wPressed = Input.GetKeyDown("k");
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_wPressed)
            {
                pd.Play();
                pd2.Play();
                FindObjectOfType<audioclipmanager>().Play("elevator");
                _teleportationModule.TeleportObjectTo(other.transform, point.position);
            }
        }
    }
}
