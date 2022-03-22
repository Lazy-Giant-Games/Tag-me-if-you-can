using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallrunDetector : MonoBehaviour
{
    public PlayerAnimator animator;
    private bool m_isWallRunning;
    [Header("Detection Config")]
    public float wallrunDist;

    [Header("Detected Contacts")]
    public bool contactR;
    public bool contactL;

    [Header("Additional Info")]
        [HideInInspector]
    public Vector3 wallNormal;


    void Update()
    {
        contactR = false;
        contactL = false;

        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.right), out hit, wallrunDist, layerMask)) {
			if (!m_isWallRunning) {
                animator.WallRunRight();
                m_isWallRunning = true;
            }
            wallNormal = hit.normal;
            contactR = true;
        } else if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.left), out hit, wallrunDist, layerMask)) {
            wallNormal = hit.normal;
            contactL = true;
            if (!m_isWallRunning) {
                animator.WallRunLeft();
                m_isWallRunning = true;
            }
        } else {
			if (m_isWallRunning) {
                m_isWallRunning = false;
                animator.PlayLowJump();
            }
            
        }
    }
}
