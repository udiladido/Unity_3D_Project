using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class launchPad : MonoBehaviour
{

    public float jumpForce;


    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);

    }


}
