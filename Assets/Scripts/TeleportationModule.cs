using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeleportationModule : MonoBehaviour {

    private bool _isTeleporting;
    public List<PostTeleportationTarget> Targets;

    public void TeleportObjectTo(Transform obj, Vector3 destination)
    {
        if (_isTeleporting) return;
        _isTeleporting = true;
        obj.position = destination;
        StartCoroutine("EndTeleportationInAWhile");
        var target = Targets.FirstOrDefault(t => t.IsPlayerInside());
        if (target != null) GetComponent<RotationModule>().CurrentTargetRotation = target.PlaneRotation;
    }

    public IEnumerator EndTeleportationInAWhile()
    {
        if (!_isTeleporting) yield break;
        yield return new WaitForSeconds(0.25f);
        _isTeleporting = false;
    }
    
    public static Vector3? PointToLookAt;
    private Transform self;
	// Use this for initialization
	void Start () {
        _isTeleporting = false;
        PointToLookAt = null;
        self = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PointToLookAt.HasValue)
        {
            self.rotation = Quaternion.Slerp(self.rotation, Quaternion.LookRotation(PointToLookAt.Value), Time.deltaTime * 10);
            if(Quaternion.Angle(self.rotation, Quaternion.LookRotation(PointToLookAt.Value)) < 0.01f)
            {
                self.rotation = Quaternion.LookRotation(PointToLookAt.Value);
                PointToLookAt = null;
            }
        }
	}
}
