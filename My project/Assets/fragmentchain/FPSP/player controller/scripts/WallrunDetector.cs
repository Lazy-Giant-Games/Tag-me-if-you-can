using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallrunDetector : MonoBehaviour
{

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
            if (hit.collider.gameObject.layer == 11) {
                Debug.LogError(hit.collider.gameObject.name + " -- " + hit.collider.gameObject.layer);
                return;
            }
            wallNormal = hit.normal;
            contactR = true;
        } else if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.left), out hit, wallrunDist, layerMask)) {
            if (hit.collider.gameObject.layer == 11) {
                Debug.LogError(hit.collider.gameObject.name + " -- " + hit.collider.gameObject.layer);
                return;
            }
            wallNormal = hit.normal;
            contactL = true;
            
        } else {
			
        }
    }
}
