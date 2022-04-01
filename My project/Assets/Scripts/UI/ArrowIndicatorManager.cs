using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicatorManager : MonoBehaviour {
    public List<WindowQuestPointer> pointers = new List<WindowQuestPointer>();
	public CommandControlledBot goAI;
	private void Start() {
		OnLevelInstantiated();
	}

	private void OnDisable() {
		
	}
	private void OnLevelInstantiated() {
		//GameManager.Instance.OnLevelInitialized -= OnLevelInstantiated;
		pointers.ForEach((eachPointer) => eachPointer.gameObject.SetActive(false));
		pointers[0].gameObject.SetActive(true);
		pointers[0].SetEnemy(goAI);
	}
}
