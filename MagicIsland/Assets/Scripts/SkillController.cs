using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public ParticleSystem particle;

    private Camera camera => Camera.main;

    private Transform particleTf => transform;

    private Vector3 target = Vector3.zero;

    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        var mousePoint = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));

        //var g = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var direction = mousePoint - camera.transform.position;

        if (Physics.Raycast(camera.transform.position, direction, out hit))
        {
            target = hit.point;
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
    }
}
