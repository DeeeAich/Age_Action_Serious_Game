using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTransparency : MonoBehaviour
{
    [Header("Upstairs")]
    [SerializeField] GameObject upstairsObject;

    [Header("Transparency")]
    [SerializeField] Transform player;
    [SerializeField] RaycastHit[] currentHits;
    Vector3 rayDirection;
    float rayDistance;
    [SerializeField] float amountRadius = 0.5f;

    private void Start()
    {
        currentHits = new RaycastHit[0];
        rayDirection = player.position - Camera.main.transform.position;
        rayDistance = Vector3.Distance(player.position, Camera.main.transform.forward) - amountRadius * 2;
    }

    private void Update()
    {

        if(currentHits.Length > 0)
            foreach(RaycastHit hit in currentHits)
            {
                if (hit.transform.TryGetComponent<ObjectTransparent>(out ObjectTransparent temp))
                    temp.ChangeMat(false);
            }

        currentHits = Physics.SphereCastAll(Camera.main.transform.position, amountRadius, rayDirection, rayDistance);

        if(currentHits.Length > 0)
            foreach(RaycastHit hit in currentHits)
            {
                print(hit.transform.name);
                if (hit.transform.TryGetComponent<ObjectTransparent>(out ObjectTransparent temp))
                    temp.ChangeMat(true);
            }

    }

    public void MoveStairs(bool up) =>
        upstairsObject.SetActive(up);

}
