using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Image icon;

	public float refreshTime = 1;

	private float coolDawnTime;

	private Vector3 punchScale = new Vector3(1.2f, 1.2f);
	private Vector3 punchStep = new Vector3(0.03f, 0.03f);

	public bool CanUse { get; set; }

	private void Awake()
	{
		CanUse = true;
	}

	public void CoolDawn()
	{
		CanUse = false;

		coolDawnTime = 0;

		StartCoroutine(FillIcon());
	}

	private IEnumerator FillIcon()
	{
		while(coolDawnTime < refreshTime)
		{
			icon.fillAmount = coolDawnTime;

			coolDawnTime += Time.deltaTime;

			yield return new WaitForFixedUpdate();
		}

		while(icon.transform.localScale.x < punchScale.x)
		{
			icon.transform.localScale += punchStep;

			yield return new WaitForFixedUpdate();
		}

		while (icon.transform.localScale.x > 1)
		{
			icon.transform.localScale -= punchStep;

			yield return new WaitForFixedUpdate();
		}

		icon.transform.localScale = Vector3.one;

		CanUse = true;
	}
}
