using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Image _icon;

    public Text _text;

    public Sprite[] sprites;

    public void SetText(string text, float duration, int spr = 0)
	{
        gameObject.SetActive(true);

        _text.text = text;

        _icon.sprite = sprites[spr];

        StartCoroutine(Hide(duration));
	}

    private IEnumerator Hide(float duration)
	{
        yield return new WaitForSeconds(duration);

        gameObject.SetActive(false);
	}    
}
