using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowQuestPointer : MonoBehaviour {
    [SerializeField] private Sprite arrowSprite;
    [SerializeField] private Sprite crossSprite;
    public EnemyProgressBar progressBar;
    public CommandControlledBot target;
    public RectTransform pointerRectTransform;
    public Image pointerImage;
    public bool m_isOffScreen;
    public Text distanceText;
    public void SetEnemy(CommandControlledBot p_enemy) {
        target = p_enemy;
    }
    private void Update() {
        if (target == null) {
            return;
        }
        if (!target.StartedRunning) {
            distanceText.text = string.Empty;
            pointerImage.enabled = false;
            return;
        }
        Vector3 toPosition = target.transform.position;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        //float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
        //pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        float borderSize = 50f;
        Vector3 targetPositionScreenpoint = Camera.main.WorldToScreenPoint(target.transform.position);
        m_isOffScreen = targetPositionScreenpoint.x <= borderSize || targetPositionScreenpoint.x >= Screen.width || targetPositionScreenpoint.y <= 0 || targetPositionScreenpoint.y >= Screen.height;

        if (m_isOffScreen) {
            //pointerImage.enabled = true;
            distanceText.text = progressBar.textDistance.text;
            Vector3 cappedTargetPosition = targetPositionScreenpoint;
            if (cappedTargetPosition.x <= borderSize) cappedTargetPosition.x = borderSize;
            if (cappedTargetPosition.x >= Screen.width - borderSize) cappedTargetPosition.x = Screen.width - borderSize;
            if (cappedTargetPosition.y <= borderSize) cappedTargetPosition.y = borderSize;
            if (cappedTargetPosition.y >= Screen.height - borderSize) cappedTargetPosition.y = Screen.height - borderSize;

            Vector3 pointerWorldPosition = cappedTargetPosition;
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        } else {
            //pointerImage.enabled = false;
            distanceText.text = string.Empty;
            Vector3 pointerWorldPosition = targetPositionScreenpoint;
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        }
    }
}