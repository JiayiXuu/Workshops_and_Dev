using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotroller : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start () {
        offset = transform.position - player.transform.position;

    }

    // LateUpdate makes sure that other updates are all completed
    void LateUpdate() {
        transform.position = player.transform.position + offset;

    }

}
