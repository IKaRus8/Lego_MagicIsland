using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Behaviours.Actions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SkillController player;

    public PickupAction magicStick;

	private void Awake()
	{
		magicStick.OnCollected += player.OnPickUpStick;
	}
}
