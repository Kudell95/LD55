using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
	//NOTE: subject to change given game.
	public int EntrySceneIndex;
	
	private void Awake() {
		SoundManager.Instance?.PlayMusic("MenuTheme", true);
	}
	
	public void StartGame()
	{
		SoundManager.Instance?.PlaySound("ButtonClick");
		SceneTransitionManager.Instance.LoadScene(EntrySceneIndex);
	}
	
   public void Quit()
   {
	   SoundManager.Instance?.PlaySound("ButtonClick");	
	   ModalWindow.Main.DisplayConfirmScreen("Quit", "Are you sure you want to quit?", () => Application.Quit());
   }
}
