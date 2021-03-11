using System.Collections;
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

	[Space]
	public GameObject dangerTrigger;

	private string startText = "There are many rumors about these islands. I have come here to reveal all the secrets.";

	private string statueText = "A robot statue on the island? Interesting...";
	private string elevatorText = "The elevator has long been destroyed, I have to find another way.";
	private string robotText = "These are the remains of a robot, where are they from here?";
	private string mashineText = "Ominous thing, lucky it's off.";

	private string GoToCaveText = "It's better not to go to that island.";
	private string GoToCave2Text = "It's like a cave entrance, I'll have to jump.";

	private string consoleText = "The console looks working, only a few energy crystals are needed.";

	private string dungeosText = "Whoa, it has become quite dangerous";

	private void Awake()
	{
		StartCoroutine(StartEvent(7));

		ExitLevelTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += EndLevel;

		statueTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(StatueEvent(3));
		elevatorTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(ElevatorEvent(3));
		robotTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(RobotEvent(3));
		mashineTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => MashineEvent(3);
		GoToCaveTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(GoToCaveEvent(3));

		consoleTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => ConsoleEvent(3);

		dangerTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => dialogController.SetText(dungeosText, 4);
	}

	private void EndLevel()
	{
		SceneManager.LoadScene(4);
	}

	private IEnumerator StartEvent(int duration)
	{
		dialogController.SetText(startText, duration);
		player.SetInput(false);

		yield return new WaitForSeconds(duration);

		player.SetInput(true);
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
