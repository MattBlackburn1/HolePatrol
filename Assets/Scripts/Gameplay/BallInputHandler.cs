using UnityEngine;

public class BallInputHandler : MonoBehaviour
{
    private Camera mainCamera;

    private Vector3 dragStartPoint;
    private Vector3 dragEndPoint;
    
    public bool IsDragging { get; private set; }
    public bool ShouldShoot { get; private set; }
    
    public Vector3 DragVector => dragStartPoint - dragEndPoint;

    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        ShouldShoot = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (RaycastToGround(out Vector3 hitPoint))
            {
                dragStartPoint = hitPoint;
                IsDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && IsDragging)
        {
            if (RaycastToGround(out Vector3 hitPoint))
            {
                dragEndPoint = hitPoint;
            }
        }

        if (Input.GetMouseButtonUp(0) && IsDragging)
        {
            IsDragging = false;
            ShouldShoot = true;
        }
    }

    private bool RaycastToGround(out Vector3 point)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            point = hit.point;
            return true;
        }
        
        point = Vector3.zero;
        return false;
    }
}
