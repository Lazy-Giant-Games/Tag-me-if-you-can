using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;
public class ClikManager : MonoBehaviour {

    public static ClikManager Instance = null;
    private void OnEnable() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void OnDisable() {
        if (Instance == this) {
            Instance = null;
        }
    }
    private void Start() {
        TTPCore.Setup();
    }

    //IMPORTANT: LEVEL IS FORCED to 1 because for now we only have 1 level
    public void CallClikEventGameWin(int p_level = 1) {
        var parameters = new Dictionary<string, object>();
        parameters.Add("Game " + (p_level).ToString() + " Victory", "Level " + (p_level).ToString());
        TTPGameProgression.FirebaseEvents.MissionComplete(parameters);
    }

    //IMPORTANT: LEVEL IS FORCED to 1 because for now we only have 1 level
    public void CallClikEventGameLose(int p_level = 1) {
        var parameters = new Dictionary<string, object>();
        parameters.Add("Game " + (p_level).ToString() + " Fails", "Level " + (p_level).ToString());
        TTPGameProgression.FirebaseEvents.MissionFailed(parameters);
    }

    //IMPORTANT: LEVEL IS FORCED to 1 because for now we only have 1 level
    public void CallClikEventGameStart(int p_level = 1) {
        var parameters = new Dictionary<string, object>();
        parameters.Add("Game " + (p_level).ToString() + " start", "Level " + (p_level).ToString());
        TTPGameProgression.FirebaseEvents.MissionStarted((p_level), parameters);
    }
}