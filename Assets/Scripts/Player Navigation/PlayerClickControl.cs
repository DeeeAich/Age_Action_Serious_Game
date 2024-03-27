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

    [SerializeField] bool downStairs = true;

    [SerializeField] WallTransparency wallController;

    bool movingBetweenFloors;

    private void Start()
    {
        agentControls = GetComponent<NavMeshAgent>();
        wallController = FindObjectOfType<WallTransparency>();
    }

    private void Update()
    {
        
        if(Input.GetMouseButton(0) && !movingBetweenFloors)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20f, layerMask: groundMask))
            {

                print(hit.collider.tag);

                if (hit.collider.tag != "Stairs")
                    agentControls.SetDestination(hit.point);
                else if (downStairs)
                {
                    //hit.collider.GetComponent<ObjectTransparent>().enabled = false;

                    agentControls.SetDestination(wallController.locations[1].position);
                    downStairs = false;

                    movingBetweenFloors = true;

                }
                else
                {
                    //hit.collider.GetComponent<ObjectTransparent>().enabled = true;

                    agentControls.SetDestination(wallController.locations[0].position);
                    downStairs = true;

                    movingBetweenFloors = true;
                }
            }
        }
        else if (agentControls.remainingDistance < 2)
        {
            movingBetweenFloors = false;
            wallController.MoveStairs(!downStairs);
        }


    }

    private void FixedUpdate()
    {
        
        camera.transform.position = transform.position;

    }

}
