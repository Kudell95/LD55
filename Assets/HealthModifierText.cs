using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class HealthModifierText : MonoBehaviour
{
	
	public float MaxPositionModifier = 1.0f;
	public float MinPositionModifier = 0.1f;
	
	
	public Color DamageColour;
	public Color HealColour;
	
	private Vector3 _startPosition;
	
	public GameObject TextPrefab;
	
	private void Start()
	{
		_startPosition = transform.position;
	}
	
	
	public void ShowDamage(int damage)
	{
		string text = $"-{damage.ToString()}";
		Show(DamageColour, text);
	}
	
	public void ShowHeal(int heal)
	{
		string text = $"+{heal.ToString()}";
		Show(HealColour, text);
	}
	
	
	public void Show(Color color, string text)
	{
		var textObject = Instantiate(TextPrefab,transform);
		textObject.transform.position = _startPosition;
		TMP_Text _text = textObject.GetComponent<TMP_Text>();
		_text.transform.position = new Vector3(_startPosition.x + Random.Range(MinPositionModifier, MaxPositionModifier), _startPosition.y + Random.Range(MinPositionModifier, MaxPositionModifier), _startPosition.z);
		_text.color = color;
		_text.text = text;
		
		_text.DOFade(1, 0.01f);
		_text.transform.DOLocalMoveY(1,5);
		LeanTween.delayedCall(0.5f, ()=>
		{
			Hide(_text);
		});
	}
	
	public void Hide(TMP_Text _text)
	{
		_text.DOFade(0, 0.5f).OnComplete(()=>
		{
			_text.transform.DOKill();
			_text.transform.position = _startPosition;
			Destroy(_text.gameObject);
		});
	}
	
}
