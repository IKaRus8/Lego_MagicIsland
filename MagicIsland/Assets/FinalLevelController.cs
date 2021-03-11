using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Triggers;
using UnityEngine;

public class FinalLevelController : MonoBehaviour
{
    public DialogController dialogController;

	public SkillController player;

	public EnemySpawner enemySpawner;

	public PlatformsSpawner platformsSpawner;

	[Space]
	public GameObject BossTriggerGo;
	public GameObject fabricaCamera1;
	public GameObject fabricaCamera2;

	[Space]
	public GameObject platformConsole;

	private string fabricaText = "wow, fabrica";
	private string bossText = "wow, boss";

	private void Awake()
	{
		player.OnPickUpStick(null);

		BossTriggerGo.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(BossEvent(3));

		platformConsole.GetComponentInChildren<InputTrigger>().OnActivate += OnPlatformStop;
	}

	private IEnumerator FabricaEvent(int duration)
	{
		fabricaCamera1.SetActive(true);

		dialogController.SetText(fabricaText, duration);

		yield return new WaitForSeconds(duration);

		fabricaCamera1.SetActive(false);
	}

	private IEnumerator BossEvent(int duration)
	{
		fabricaCamera2.SetActive(true);

		dialogController.SetText(bossText, duration, true);

		yield return new WaitForSeconds(duration);

		fabricaCamera2.SetActive(false);
	}

	private void OnPlatformStop()
	{
		platformsSpawner.StopGenerator();

		StartCoroutine(enemySpawner.Generate());

		StartCoroutine(FabricaEvent(3));
	}
}
