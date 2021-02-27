using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particalController : MonoBehaviour
{
	private void OnParticleCollision(GameObject other)
	{
		var enemy = other.GetComponent<EnemyController>();

		if(enemy != null)
		{
			enemy.Death();
		}
	}
}
