using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Opponent : MonoBehaviour, IOpponent
{
	public OpponentDataSO OpponentData;
	
	public int Health;
	public string GUID;
	public SpriteRenderer OpponentSpriteRenderer;
	public Transform SpriteOriginPoint;
	
	float _opponentOriginalScaleY;
	
	private void Awake() {
		_opponentOriginalScaleY = SpriteOriginPoint.localScale.y;
		SpriteOriginPoint.transform.DOScaleY(0,0);
		
		SpriteOriginPoint.transform.localScale = new Vector3(SpriteOriginPoint.transform.localScale.x, 0, SpriteOriginPoint.transform.localScale.z);
		
	}
	
	public void Attack()
	{
		throw new System.NotImplementedException();
	}

	public void Die()
	{
		throw new System.NotImplementedException();
	}

	public Opponent Clone()
	{
		return (Opponent)MemberwiseClone();
	}

	public Opponent()
	{
		GUID = System.Guid.NewGuid().ToString();
	}
	public Opponent(OpponentDataSO opponenentData)
	{
		GUID = System.Guid.NewGuid().ToString();
		OpponentData = opponenentData;
	}
	
	
	public void SpawnNewOpponent(OpponentDataSO newOpponentData)
	{
		//TODO: flesh this out a bit more with some animations etc...
		//How do we wait to continue. events???
		
		OpponentData = newOpponentData;
		Health = OpponentData.Health;
		OpponentSpriteRenderer.sprite = OpponentData.Image;
		SpriteOriginPoint.transform.DOKill();
		
		SoundManager.Instance.PlaySound("OpponentGrowl");
		SpriteOriginPoint.transform.DOScaleY(_opponentOriginalScaleY,1f).OnComplete(()=>{			
			SpriteOriginPoint.transform.DOShakePosition(1f,0.5f).OnComplete(()=>{				
		 		OpponentManager.OnOpponentReadyForFight?.Invoke();		
				SpriteOriginPoint.transform.DOMoveY(0.5f, 1.5f).OnComplete(()=>{SpriteOriginPoint.transform.DOScaleY(0.9f,0.3f);}).SetLoops(-1,LoopType.Yoyo);
			});			
		});
		
		
		
		
		//play animation here.
		//once animation done.
		// OpponentManager.OnOpponentReadyForFight?.Invoke();
	}
}


