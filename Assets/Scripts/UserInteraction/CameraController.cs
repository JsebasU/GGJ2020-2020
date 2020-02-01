using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;

public class CameraController : MonoBehaviour, IDragHandler
{
    private Camera mainCamera;
    private Transform cameraAxis;
    private int touchCount = 0;

    // Camera variables
    public float cameraZoomSpeed = 1f;
    public Vector2 cameraOrthoRange = Vector2.zero;
    public Vector2 cameraPerspRange = Vector2.zero;
    public Vector2 cameraMaxAngle = Vector2.zero;

    private void Awake()
    {
        this.mainCamera = Camera.main;
        this.cameraAxis = this.mainCamera.transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        switch (Input.touchCount)
        {
            case 0:
                Vector2 cameraAngle = this.cameraAxis.transform.localEulerAngles;
                this.cameraAxis.transform.localEulerAngles = new Vector3( Mathf.Clamp((-eventData.delta.y + cameraAngle.x > 180) ? -eventData.delta.y + cameraAngle.x - 360 : -eventData.delta.y + cameraAngle.x, this.cameraMaxAngle.x, this.cameraMaxAngle.y), eventData.delta.x + cameraAngle.y, 0f);
                break;
            default:
                if (Input.touchCount == 2)
                {
                    Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                    if (mainCamera.orthographic)
                    {
                        mainCamera.orthographicSize += deltaMagnitudeDiff * cameraZoomSpeed;

                        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, this.cameraOrthoRange.x,
                            this.cameraOrthoRange.y);
                    }
                    else
                    {
                        mainCamera.fieldOfView += deltaMagnitudeDiff * cameraZoomSpeed;

                        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, this.cameraPerspRange.x,
                            this.cameraPerspRange.y);
                    }
                }
                else
                {
                    Debug.Log("Don't let that octopus play!");
                }
                break;
        }
    }
}