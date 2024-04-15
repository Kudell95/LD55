using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class VisualAnimationController : MonoBehaviour
{	
   public GameObject ObjectPrefab;
   public Transform AnimationDestination;
   public Transform prefabParent;
   
   public void PlayAttackAnimation(CardDataSO cardData, TweenCallback onAttackApex, TweenCallback onComplete)
   {
		//spawn object, pass in image
		GameObject VisualObject = Instantiate(ObjectPrefab, prefabParent);
		//start with no alpha/transperant
		
		VisualObject.transform.localPosition = transform.position;
		SpriteRenderer sr = VisualObject.GetComponent<SpriteRenderer>();
		
		//set to white but transperant
		sr.sprite = cardData.Image;
		
		//TODO: Particle effects here...
		
		sr.DOFade(0, 0).OnComplete(()=>
		{
			sr.DOFade(1, 1.5f).OnComplete(()=>
			{
				VisualObject.transform.DOLocalMove(AnimationDestination.transform.position, 0.1f).OnComplete(()=>			
				{
					onAttackApex?.Invoke();				
					
					VisualObject.transform.DOLocalMove(transform.position, 0.5f).OnComplete(()=>{
						
						sr.DOFade(0,1.5f).OnComplete(()=>{
							onComplete?.Invoke();
							Destroy(VisualObject);
							});
					});
				});		
				
			});
		});
   }
   
   
   public void PlayMiscObjectAnimation(CardDataSO cardData, TweenCallback onComplete)
   {
		//spawn object, pass in image
		GameObject VisualObject = Instantiate(ObjectPrefab, prefabParent);
		//start with no alpha/transperant
		
		VisualObject.transform.localPosition = transform.position;
		SpriteRenderer sr = VisualObject.GetComponent<SpriteRenderer>();
		
		//set to white but transperant
		sr.sprite = cardData.Image;
		
		//TODO: Particle effects here...
		
		sr.DOFade(0, 0).OnComplete(()=>
		{
			sr.DOFade(1, 1.5f).OnComplete(()=>{
				sr.DOFade(0, 1.5f);
				VisualObject.transform.DOLocalMoveY(1,1f).OnComplete(()=>{
					onComplete?.Invoke();
					Destroy(VisualObject);
				});		
				
			});
		});
   }
}
