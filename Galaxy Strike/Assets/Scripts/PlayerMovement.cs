using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] float controlSpeed = 10f;
    Vector2 movement;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;

    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor = 10f;
    [SerializeField] float controlRotationSpeed = 10f;

    void Start()
    {

    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        //Debug.Log(movement);
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, controlRotationSpeed * Time.deltaTime);
    }

}
