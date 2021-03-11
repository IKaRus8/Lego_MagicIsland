using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.LEGO.Behaviours.Triggers;
using UnityEngine;

public class PlatformsSpawner : MonoBehaviour
{
    public CinemachineSmoothPath Path;

    public CinemachineDollyCart[] platformPrefabs;

	public bool generate = true;

	private List<CinemachineDollyCart> activePlatform;

	private void Awake()
	{
		activePlatform = new List<CinemachineDollyCart>();

		StartCoroutine(Generator());
	}

	private void Update()
	{
		if (generate)
		{
			foreach (var plat in activePlatform.ToList())
			{
				if (plat.m_Position > 265)
				{
					activePlatform.Remove(plat);

					Destroy(plat.gameObject);
				}
			} 
		}
	}

	public IEnumerator Generator()
	{
		while (generate)
		{
			int i = Random.Range(0, platformPrefabs.Length - 1);

			var platform = Instantiate(platformPrefabs[i]);

			platform.m_Path = Path;

			platform.m_Speed = 7;

			platform.transform.position = Path.m_Waypoints[0].position;

			activePlatform.Add(platform);

			yield return new WaitForSeconds(10); 
		}
	}

	public void StopGenerator()
	{
		activePlatform.ForEach(p => p.m_Speed = 0);

		generate = false;

		var enemies = GetComponentsInChildren<EnemyController>();

		foreach (var en in enemies)
		{
			Destroy(en.gameObject);
		}

		StopCoroutine(Generator());
	}
}
