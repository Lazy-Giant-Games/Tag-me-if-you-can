using System;
using TagMeIfYouCan.UI;
using UnityEngine.UI;

public class MainMenuUIModel : MVCUIModel {

    public Action onClickPlay;

    public Button btnPlay;
    
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