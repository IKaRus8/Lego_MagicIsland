using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using Unity.LEGO.Behaviours.Triggers;
using Unity.LEGO.Minifig;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SkillController player;

    public PickupAction magicStick;

	public GameObject secondCamera;

	public GameObject cutSceneTriggerGo;

	public Scene caveScene;

	private MinifigController minifigController;

	NearbyTrigger cutSceneTrigger;

	private void Awake()
	{
		cutSceneTrigger = cutSceneTriggerGo.GetComponentInChildren<NearbyTrigger>();
		minifigController = player.GetComponent<MinifigController>();

		cutSceneTrigger.OnActivate += CutScene;

		magicStick.OnCollected += player.OnPickUpStick;

		StartCoroutine(SecondCameraTimer(5));
	}

	private IEnumerator SecondCameraTimer(float time)
	{
		minifigController.SetInputEnabled(false);

		yield return new WaitForSeconds(time);

		secondCamera.SetActive(false);

		minifigController.SetInputEnabled(true);
	}

	private void CutScene()
	{
		SceneManager.LoadScene(4);
	}
}
