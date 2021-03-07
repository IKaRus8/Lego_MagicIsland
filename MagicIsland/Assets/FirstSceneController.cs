using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
	public SkillController player;
	public DialogController dialogController;
	public GameObject ExitLevelTrigger;
	[Space]
	public GameObject statueCamera;
	public GameObject statueTrigger;

	[Space]
	public GameObject elevatorCamera;
	public GameObject elevatorTrigger;

	[Space]
	public GameObject robotCamera;
	public GameObject robotTrigger;

	[Space]
	public GameObject mashineTrigger;

	[Space]
	public GameObject GoToCaveCamera;
	public GameObject GoToCave2Camera;
	public GameObject GoToCaveTrigger;

	[Space]
	public GameObject consoleTrigger;

	private string statueText = "Wow, statue";
	private string elevatorText = "Wow, elevator";
	private string robotText = "Wow, robot";
	private string mashineText = "Wow, death";

	private string GoToCaveText = "Wow, robots";
	private string GoToCave2Text = "Wow, cave";

	private string consoleText = "Wow, cave";

	private void Awake()
	{
		ExitLevelTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += CutScene;

		statueTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(StatueEvent(3));
		elevatorTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(ElevatorEvent(3));
		robotTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(RobotEvent(3));
		mashineTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => MashineEvent(3);
		GoToCaveTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(GoToCaveEvent(3));

		consoleTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => ConsoleEvent(3);
	}

	private void CutScene()
	{
		SceneManager.LoadScene(4);
	}

	private IEnumerator StatueEvent(int duration)
	{
		dialogController.SetText(statueText, duration);
		statueCamera.SetActive(true);
		player.SetInput(false);

		yield return new WaitForSeconds(duration);

		statueCamera.SetActive(false);
		player.SetInput(true);
	}

	private IEnumerator ElevatorEvent(int duration)
	{
		dialogController.SetText(elevatorText, duration);
		elevatorCamera.SetActive(true);
		player.SetInput(false);

		yield return new WaitForSeconds(duration);

		elevatorCamera.SetActive(false);
		player.SetInput(true);
	}

	private IEnumerator RobotEvent(int duration)
	{
		dialogController.SetText(robotText, duration);
		robotCamera.SetActive(true);
		player.SetInput(false);

		yield return new WaitForSeconds(duration);

		robotCamera.SetActive(false);
		player.SetInput(true);
	}

	private void MashineEvent(int duration)
	{
		dialogController.SetText(mashineText, duration);
	}

	private IEnumerator GoToCaveEvent(int duration)
	{
		dialogController.SetText(GoToCaveText, duration);
		GoToCaveCamera.SetActive(true);
		player.SetInput(false);

		yield return new WaitForSeconds(duration);

		dialogController.SetText(GoToCave2Text, duration);
		GoToCaveCamera.SetActive(false);
		GoToCave2Camera.SetActive(true);

		yield return new WaitForSeconds(duration);

		GoToCave2Camera.SetActive(false);
		player.SetInput(true);
	}

	private void ConsoleEvent(int duration)
	{
		dialogController.SetText(consoleText, duration);
	}
}
