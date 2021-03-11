using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.UI;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Image _icon;

    public Text _text;

    //public OptionsMenuManager menuManager;

    public EnemyManager enemyManager;

    public SkillController player;

    public Sprite[] sprites;

    public void SetText(string text, float duration)
	{
        gameObject.SetActive(true);

        _text.text = text;

        StartCoroutine(Hide(duration));
	}

    public void SetText(string text, float duration, int spr)
	{
        SetText(text, duration);

        _icon.sprite = sprites[spr];
    }

    public void SetText(string text, float duration, bool pause, int spr = 0)
	{
        SetText(text, duration, spr);

        enemyManager.EnemiesState(false);

        //menuManager.CustomPauseActivation(true);
    }

    private IEnumerator Hide(float duration)
	{
        yield return new WaitForSeconds(duration);

        gameObject.SetActive(false);

        enemyManager.EnemiesState(true);

        //menuManager.CustomPauseActivation(false);
    }    
}
