using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class Input : MonoBehaviour
{
    [HideInInspector]
    public Vector2 MovementInput;
    [HideInInspector]
    public Vector2 PreviousMovementInput;
    [HideInInspector]
    public bool InteractInput;

    private static Input instance;

    private void Awake()
    {
        if (Input.instance != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            Input.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        this.MovementInput = Vector2.zero;
        this.PreviousMovementInput = Vector2.zero;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        this.PreviousMovementInput = this.MovementInput;
        this.MovementInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        this.InteractInput = context.ReadValueAsButton();
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
