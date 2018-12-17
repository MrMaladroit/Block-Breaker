using UnityEngine;

public class PaddleMovementController : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    void Update()
    {
        float mouseXPosInUnits = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouseXPosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}