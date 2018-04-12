using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public Transform target;            
    public float smooth = 5f;        

    Vector3 offset;                    

    void Start() {
        offset = target.position.normalized;
    }

    void FixedUpdate() {
        Vector3 targetCameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPos, smooth * Time.deltaTime);
    }
}
