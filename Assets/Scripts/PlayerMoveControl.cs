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

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

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
