using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveUILoader : MonoBehaviour
{
	public int UISceneIndex;
	
	private void Awake() {
		SceneManager.LoadScene(UISceneIndex, LoadSceneMode.Additive);
	}
}
