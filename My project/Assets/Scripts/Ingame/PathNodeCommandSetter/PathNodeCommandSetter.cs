using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNodeCommandSetter : MonoBehaviour {
    public NodeTraverser nodeTraverser;
    public CommandControlledBot commandControlledBot;

    public virtual void SetPathNodeLeft() { }
    public virtual void SetPathNodeRight() { }
    public void StartPlay() {
        nodeTraverser.RandomizePath();
        if (GameManager.Instance.targetPath == GameManager.PATH.RIGHT_PATH) {
            SetPathNodeRight();
        } else {
            SetPathNodeLeft();
        }

        commandControlledBot.StartedRunning = true;
    }
}
