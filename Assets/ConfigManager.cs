using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
	public static ConfigManager Instance;
	public ConfigSO ConfigObject;
	
	private void Awake() {
		if(Instance == null)
		{
			Instance = this;
		}else
		{
			Destroy(this);
		}
	}
	
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
