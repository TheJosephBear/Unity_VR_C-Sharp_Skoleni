using UnityEngine;
using UnityEngine.InputSystem;

public class InputReading : MonoBehaviour {

    public InputActionProperty InputTriggerL;
    public InputActionProperty InputTriggerR;
    public InputActionProperty InputGrabL;
    public InputActionProperty InputGrabR;

    private void Start() {
        InputTriggerL.action.Enable();
        InputTriggerR.action.Enable();
        InputGrabL.action.Enable();
        InputGrabR.action.Enable();
    }

    void Update() {
        print($"Trigger L: {InputTriggerL.action.ReadValue<float>()}");
        print($"Trigger R: {InputTriggerR.action.ReadValue<float>()}");
        print($"Grab L: {InputGrabL.action.ReadValue<float>()}");
        print($"Grab R: {InputGrabR.action.ReadValue<float>()}");
    }
}