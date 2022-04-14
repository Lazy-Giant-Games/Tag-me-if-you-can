using System;
using TagMeIfYouCan.UI;
using UnityEngine.UI;
using UnityEngine;

public class IngameUIModel : MVCUIModel {

    public Action onClickRestart;

    public Button btnRestart;

    public Image imgGameProgressBar; //how near the player to enemy
    public Image imgFade;

    public GameObject goTutorial;
    private void OnEnable() {
        btnRestart.onClick.AddListener(OnClickRestart);
    }
    private void OnDisable() {
        btnRestart.onClick.RemoveListener(OnClickRestart);
    }
    private void OnClickRestart() {
        onClickRestart?.Invoke();
    }
}