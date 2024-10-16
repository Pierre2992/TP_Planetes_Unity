using UnityEngine;
using System;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 200000.0f;
    public float zoomSpeed = 1.0f;
    private Camera mainCamera;
    private Vector3 initialCameraPosition;
    public Text planetInfoText;
    private bool isPointerOverUI;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleRotationInput();

        isPointerOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

        if (!isPointerOverUI)
        {
            HandleZoomInput();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject planet = hit.collider.gameObject;

                    // Placer la caméra avec la planète au centre de la fenêtre
                    if (planet != null)
                    {
                        initialCameraPosition = mainCamera.transform.position;
                        Vector3 targetPosition = planet.transform.position;
                        mainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, initialCameraPosition.z);
                        planetInfoText.text = "This is " + planet.name;
                        
                       
                    }
                }
            }
        }
    }

    void HandleRotationInput()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.Rotate(Vector3.up, mouseX, Space.World);
            transform.Rotate(Vector3.right, -mouseY, Space.Self);
        }
    }

    void HandleZoomInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);
    }
}

