using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraFollow : MonoBehaviour {

    private CinemachineVirtualCamera virtualCamera;

	// Use this for initialization
	void Start () {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = GameManager.Instance.Player;
	}
	
	
}
