using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed = 5.0f, xSpeed = 10f;
    private float limitX = 4.0f;
    private float touchXDelta, newX;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        PlayerMove();
    }
    /*We are constantly advancing the character along the z-axis. The method that provides the movement in the x-axis direction when the mouse moves horizontally when the left click of the mouse is pressed, or when we move our finger horizontally on the phone screen when touching the phone screen.*/
    private void PlayerMove()
    {
        if(Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z + speed * Time.deltaTime);
    }
}
