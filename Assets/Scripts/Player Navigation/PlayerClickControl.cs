using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerClickControl : MonoBehaviour
{

    NavMeshAgent agentControls;

    [SerializeField] LayerMask groundMask;

    [SerializeField] Transform camera;

    private void Start()
    {
        agentControls = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if(Input.GetMouseButton(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 20f, layerMask: groundMask))
            {
                agentControls.SetDestination(hit.point);
            }

        }

    }

    private void FixedUpdate()
    {
        
        camera.transform.position = transform.position;

    }

}
