using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace TagMeIfYouCan.UI {
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class MVCUIModel : MonoBehaviour {
		public List<GameObject> hideableUIs = new List<GameObject>();
		protected CanvasGroup _canvasGroup;

		public Transform parentDisplay;
		
		private void Awake() { _canvasGroup = GetComponent<CanvasGroup>(); }

		protected void SetInteractable(bool interactable) { _canvasGroup.interactable = interactable; }

		public void ShowHideableUIs() {
			hideableUIs.ForEach((eachHideableUI) => {
				if (eachHideableUI.GetComponent<Button>() != null) {
					eachHideableUI.GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 1f);
				} else {
					eachHideableUI.SetActive(true);
				}
			});
		}
		public void HideHideableUIs() {
			hideableUIs.ForEach((eachHideableUI) => {
				if (eachHideableUI.GetComponent<Button>() != null) {
					eachHideableUI.GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 0.001f);
				} else {
					eachHideableUI.SetActive(false);
				}
			});
		}
	}
}