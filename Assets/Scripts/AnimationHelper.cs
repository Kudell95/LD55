using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
	public Color OnHitColor;
	
	public void OnHit(Transform _transform)
	{
		_transform.DOShakePosition(0.1f, 0.5f, 10, 50, false);
	}
	
	public void OnHit(Transform _transform, SpriteRenderer spriteRenderer)
	{
		_transform.DOShakePosition(0.1f, 0.5f, 10, 50, false);
		Color color = spriteRenderer.color;
		spriteRenderer.DOColor(OnHitColor, 0.1f).OnComplete(()=>
		{
			spriteRenderer.DOColor(color, 0.1f);
		});
		
	}
	
	
	
	public void OnHit(Transform _transform, SpriteRenderer spriteRenderer, TweenCallback onComplete)
	{
		_transform.DOShakePosition(0.1f, 0.5f, 10, 50, false);
		Color color = spriteRenderer.color;
		spriteRenderer.DOColor(OnHitColor, 0.1f).OnComplete(()=>
		{
			spriteRenderer.DOColor(color, 0.1f).OnComplete(onComplete);
		});
		
	}
	
	// public void OnDeath(Transform _transform)
	// {
	// 	_transform.DOScaleX(0,0.2f);
	// }
}
