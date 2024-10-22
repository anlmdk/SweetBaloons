using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSpeedMultiplier = 2f;
    [SerializeField] private BoxCollider2D boundaries;
    [SerializeField] private Transform baloonThrowTransform;

    private Bounds bounds;

    private float leftBound;
    private float rightBound;

    private float startingLeftBound;
    private float startingRightBound;

    private float offset;

    private void Awake()
    {
        bounds = boundaries.bounds;

        offset = transform.position.x - baloonThrowTransform.position.x;

        leftBound = bounds.min.x + offset;
        rightBound = bounds.max.x + offset;

        Debug.Log(leftBound);
        Debug.Log(rightBound);

        startingLeftBound = leftBound;
        startingRightBound = rightBound;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        // Klavye giriþine göre hareket
        Vector3 newPosition = transform.position + new Vector3 (UserInput.MoveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);

        // Fare hareketine göre ek hýz (Mouse Delta kullanarak)
        if (UserInput.IsMouseMoving)
        {
            Vector3 mouseMovement = new Vector3(UserInput.MouseDelta.x * mouseSpeedMultiplier * Time.deltaTime, 0f, 0f);
            newPosition += mouseMovement;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);

        transform.position = newPosition;
    }

    public void ChangeBoundary(float extraWidth)
    {
        leftBound = startingLeftBound;
        rightBound = startingRightBound;

        leftBound += ThrowBaloonController.Instance.Bounds.extents.x + extraWidth;
        rightBound += ThrowBaloonController.Instance.Bounds.extents.x + extraWidth;
    }
}
