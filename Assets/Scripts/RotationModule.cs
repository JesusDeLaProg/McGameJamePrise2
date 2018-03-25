using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationModule : MonoBehaviour {

    private Quaternion? _currentTargetRotation;
    private Transform self;

    public float RotationSpeed;

    public Vector3? CurrentTargetRotation
    {
        get
        {
            return _currentTargetRotation.HasValue
                ?_currentTargetRotation.Value.eulerAngles
                : (Vector3?)null;
        }
        set
        {
            if(value.HasValue)
            {
                _currentTargetRotation = Quaternion.Euler(value.Value);
            }
            else
            {
                _currentTargetRotation = null;
            }
        }
    }

	// Use this for initialization
	void Start () {
        CurrentTargetRotation = null;
        self = GetComponent<Transform>() as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(_currentTargetRotation.HasValue)
        {
            self.rotation = Quaternion.Slerp(self.rotation, _currentTargetRotation.Value, Time.deltaTime * RotationSpeed);
            if(Mathf.Abs(Quaternion.Angle(self.rotation, _currentTargetRotation.Value)) < 0.1f)
            {
                self.rotation = _currentTargetRotation.Value;
                _currentTargetRotation = null;
            }
        }
	}
}
