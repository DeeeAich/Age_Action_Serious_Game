using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DragObject : MonoBehaviour
{
    CameraManager manager;

    public float zDistance = 10;
    public Camera mainCamera;
    private Vector3 resetPos;
    public bool coliding;
    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("CameraManager").GetComponent<CameraManager>();
        this.enabled = false;
        mainCamera = Camera.main;
        collider = transform.GetComponent<Collider>();

    }

    private void OnEnable()
    { 
        
        zDistance = Vector3.Distance(mainCamera.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
          
            this.enabled = false;
        } 
        Vector3 mousePos = Input.mousePosition;
        Vector3 dragPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 9));
        transform.position = dragPos;
        
    }

    
}
