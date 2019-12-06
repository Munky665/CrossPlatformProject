using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 5;
    [SerializeField]
    private float smoothing = 2;

    Vector2 smoothV;
    Vector2 mouseLook;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    #if UNITY_EDITOR
        Aim();
    #endif
    }

    void Aim()
    {
        //get axis and store in vector
        var mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        //scale the vector
        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothing);

        mouseLook += smoothV;
        //clamp the look up rotation at 90 and -90
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}
