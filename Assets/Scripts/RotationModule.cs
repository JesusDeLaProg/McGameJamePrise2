using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationModule : MonoBehaviour {

    private Quaternion? _currentTargetRotation;
    private Transform self;

    public float RotationSpeed;

    private Quaternion? _rubberbandTarget;

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

    public void RubberBandToRotation(Vector3 target)
    {
        _rubberbandTarget = Quaternion.Euler(target);
        StartCoroutine("DoRubberBand");
    }

    IEnumerator DoRubberBand()
    {
        var beginRotation = self.rotation;
        var camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraLogic>();
        var beginCameraDistance = camera.m_distance;
        if(!_rubberbandTarget.HasValue) yield break;
        yield return new WaitForSeconds(0.25f);
        camera.m_distance = 9.0f;
        camera.NextTarget();
        _currentTargetRotation = _rubberbandTarget.Value;
        _rubberbandTarget = null;
        yield return new WaitUntil(() => !_currentTargetRotation.HasValue);
        yield return new WaitForSeconds(1.0f);
        _currentTargetRotation = beginRotation;
        camera.m_distance = beginCameraDistance;
        camera.NextTarget();
        yield return new WaitUntil(() => _currentTargetRotation == null);
        yield break;
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
