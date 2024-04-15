using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
	public static NotificationManager Instance { get; private set; }
	
	public RectTransform NotificationTransform;
	public TextMeshProUGUI NotificationText;
	
	private float _OriginalScale = 1.0f;
	
	
	public Stack<string> MessageQueue = new Stack<string>();	

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
		
		_OriginalScale = NotificationTransform.localScale.y;
		NotificationTransform.DOScaleY(0.0f, 0f);
		NotificationTransform.gameObject.SetActive(false);
		NotificationText.text = string.Empty;
	}
	
	
	private void ShowPanel()
	{
		NotificationTransform.gameObject.SetActive(true);
		NotificationTransform.DOScaleY(_OriginalScale, 0.15f);
	}
	
	private void HidePanel()
	{
		NotificationText.text = string.Empty;
		NotificationTransform.DOScaleY(0.0f, 0.15f).OnComplete(() => NotificationTransform.gameObject.SetActive(false));
	}	

	public void Notify(string message)
	{
		
		if(string.IsNullOrEmpty(message))
			return;
			
		NotificationText.text = message;
		ShowPanel();
		LeanTween.delayedCall(2f, ()=>{	HidePanel();});
	}


	





}
