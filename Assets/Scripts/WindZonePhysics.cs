﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadOnlyDrawer;
using System;

[DisallowMultipleComponent]
[RequireComponent(typeof(WindZone))]
public class WindZonePhysics : MonoBehaviour {
    [ReadOnly] public WindZone referedComponent;
    public float Strength {
        get { return referedComponent.windMain; }
        set { referedComponent.windMain = value; }
    }
    public float Turbulence {
        get { return referedComponent.windTurbulence; }
        set { referedComponent.windTurbulence = value; }
    }
    public string lookForTag = "Projectile";

	// Use this for initialization
	void Start () {
        referedComponent = GetComponent<WindZone>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Rigidbody[] rbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody projectile in rbodies) {
            if (projectile.CompareTag(lookForTag)) {
                BlowOn(projectile);
            }

        }
    }

    private void BlowOn(Rigidbody projectile) {
        float turbulence = Turbulence * UnityEngine.Random.value;
        projectile.AddForce(transform.forward * (Strength+turbulence) * 10);
    }
}
