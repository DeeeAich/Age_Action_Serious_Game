using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform mainCamera;

    public CinemachineFreeLook[] cameras = new CinemachineFreeLook[2];

    public CinemachineFreeLook playerCamera;
    public CinemachineFreeLook puzzleCamera;

    public CinemachineFreeLook currentCamera;
    public CinemachineFreeLook startCamera;

    // Start is called before the first frame update
    void Start()
    {
        cameras[0] = playerCamera;
        
        mainCamera = Camera.main.transform;

        currentCamera = startCamera;

        for(int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void SwitchCamera(CinemachineFreeLook newCam)
    {
        currentCamera = newCam;

        currentCamera.Priority = 20;

        for(int i = 0;i < cameras.Length;i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameras[1] = puzzleCamera;
        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchCamera(puzzleCamera);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            SwitchCamera(playerCamera);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.collider.tag == "Puzzle")
                {
                    puzzleCamera = hit.transform.GetChild(0).GetComponent<CinemachineFreeLook>();
                }
                
            }
        }
    }
}
