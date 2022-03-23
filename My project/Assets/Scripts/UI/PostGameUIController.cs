using TagMeIfYouCan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace TagMeIfYouCan {
    public class PostGameUIController : MVCUIController, PostGameUIView.IListener {
        [SerializeField]
        private PostGameUIModel m_postGameUIModel;
        private PostGameUIView m_postGameUIView;

        #region Mono Calls
        private void Start() {
            InstantiateUI();
        }

        private void OnDestroy() {
            m_postGameUIView.Unsubscribe(this);
        }
        #endregion
        //Call this function to Instantiate the UI, on the callback you can call initialization code for the said UI
        [ContextMenu("Instantiate UI")]
        public override void InstantiateUI() {
            PostGameUIView.Create(_canvas, m_postGameUIModel, (p_ui) => {
                m_postGameUIView = p_ui;
                m_postGameUIView.Subscribe(this);

                InitUI(p_ui.UIModel, p_ui);
            });
        }

        #region IngameUIView.IListener
        public void OnClickPlay() { HideUI(); }
        #endregion
    }
}