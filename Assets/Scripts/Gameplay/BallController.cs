using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallInputHandler inputHandler; 
    [SerializeField] private BallPhysicsController physicsController;

    [SerializeField] private BallAimVisualizer aimVisualizer;

    private bool hasBeenHit;

    void Update()
    {
        if (hasBeenHit)
            return;

        if (inputHandler.IsDragging)
        {
            aimVisualizer.Show(transform.position, inputHandler.DragVector);
        }

        if (inputHandler.ShouldShoot)
        {
            hasBeenHit = true;
            aimVisualizer.Hide();
            physicsController.ApplyForce(inputHandler.DragVector.normalized);
        }
    }
}