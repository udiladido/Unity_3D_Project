using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class ChangeSkinnedMesh : MonoBehaviour
{

    public SkinnedMeshRenderer skinnedMeshRenderer;

    public virtual void Initialize()
    {

        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

    }


    public virtual void ChangeMesh(Mesh newMesh)
    {

        if (skinnedMeshRenderer != null)
        {
            skinnedMeshRenderer.sharedMesh = newMesh;
        }

    }
    

}
