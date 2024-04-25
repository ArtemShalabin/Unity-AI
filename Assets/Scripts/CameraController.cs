using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 currentEualerAngel;
    [SerializeField]
    private float speedRotation;
    private float normalSpeed;
    private float fastSpeed;
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed;
        fastSpeed = speed * 2;
        currentEualerAngel = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = fastSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }

        Move();
        if(Input.GetMouseButton(1))
        {
            Rotation();
        }

    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 diraction = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(diraction * speed * Time.deltaTime);
    }
    private void Rotation()
    {
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(-x, y, 0);
        currentEualerAngel += rotation * speedRotation;
        transform.eulerAngles = currentEualerAngel;
    }
}
