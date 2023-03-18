using UnityEngine;



public class ScreenWrap : MonoBehaviour
{
    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float buffer = 1.0f;
    public Camera thisCamera;

    void Awake()
    {
        if (thisCamera == null)
        {
            thisCamera = Camera.main;
        }

        leftConstraint = thisCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;
        rightConstraint = thisCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x;
        bottomConstraint = thisCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y;
        topConstraint = thisCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y;
    }

    void Update()
    {
        Vector3 ship = transform.position;

        if (ship.x < leftConstraint - buffer)
        {
            ship.x = rightConstraint + buffer;
            transform.position = ship;
        }
        if (ship.x > rightConstraint + buffer)
        {
            ship.x = leftConstraint - buffer;
            transform.position = ship;
        }
        if (ship.y < bottomConstraint - buffer)
        {
            ship.y = topConstraint + buffer;
            transform.position = ship;
        }
        if (ship.y > topConstraint + buffer)
        {
            ship.y = bottomConstraint - buffer;
            transform.position = ship;
        }
    }
}
