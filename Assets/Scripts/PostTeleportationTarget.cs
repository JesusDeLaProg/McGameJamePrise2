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
        return IsPositionInside(playerPosition);
    }

    public bool IsPositionInside(Vector3 position)
    {
        var closestPosition = GetComponent<Collider>().ClosestPoint(position);
        Debug.Log("Pos: " + position + " Closest pos: " + closestPosition
            + " Magnitude: " + Math.Abs((closestPosition - position).magnitude));
        return Math.Abs((closestPosition - position).magnitude) < 0.1f;
    }

}
