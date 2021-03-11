using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using Unity.LEGO.Behaviours.Triggers;
using UnityEngine;

public class CaveLevelManager : MonoBehaviour
{
    public DialogController dialogController;
    public SkillController player;

    [Space]
    public GameObject stickTrigger;
    public GameObject stickCamera;

    [Space]
    public GameObject targetTrigger;

    [Space]
    public PickupAction magicStick;
    public GameObject lookUpCamera;

    private string startText = "It looks like this cave is also dangerous.";
    private string stickText = "The robots were hiding something of value here.";
    private string targetText = "This item can emit powerful charges. The robot does not look dangerous, I will try it on it.";

    void Start()
    {
        dialogController.SetText(startText, 5);

        magicStick.OnCollected += StickCollected;

        stickTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => StartCoroutine(StickEvent(3));
        targetTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += () => TargetEvent(3);
    }

    private void StickCollected(PickupAction action)
	{
        lookUpCamera.SetActive(true);
	}

    private IEnumerator StickEvent(int duration)
	{
        dialogController.SetText(stickText, duration);
        stickCamera.gameObject.SetActive(true);
        player.SetInput(false);

        yield return new WaitForSeconds(duration);

        stickCamera.gameObject.SetActive(false);
        player.SetInput(true);
    }

    private void TargetEvent(int duration)
	{
        dialogController.SetText(targetText, duration);
    }
}
