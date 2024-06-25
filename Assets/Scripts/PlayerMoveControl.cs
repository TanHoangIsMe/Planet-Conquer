using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveControl : MonoBehaviour
{
    //[SerializeField] InputAction movement;

    [SerializeField] float speed;
    [SerializeField] float horizontalRange = 1f;
    [SerializeField] float verticalRange = 1f;
    [SerializeField] float pitchPosition;
    [SerializeField] float pitchControl;
    [SerializeField] float yawPosition;
    [SerializeField] float rollControl;

    float moveHorizontal,moveVertical;  

    // Update is called once per frame
    void Update()
    {
        Transaltion();
        Rotation();
    }

    private void Rotation()
    {
        float pitch = transform.localPosition.y * pitchPosition
            + moveVertical * pitchControl;
        float yaw = transform.localPosition.x * yawPosition;
        float roll = moveHorizontal * rollControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw,roll);
    }

    private void Transaltion()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        //float moveHorizontal = movement.ReadValue<Vector2>().x;
        //float moveVertical = movement.ReadValue<Vector2>().y;

        float startX = transform.localPosition.x;
        float newX = transform.localPosition.x + moveHorizontal * speed * Time.deltaTime;
        float clampX = Mathf.Clamp(newX, -horizontalRange, horizontalRange);

        float startY = transform.localPosition.y;
        float newY = transform.localPosition.y + moveVertical * speed * Time.deltaTime;
        float clampY = Mathf.Clamp(newY, -verticalRange, verticalRange);

        transform.localPosition = new Vector3(clampX, clampY, transform.localPosition.z);
    }
    //private void OnEnable()
    //{
    //    movement.Enable();
    //}

    //private void OnDisable()
    //{
    //    movement.Disable();        
    //}
}
