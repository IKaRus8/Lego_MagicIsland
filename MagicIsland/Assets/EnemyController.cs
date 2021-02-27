using LEGOModelImporter;
using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using Unity.LEGO.Minifig;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ExplodeAction explode;

	private MoveAction moveAction;

	private LookAtAction lookAtAction;

	private void Start()
	{
		explode = GetComponentInChildren<ExplodeAction>();
		moveAction = GetComponentInChildren<MoveAction>();
		lookAtAction = GetComponentInChildren<LookAtAction>();

		explode.CustomEx = true;
	}

	public void Death()
	{
		explode.enabled = true;

		moveAction.enabled = false;
		lookAtAction.enabled = false;

		StartCoroutine(Fade());
	}

	private IEnumerator Fade()
	{
		yield return new WaitForSeconds(1);

		Destroy(gameObject);
	}

	private IEnumerator FadeSlow()
	{
		foreach (Transform child in transform.GetChild(0))
		{
			Destroy(child.gameObject);

			yield return new WaitForFixedUpdate();
		}

		Destroy(gameObject);
	}
}
