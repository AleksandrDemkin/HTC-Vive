using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centering : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private CapsuleCollider myCol;

    private Vector3 vec;

    private void OnValidate()
    {
        myCol = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        FIndTeleportPivotAndTarget();
        vec.y = myCol.center.y;
    }

    // Update is called once per frame
    void Update()
    {
        vec.x = pivot.localPosition.x;
        vec.z = pivot.localPosition.z;

        myCol.center = vec;
    }

    private void FIndTeleportPivotAndTarget()
    {
        foreach (var cam in Camera.allCameras)
        {
            if (!cam.enabled) { continue; }
            if (cam.stereoTargetEye != StereoTargetEyeMask.Both) { continue; }
            pivot = cam.transform;
        }
    }
}
