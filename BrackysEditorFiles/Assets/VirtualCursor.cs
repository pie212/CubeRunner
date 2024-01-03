using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VirtualCursor : MonoBehaviour
{
    public InputMaster PlayerControls;

    public InputAction cursorAction; // Renamed from VirtualCursor
    public float cursorSpeed = 5.0f;
    public Vector2 scroll;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize your cursor or do any setup you need here
        
        PlayerControls = new InputMaster();
    }

    void OnEnable()
    {
        cursorAction = PlayerControls.Player.CursorController;
        //cursorAction.performed += OnVirtualCursorInput;
        cursorAction.Enable();
    }

    void OnDisable()
    {
        cursorAction.Disable();
        //cursorAction.performed -= OnVirtualCursorInput;
    }

    public void Update()
    {
        scroll = cursorAction.ReadValue<Vector2>();
        Debug.Log(scroll);
        Vector3 cursorMovement = new Vector3(scroll.x, scroll.y, 0) * cursorSpeed * Time.deltaTime;

        transform.Translate(cursorMovement);
    }
}
