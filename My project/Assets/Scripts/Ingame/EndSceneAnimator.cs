using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TagMeIfYouCan.UI;
public class EndSceneAnimator : MonoBehaviour {

    public GameObject goFightCloud;
    public GameObject girlPosition;
    public IngameUIController ingameUIController;
    private void OnEnable() {
        GetComponentInChildren<Animator>().enabled = false;
        if (GameManager.Instance.DoesLevelHasAI()) {
            StartCoroutine(DelayedFXFight());
        } else {
            ingameUIController.DoFadeOut();
            GetComponentInChildren<Animator>().gameObject.SetActive(false);
            GameObject.FindObjectOfType<PlayerController>().transform.position = Vector3.zero;
        }
        GameObject.Find("Finish_Line").SetActive(false);
    }
    IEnumerator DelayedFXFight() {
        GetComponentInChildren<Animator>().enabled = true;
        ingameUIController.DoFadeOut();
        yield return new WaitForSeconds(1.25f);
        goFightCloud.SetActive(true);
        goFightCloud.transform.position = girlPosition.transform.position;
    }
}
