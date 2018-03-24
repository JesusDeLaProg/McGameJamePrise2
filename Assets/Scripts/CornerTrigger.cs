using System;
using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
using UnityEngine;

public class CornerTrigger : MonoBehaviour
{

	public Transform Building;
    public Vector3 Target1;
	public Vector3 Target2;
    public float RotationSpeed;
    private Quaternion _qTarget1;
    private Quaternion _qTarget2;
    private Quaternion? _currentRotationTarget;

    // Use this for initialization
    void Start()
    {
        _qTarget1 = Quaternion.Euler(Target1);
        _qTarget2 = Quaternion.Euler(Target2);
		var v = System.Environment.Version;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentRotationTarget.HasValue)
        {
			Building.rotation = Quaternion.Slerp(Building.rotation, _currentRotationTarget.Value, Time.deltaTime * RotationSpeed);
            Debug.Log("Rotation: " + Building.rotation.eulerAngles);
            if (Math.Abs(Quaternion.Angle(Building.rotation, _currentRotationTarget.Value)) < 0.1f) Building.rotation = _currentRotationTarget.Value;

            _currentRotationTarget = Building.rotation == _currentRotationTarget.Value
                                        ? null
                                        : _currentRotationTarget;
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision", other);
        if (other.CompareTag("Player"))
        {
            _currentRotationTarget = Math.Abs(Quaternion.Angle(Building.rotation, _qTarget1)) < 1f
                                        ? _qTarget2
                                        : _qTarget1;
            Debug.Log("Current rotation target changed to " + _currentRotationTarget.Value.ToString()
            + ". Current position is " + Building.rotation.ToString());
        }
    }
}
