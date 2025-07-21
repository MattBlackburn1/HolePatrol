using UnityEngine;

public class BallAimVisualizer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private float lineLengthMultiplier = 1f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void Show(Vector3 origin, Vector3 direction)
    {
        lineRenderer.enabled = true;
        
        Vector3 endPoint = origin + (direction.normalized * lineLengthMultiplier);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, origin + Vector3.up * 0.1f);
        lineRenderer.SetPosition(1, endPoint + Vector3.up * 0.1f);
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}
