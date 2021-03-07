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

	private void Awake()
	{
		magicStick.OnCollected += player.OnPickUpStick;

		//StartCoroutine(SecondCameraTimer(5));
	}

	private IEnumerator SecondCameraTimer(float time)
	{
		player.SetInput(false);

		yield return new WaitForSeconds(time);

		secondCamera.SetActive(false);

		player.SetInput(true);
	}
}
