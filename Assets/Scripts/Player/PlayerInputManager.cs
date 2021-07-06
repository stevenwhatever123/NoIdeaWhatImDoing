using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    MovementManager movement;

    [SerializeField]
    MouseLookManager mouseLook;

    Player controls;
    Player.GroundMovementActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new Player();
        groundMovement = controls.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.RecieveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestory()
    {
        controls.Disable();
    }
}
