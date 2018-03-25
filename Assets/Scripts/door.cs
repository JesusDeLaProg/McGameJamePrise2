using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class door : MonoBehaviour
{
    public bool IsObjective = false;
    private bool _wPressed;
    public Transform point;
    public PlayableDirector pd;
    public PlayableDirector pd2;

    private TeleportationModule _teleportationModule;

    private void Start() {
        _teleportationModule = GameObject.FindGameObjectWithTag("Building").GetComponent<TeleportationModule>() as TeleportationModule;
        _wPressed = false;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        _wPressed = Input.GetKeyDown("w");
    }


    public void OnTriggerStay(Collider other)
    {
        if(GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().IsItTimeToStop)
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            if (_wPressed && !IsObjective)
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
