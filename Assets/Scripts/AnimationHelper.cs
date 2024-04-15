using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
	public void OnHit(Transform _transform)
	{
		_transform.DOShakePosition(0.1f, 0.2f, 10, 50, false);
	}
	
	public void OnDeath(Transform _transform)
    {
    	_transform.DOScaleX(0,0.2f);
    }
}
