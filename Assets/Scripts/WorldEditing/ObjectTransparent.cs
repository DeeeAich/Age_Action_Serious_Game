using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransparent : MonoBehaviour
{
    [SerializeField] Material[] materials;
    
    public void ChangeMat(bool playerBehind)
    {
        if (playerBehind)
        {
            GetComponent<MeshRenderer>().material = materials[1];
        }
       else
        {
            GetComponent<MeshRenderer>().material = materials[0];
        }
    }
    

}
