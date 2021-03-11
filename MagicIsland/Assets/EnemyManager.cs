using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public EnemyController[] enemies => GetComponentsInChildren<EnemyController>();

	public void EnemiesState(bool value)
	{
		foreach (var en in enemies)
		{
			en.SetState(value);
		}
	}
}
