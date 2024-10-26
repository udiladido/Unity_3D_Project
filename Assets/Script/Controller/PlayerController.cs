using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5;
    public Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform CameraContainer;
    public float minXLook = - 85f;
    public float maxXLook = 80f;
    private float camCurXRot;
    public float lookSensitivity = 0.1f;


    [Header("Camera")]
    public float maxZoom;
    public float minZoom;
    private float camCurZoom;
    public float zoomSensitivity;

    private Vector3 initialLocalPosition;
    private Vector2 mouseDelta;
    private Vector2 mouseScroll;
    
    
    private Rigidbody rigidbody;



    public Action PovChange;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        Move();

    }


    private void LateUpdate()
    {

        CameraLook();


    }

    private void Start()
    {
        initialLocalPosition = CameraContainer.localPosition;
    }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }


    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }


    public void OnPovChangeButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            PovChange?.Invoke();

        }
    }

    public void OnCameraZoom(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {

            mouseScroll = context.ReadValue <Vector2>();

            camCurZoom += mouseScroll.y * zoomSensitivity;
            camCurZoom = Mathf.Clamp(camCurZoom, minZoom, maxZoom);


            Vector3 targetPosition = initialLocalPosition + CameraContainer.forward * camCurZoom;

            CameraContainer.localPosition = Vector3.MoveTowards(CameraContainer.localPosition, targetPosition, zoomSensitivity * Time.deltaTime);

        }
    }


    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {

            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)

        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }


        return false;
    }


    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        CameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0 , 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);

    }




    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;

    }


}
