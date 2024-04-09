using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
	//NOTE: subject to change given game.
	public int EntrySceneIndex;
	
	
	public void StartGame()
	{
		SceneTransitionManager.Instance.LoadScene(EntrySceneIndex);
	}
	
   public void Quit()
   {
	   ModalWindow.Main.DisplayConfirmScreen("Quit", "Are you sure you want to quit?", () => Application.Quit());
   }
}
