using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Réglages")]
    public float distanceMax = 15f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootRaycast();
        }
    }

    void ShootRaycast()
    {
        Ray ray = cam.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2, 0)
        );

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * distanceMax, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, distanceMax))
        {
            ClickableObject target = hit.collider.GetComponent<ClickableObject>();

            if (target != null)
            {
                target.OnObjectClicked();
            }
            else
            {
                Debug.Log("Objet touché : " + hit.collider.name);
            }
        }
    }
}
