using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostTeleportationTarget : MonoBehaviour {

    private RotationModule _rotationModule;
    public Vector3 PlaneRotation;

	// Use this for initialization
	void Start () {
        _rotationModule = GameObject.FindGameObjectWithTag("Building").GetComponent<RotationModule>();
	}

    public bool IsPlayerInside()
    {
        var playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        var closestPosition = GetComponent<Collider>().ClosestPoint(playerPosition);
        Debug.Log("Player pos: " + playerPosition + " Closest pos: " + closestPosition);
        return Math.Abs((closestPosition - playerPosition).magnitude) < 0.1f;
    }

}
