using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeTraverser : MonoBehaviour {
    

    public List<Transform> runningNodes = new List<Transform>();
    public List<Transform> jumpingNodes = new List<Transform>();
    public List<Transform> climbingNodes = new List<Transform>();
    public List<Transform> vaultNodes = new List<Transform>();

    public List<Transform> runningNodes_b = new List<Transform>();
    public List<Transform> jumpingNodes_b = new List<Transform>();
    public List<Transform> climbingNodes_b = new List<Transform>();
    public List<Transform> vaultNodes_b = new List<Transform>();

    

	public void RandomizePath() {
        if (GameManager.Instance.randomizePath) {
            if (UnityEngine.Random.Range(0, 100) > 50) {
                GameManager.Instance.targetPath = GameManager.PATH.LEFT_PATH;
            } else {
                GameManager.Instance.targetPath = GameManager.PATH.RIGHT_PATH;
            }
        }
        
	}
}
