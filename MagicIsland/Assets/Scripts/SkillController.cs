using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using Unity.LEGO.Minifig;
using UnityEngine;
using static Unity.LEGO.Minifig.MinifigFaceAnimationController;

public class SkillController : MonoBehaviour
{
    public ParticleSystem particle;

    public AbilityUI fireAbility;

    public MinifigController minifig;

    private MinifigFaceAnimationController faceAnimationController;

    private Animator animator;

    private Vector3 target = Vector3.zero;

    private Plane groundPlane = new Plane(Vector3.up, new Vector3(0, 0, 0));

    private Camera camera => Camera.main;

    private Transform particleTf => transform;


	private void Awake()
	{
        animator = GetComponent<Animator>();

        //faceAnimationController = GetComponent<MinifigFaceAnimationController>();

        //minifig.PlaySpecialAnimation(MinifigController.SpecialAnimation.LookingAround);
        //faceAnimationController.PlayAnimation(FaceAnimation.Frustrated);
    }

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

    public void OnPickUpStick(PickupAction action)
	{
        fireAbility.gameObject.SetActive(true);
    }

    public void SetInput(bool value)
	{
        minifig.SetInputEnabled(value);
    }

    public void SetAnimatorState(bool value)
	{
        animator.enabled = value;

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
