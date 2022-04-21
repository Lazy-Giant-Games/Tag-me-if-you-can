using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeTraverser : MonoBehaviour {
    public enum PATH { LEFT_PATH, RIGHT_PATH }
    public PATH targetPath = PATH.RIGHT_PATH;

    public List<Transform> runningNodes = new List<Transform>();
    public List<Transform> jumpingNodes = new List<Transform>();
    public List<Transform> climbingNodes = new List<Transform>();
    public List<Transform> vaultNodes = new List<Transform>();

    public List<Transform> runningNodes_b = new List<Transform>();
    public List<Transform> jumpingNodes_b = new List<Transform>();
    public List<Transform> climbingNodes_b = new List<Transform>();
    public List<Transform> vaultNodes_b = new List<Transform>();

    public bool randomizePath;

	public void RandomizePath() {
        if (randomizePath) {
            if (UnityEngine.Random.Range(0, 100) > 50) {
                targetPath = PATH.LEFT_PATH;
            } else {
                targetPath = PATH.RIGHT_PATH;
            }
        }
        
	}
}
