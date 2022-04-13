using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TagMeIfYouCan.UI;
public class EndSceneAnimator : MonoBehaviour
{

    public GameObject goFightCloud;
    public GameObject girlPosition;
    public IngameUIController ingameUIController;
    private void OnEnable() {
        StartCoroutine(DelayedFXFight());

    }
    IEnumerator DelayedFXFight() {
        ingameUIController.DoFadeOut();
        yield return new WaitForSeconds(1.25f);
        goFightCloud.SetActive(true);
        goFightCloud.transform.position = girlPosition.transform.position;
    }
}
