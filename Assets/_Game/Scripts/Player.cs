using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float raycastDistance = 1f;
    [SerializeField] private LayerMask collisionLayer;

    private bool isMoving;
    private Vector3 moveDirection;
    private Vector3 mouseInputPos;
    
    // Update is called once per frame
    void Update()
    {
        MouseInput();

        if (isMoving)
        {
            Move();
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseInputPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            var dragVec = Input.mousePosition - mouseInputPos;

            if (dragVec.magnitude >= 50f)
            {
                dragVec.Normalize();

                if (Mathf.Abs(dragVec.x) > Mathf.Abs(dragVec.y))
                {
                    if (dragVec.x > 0)
                    {
                        moveDirection = Vector3.right;
                    }
                    else
                    {
                        moveDirection = Vector3.left;
                    }
                }
                else
                {
                    if (dragVec.y > 0)
                    {
                        moveDirection = Vector3.forward;
                    }
                    else
                    {
                        moveDirection = Vector3.back;
                    }
                }
            }
        }
        // Kiểm tra va chạm
        Ray ray = new Ray(transform.position, moveDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, collisionLayer))
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    private void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}

