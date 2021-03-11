using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using UnityEngine;
using Cinemachine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController enemy;

	[Range(3,20)]
	public int vilocity = 10;

	public CinemachineSmoothPath path;

	public Transform enemyContainer;

	public EnemyManager enemyManager;

	bool generate = true;

	public IEnumerator Generate()
	{
		while (generate)
		{
			if (enemyManager.enemies.Length < 7)
			{
				var newEn = Instantiate(enemy);

				newEn.transform.SetParent(enemyContainer);

				newEn.StartPatrule(path); 
			}

			yield return new WaitForSeconds(vilocity); 
		}
	}

	public void StopGenerate()
	{
		generate = false;

		StopCoroutine(Generate());
	}
}
