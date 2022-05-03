using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TagMeIfYouCan.UI;
public class FailSceneAnimator : MonoBehaviour {

    public IngameUIController ingameUIController;
    public GameObject goRunner;
    public GameObject goCamera;
	private void OnEnable() {
        FallingGameOver.OnFalling += FailSceneTrigger;
	}

	private void OnDisable() {
        FallingGameOver.OnFalling -= FailSceneTrigger;
    }
	public void FailSceneTrigger() {
        GameObject.Find("Finish_Line").SetActive(false);
        StartCoroutine(DelayedWalk());
    }
    IEnumerator DelayedWalk() {
        ingameUIController.DoFadeOut();
        goCamera.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        
        GetComponent<Animator>().enabled = true;
        goRunner.SetActive(true);
    }
}
