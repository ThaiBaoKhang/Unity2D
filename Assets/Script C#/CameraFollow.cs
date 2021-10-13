using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    public BoxCollider2D boundsbox;

    private Vector3 minBounds;

    private Vector3 maxBounds;

    private Camera cmr;

    private float HalfHeight;

    private float HalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        //不允許camera位置露出外面
        minBounds = boundsbox.bounds.min;
        maxBounds = boundsbox.bounds.max;
        cmr = GetComponent<Camera>();
        HalfHeight = cmr.orthographicSize;
        HalfWidth = HalfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + HalfWidth, maxBounds.x - HalfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + HalfHeight, maxBounds.y - HalfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
