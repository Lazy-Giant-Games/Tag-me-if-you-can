using System;
using TagMeIfYouCan.UI;
using UnityEngine.UI;
using UnityEngine;

public class PostGameUIModel : MVCUIModel {

    public Action onClickPlay;
    public Button btnPlay;
    public GameObject goWin;
    public GameObject goLose;
    private void OnEnable() {
        btnPlay.onClick.AddListener(OnClickPlay);
    }
    private void OnDisable() {
        btnPlay.onClick.RemoveListener(OnClickPlay);
    }
    private void OnClickPlay() {
        onClickPlay?.Invoke();
    }
}