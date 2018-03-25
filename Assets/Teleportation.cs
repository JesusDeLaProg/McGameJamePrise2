﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

	public static bool IsTeleporting;
    public static Vector3? PointToLookAt;
    private Transform self;
	// Use this for initialization
	void Start () {
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
