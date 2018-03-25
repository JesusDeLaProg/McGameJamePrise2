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

    private void Start() {
        Teleportation.IsTeleporting = false;
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("w") && !Teleportation.IsTeleporting)
            {
                Teleportation.IsTeleporting = true;
                StartCoroutine("WaitForEndOfTeleportation");
                var building = GameObject.FindGameObjectWithTag("Building");
                pd.Play();
                pd2.Play();
                Debug.Log("New pos: " + point.position);
                other.gameObject.transform.position = point.position;
            }
        }
    }

    IEnumerator WaitForEndOfTeleportation() {
        if(!Teleportation.IsTeleporting) yield break;
        yield return new WaitForSeconds(0.25f);
        Teleportation.IsTeleporting = false;
    }

}
