using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CardSelectionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[SerializeField] private float _verticalMoveAmount = 30f;
	[SerializeField] private float _moveTime = 0.1f;
	[Range(0f, 2f), SerializeField] private float _scaleAmount = 1.1f;
	
	
	[SerializeField] private RectTransform _rectTransform;
	
	[SerializeField] private GameObject _parent;
	
	public UnityEvent OnCardClicked;
	
	[HideInInspector]
	private bool _selected = false;
	
	private BaseEventData SavedOnSelectedEventData;

	private Vector3 _startPos;
	private Vector3 _startScale;

	private void Start()
	{
		_startPos = _rectTransform.anchoredPosition;
		_startScale = transform.localScale;
	}
	
	private void Update() {
		if (_selected && Input.GetMouseButtonDown(0) && !GameManager.Paused && !GameManager.Instance.InputBlocked)
		{			
			GameManager.Instance.InputBlockers.Push("CardController");
			OnCardClicked?.Invoke();
		}
		
		if(SavedOnSelectedEventData != null)
			OnSelect(SavedOnSelectedEventData);
	}

	private IEnumerator AnimateCardOnHover(bool startingAnimation)
	{
		Vector3 endPosition;
		Vector3 endScale;

		float elapsedTime = 0f;
		while (elapsedTime < _moveTime)
		{
			elapsedTime += Time.deltaTime;

			if (startingAnimation)
			{
				endPosition = _startPos + new Vector3(0f, _verticalMoveAmount, 0f);
				endScale = _startScale * _scaleAmount;
			}

			else
			{
				endPosition = _startPos;
				endScale = _startScale;
			}

			Vector3 lerpedPos = Vector3.Lerp(_rectTransform.anchoredPosition, endPosition, (elapsedTime / _moveTime));
			Vector3 lerpedScale = Vector3.Lerp(transform.localScale, endScale, (elapsedTime / _moveTime));

			_rectTransform.anchoredPosition = lerpedPos;
			transform.localScale = lerpedScale;

			yield return null;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		eventData.selectedObject = this.gameObject;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		eventData.selectedObject = null;
	}

	public void OnSelect(BaseEventData eventData)
	{
		if(TurnBasedManager.Instance.IsPlayerTurn && !GameManager.Paused && !GameManager.Instance.InputBlocked)
		{
			SavedOnSelectedEventData = null;
			StartCoroutine(AnimateCardOnHover(true));
			_selected = true;			
		}else
		{
			SavedOnSelectedEventData = eventData;
			//reset variable here just in case (or if we add enter key binding to new turn...)
			_selected = false;
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		StartCoroutine(AnimateCardOnHover(false));
		_selected = false;
		SavedOnSelectedEventData = null;
	}
}
