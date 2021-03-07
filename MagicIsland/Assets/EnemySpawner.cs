using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController enemy;

    public GameObject endPoint;

	public Transform elevator;

	private Vector3 enemyStartPoint;

	private void Start()
	{
		enemyStartPoint = enemy.transform.position;

		//StartCoroutine(Move());
	}

	private IEnumerator Move()
	{
		var time = 0f;

		yield return new WaitForSeconds(5);

		while (time <1)
		{
			time += 0.01f;

			var a = Vector3.Lerp(enemyStartPoint, endPoint.transform.position, time);

			enemy.transform.position = a;

			yield return new WaitForFixedUpdate();
		}

		yield return new WaitForSeconds(5);

		while (time > 0)
		{
			time -= 0.01f;

			var b = Vector3.Lerp(enemyStartPoint, endPoint.transform.position, time);
		}
	}
}
