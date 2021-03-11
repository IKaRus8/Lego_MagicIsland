using LEGOModelImporter;
using System.Collections;
using Unity.LEGO.Behaviours.Actions;
using UnityEngine;
using Cinemachine;
using Unity.LEGO.Behaviours.Triggers;
using System.Linq;

public class EnemyController : MonoBehaviour
{
	public int lifeCount = 1;

	public bool isDron;

	public CinemachineDollyCart dollyCart;

	public ExplodeAction explode;

	public MoveAction moveAction;

	public LookAtAction lookAtAction;

	public ShootAction shootAction;
	public ShootAction shootAction2;

	private CinemachineSmoothPath _path;

	private void Start()
	{
		if (isDron)
		{
			dollyCart = GetComponent<CinemachineDollyCart>();

			GetComponentInChildren<NearbyTrigger>().OnActivate += () =>  StartCoroutine(StopPatrule());
		}
		
		explode.CustomEx = true;
	}

	public void Death()
	{
		lifeCount--;

		if (lifeCount == 0)
		{
			explode.enabled = true;

			SetState(false);

			StartCoroutine(Fade());
		}
	}

	public void SetState(bool value)
	{
		if (moveAction != null)
		{
			moveAction.enabled = value;
		}

		if (shootAction != null)
		{
			shootAction.enabled = value;
		}

		if (shootAction2 != null)
		{
			shootAction2.enabled = value;
		}

		if (lookAtAction != null)
		{
			lookAtAction.enabled = value; 
		}
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

	public void StartPatrule(CinemachineSmoothPath path)
	{
		_path = path;

		transform.position = path.m_Waypoints[0].position;

		dollyCart.m_Path = path;
		dollyCart.m_Speed = 7;
	}

	private IEnumerator StopPatrule()
	{
		dollyCart.enabled = false;

		Destroy(dollyCart);

		var pos = transform.position;

		yield return new WaitForSeconds(2);

 		//transform.position = pos;
	}
}
