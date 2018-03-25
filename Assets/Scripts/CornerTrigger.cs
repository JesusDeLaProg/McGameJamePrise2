using System;
using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
using UnityEngine;

public class CornerTrigger : MonoBehaviour
{
    private RotationModule _rotationModule;
    private Transform _building;
    public Vector3 Target1;
	public Vector3 Target2;

    // Use this for initialization
    void Start()
    {
        var building = GameObject.FindGameObjectWithTag("Building");
        _rotationModule = building.GetComponent<RotationModule>();
        _building = building.GetComponent<Transform>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rotationModule.CurrentTargetRotation = Math.Abs((_building.rotation.eulerAngles - Target1).magnitude) < 0.1f
                                        ? Target2
                                        : Target1;
        }
    }
}
