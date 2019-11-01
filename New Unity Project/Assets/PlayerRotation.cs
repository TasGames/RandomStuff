using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] protected float rotSpeed;
    [SerializeField] protected float rotationDeadZone;
    [SerializeField] protected float rotationOffset;

    void Update()
    {
        RotateToMouse();
    }

    void RotateToMouse()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector3)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        Quaternion newQuat = Quaternion.Euler(new Vector3 (0f, -angle - rotationOffset, 0f));
        transform.rotation = Quaternion.Lerp(transform.rotation, newQuat, Time.time * rotSpeed);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
