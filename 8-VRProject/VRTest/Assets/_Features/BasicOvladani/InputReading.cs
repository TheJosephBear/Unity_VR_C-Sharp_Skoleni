using UnityEngine;
using UnityEngine.InputSystem;

public class InputReading : MonoBehaviour {

    public Transform LeftHandRefference;
    public Transform RightHandRefference;
    public GameObject BulletPrefab;

    public InputActionProperty InputTriggerL;
    public InputActionProperty InputTriggerR;
    public InputActionProperty InputGrabL;
    public InputActionProperty InputGrabR;

    public InputActionProperty RightJoystick; 
    public CharacterController controller;         
    public float moveSpeed = 2f;
    
    private void Start() {
        InputTriggerL.action.Enable();
        InputTriggerR.action.Enable();
        InputGrabL.action.Enable();
        InputGrabR.action.Enable();
        RightJoystick.action.Enable();
    }

    void Update() {

        if(InputTriggerL.action.ReadValue<float>() >= 0.6) {
            GameObject bullet = Instantiate(BulletPrefab, LeftHandRefference.position, LeftHandRefference.rotation);
        }

        if (InputTriggerR.action.ReadValue<float>() >= 0.6) {
            GameObject bullet = Instantiate(BulletPrefab, RightHandRefference.position, RightHandRefference.rotation);
        }


        MoveCharacter();
    }

    void MoveCharacter() {
        Vector2 joy = RightJoystick.action.ReadValue<Vector2>();
        if (joy.sqrMagnitude < 0.01f) return;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * joy.y + right * joy.x;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}