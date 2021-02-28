﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public ParticleSystem particle;

    public AbilityUI fireAbility;

    private Camera camera => Camera.main;

    private Transform particleTf => transform;

    private Vector3 target = Vector3.zero;

    private Plane groundPlane = new Plane(Vector3.up, new Vector3(0, 0, 0));

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (fireAbility.CanUse)
			{
				Fire(); 
			}
        }
    }

    private void Fire()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        groundPlane = new Plane(Vector3.up, new Vector3(0, particleTf.position.y, 0));

        if (groundPlane.Raycast(ray, out float distance))
        {
            target = ray.GetPoint(distance);
            target.y = particleTf.position.y;
        }
        else
        {
            return;
        }

        // Determine which direction to rotate towards
        Vector3 targetDirection = target - particleTf.position;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(particleTf.forward, targetDirection, 100, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        particleTf.rotation = Quaternion.LookRotation(newDirection);

        particle.Play();

        fireAbility.CoolDawn();
    }
}
