using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    private float rotationX = 0f;
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Échap = libérer curseur pour cliquer
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // Déplacement seulement si curseur bloqué
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Vector2 moveInput = new Vector2(
                Keyboard.current.dKey.isPressed ? 1 : Keyboard.current.aKey.isPressed ? -1 : 0,
                Keyboard.current.wKey.isPressed ? 1 : Keyboard.current.sKey.isPressed ? -1 : 0
            );

            Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
            transform.position += move * speed * Time.deltaTime;

            Vector2 mouseDelta = Mouse.current.delta.ReadValue() * mouseSensitivity * 0.1f;
            rotationX -= mouseDelta.y;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            cam.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseDelta.x);
        }
    }
}