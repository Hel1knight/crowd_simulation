using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //Camera
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;

    public Transform cam;
    private Vector2 mouseLook;
    private Vector2 smoothV;


    //Player
    public float walkSpeed = 10;
    public float runSpeed = 20;
    public float strafingSpeed = 10;

    private float movementSpeed;
    private CharacterController charController;




    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        if (!cam)
            cam = transform.Find("Camera");

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {

        CameraMovement();

        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
           // Cursor.lockState = CursorLockMode.None;
        }

    }


    private void CameraMovement()
    {

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;

        
        cam.localRotation = Quaternion.AngleAxis(Mathf.Clamp(-mouseLook.y, -70f, 70f), Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up);

    }
    private void PlayerMovement()
    {

        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            transform.Translate(horizInput * runSpeed * Time.deltaTime, 0, vertInput * strafingSpeed * Time.deltaTime);
        else
            transform.Translate(horizInput * walkSpeed * Time.deltaTime, 0, vertInput * strafingSpeed * Time.deltaTime);

    }



}