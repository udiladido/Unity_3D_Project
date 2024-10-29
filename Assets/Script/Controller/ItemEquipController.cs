using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemEquipController : MonoBehaviour
{
    private Dictionary<string, ChangeSkinnedMesh> equipmentParts;

    private void InitializeEquipment()
    {
        equipmentParts = new Dictionary<string, ChangeSkinnedMesh>();
        ChangeSkinnedMesh[] EquipMesh = FindObjectsOfType<ChangeSkinnedMesh>();

        foreach (var part in EquipMesh)
        {
       
            string partType = part.gameObject.name; 
            equipmentParts[partType] = part;
            part.Initialize();

        }

    }



    public void Equip(Equiparts partType, Mesh newMesh)
    {
        if (equipmentParts.TryGetValue(partType.ToString(), out var part))
        {
            part.ChangeMesh(newMesh);
        }


    }


        
   




}
