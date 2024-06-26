using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveControl : MonoBehaviour
{
    //[SerializeField] InputAction movement;

    [Header("General Setting")]
    [Tooltip("How fast the ship move")]
    [SerializeField] float speed;
    [Tooltip("Show the max position that ship can move to in X")]
    [SerializeField] float horizontalRange = 1f;
    [Tooltip("Show the max position that ship can move to in Y")]
    [SerializeField] float verticalRange = 1f;

    [Header("Rotation Setting Value")]
    [Tooltip("Pitch value due to position of ship")]
    [SerializeField] float pitchPosition;
    [Tooltip("Pitch value due to input")]
    [SerializeField] float pitchControl;
    [Tooltip("Yaw value due to position of ship")]
    [SerializeField] float yawPosition;
    [Tooltip("Roll value due to input")]
    [SerializeField] float rollControl;

    [Header("Laser Prefabs")]
    [SerializeField] GameObject[] lasers;

    float moveHorizontal, moveVertical;

    // Update is called once per frame
    void Update()
    {
        Transaltion();
        Rotation();
        Firing();
    }

    private void Rotation()
    {
        float pitch = transform.localPosition.y * pitchPosition
            + moveVertical * pitchControl;
        float yaw = transform.localPosition.x * yawPosition;
        float roll = moveHorizontal * rollControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
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

    private void Firing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach(GameObject laser in lasers)
            {
                var emssionModuel = laser.GetComponent<ParticleSystem>().emission;
                emssionModuel.enabled = true;
            }
        }
        else
        {
            foreach (GameObject laser in lasers)
            {
                var emssionModuel = laser.GetComponent<ParticleSystem>().emission;
                emssionModuel.enabled = false;
            }
        }
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
