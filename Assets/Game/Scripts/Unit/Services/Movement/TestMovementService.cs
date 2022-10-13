using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementService : MonoBehaviour
{
    public Unit unit;
    public bool directionMovement = true;
    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            unit.MovementService.StopMoving();
        } 
        else if (Input.GetKeyDown(KeyCode.W))
        {
            unit.MovementService.StartMoving();
        }
        if (Input.GetMouseButtonDown(0))
        {
            directionMovement = !directionMovement;
            Vector3 targetPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            unit.MovementService.SetMovementPosition(targetPos);
        }

        if (directionMovement)
        {
            Vector2 direction = Vector2.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction.x = 1;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                direction.y = -1;
            }

            if (direction != Vector2.zero)
                unit.MovementService.SetMovementDirection(direction);
        }
    }
}
