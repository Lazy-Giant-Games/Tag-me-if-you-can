using System;
using TagMeIfYouCan.UI;
using UnityEngine;

public class IngameUIView : MVCUIView {
    #region interface for listener
    public interface IListener {
        void OnClickRestart();
    }
    #endregion
    #region MVC Properties and functions to override
    /*
     * this will be the reference to the model 
     * */
    public IngameUIModel UIModel {
        get {
            return _baseAssetModel as IngameUIModel;
        }
    }

    /*
     * Call this Create method to Initialize and instantiate the UI.
     * There's a callback on the controller if you want custom initialization
     * */
    public static void Create(Canvas p_canvas, IngameUIModel p_assets, Action<IngameUIView> p_onCreate) {
        var go = new GameObject(typeof(IngameUIView).ToString());
        var gui = go.AddComponent<IngameUIView>();
        var assetsInstance = Instantiate(p_assets);
        gui.Init(p_canvas, assetsInstance);
        if (p_onCreate != null) {
            p_onCreate.Invoke(gui);
        }
    }
    #endregion

    public void UpdateNearProgressBarValue(float p_value) {
        UIModel.imgDistanceProgressBar.fillAmount = p_value;
    }

    public void UpdateGameProgressBarValue(float p_value) {
        UIModel.imgGameProgressBar.fillAmount = p_value;
    }

    #region Subscribe/Unsubscribe for IListener
    public void Subscribe(IListener p_listener) {
        UIModel.onClickRestart += p_listener.OnClickRestart;
    }
    public void Unsubscribe(IListener p_listener) {
        UIModel.onClickRestart -= p_listener.OnClickRestart;
    }
    #endregion
}