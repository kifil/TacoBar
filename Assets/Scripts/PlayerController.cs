using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //For moving arm towards mouse
    [SerializeField]
    private Transform trollArm;
    private Vector2 mousePos;

    //Camera Stuff
    private Camera mainCamera;
    private float cameraDistToArm;

    private void Start() {
        if(trollArm == null) {
            Debug.LogError("No arm assigned to " + this.gameObject.name);
        }
        mainCamera = Camera.main;
        if(mainCamera == null) {
            Debug.LogError("Put a main camera in the scene!!!");
        }
        cameraDistToArm = trollArm.position.z - mainCamera.transform.position.z;
    }

    private void Update() {
        mousePos = Input.mousePosition;
        Vector3 screenPoint = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cameraDistToArm));
        float angle = Mathf.Atan2((screenPoint.y - trollArm.position.y), (screenPoint.x - trollArm.position.x)) * Mathf.Rad2Deg;
        Vector3 rotation = trollArm.rotation.eulerAngles;
        rotation.z = angle;
        trollArm.eulerAngles = rotation;
    }

}
