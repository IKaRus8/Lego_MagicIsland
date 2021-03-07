using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideManager : MonoBehaviour
{
    public GameObject platform;

	public GameObject stopSlideTriggerGo;

	public SlideController FirstSlideController;

	public SlideController SecondSlideController;

	public GameObject endLevelTriggerGo;

	public GameObject secondCubeTrigger;

	public Transform endPoint;

	public Transform player;

	private void Awake()
	{
		platform.GetComponentInChildren<TouchTrigger>().OnActivate += () => StartCoroutine(RemovePlatform());

		stopSlideTriggerGo.GetComponentInChildren<NearbyTrigger>().OnActivate += StopSlide;

		endLevelTriggerGo.GetComponentInChildren<NearbyTrigger>().OnActivate += () => SceneManager.LoadScene(5);

		secondCubeTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () =>  FirstSlideController.StopSlide();
	}

	private IEnumerator RemovePlatform()
	{
		yield return new WaitForSeconds(1);

		Destroy(platform);
	}

	private void StopSlide()
	{
		SecondSlideController.StopSlide();

		player.position = endPoint.position;
	}
}
