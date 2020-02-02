using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;

public class CameraController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Camera mainCamera;
    private Transform cameraAxis;
    private int touchCount = 0;
    private Rigidbody axisRigidbody;

    // Camera variables
    public float cameraZoomSpeed = 1f;
    public Vector2 cameraOrthoRange = Vector2.zero;
    public Vector2 cameraPerspRange = Vector2.zero;
    public Vector2 cameraMaxAngle = Vector2.zero;

    private GameController _gameController;
    private Vector2 lastDelta = Vector2.zero;
    
    public void SetGameController(GameController controller)
    {
        this._gameController = controller;
    }

    public Transform GetCameraAxis()
    {
        return this.cameraAxis;
    }
    
    private void Awake()
    {
        this.mainCamera = Camera.main;
        this.cameraAxis = this.mainCamera.transform.parent;
        this.axisRigidbody = this.cameraAxis.GetComponent<Rigidbody>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this._gameController.GetGameState() != GameVariables.GameState.Halt)
        {
            switch (Input.touchCount)
            {
                case 0:
                case 1:
                    eventData.delta /= GameVariables.CameraSensitivity;
                    Vector2 cameraAngle = this.cameraAxis.transform.localEulerAngles;
                    this.cameraAxis.transform.localEulerAngles = new Vector3(
                        Mathf.Clamp(
                            (-eventData.delta.y + cameraAngle.x > 180)
                                ? -eventData.delta.y + cameraAngle.x - 360
                                : -eventData.delta.y + cameraAngle.x, this.cameraMaxAngle.x, this.cameraMaxAngle.y),
                        eventData.delta.x + cameraAngle.y, 0f);
                    this.lastDelta = eventData.delta;
                    break;
                default:
                    if (Input.touchCount >= 2)
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

                            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize,
                                this.cameraOrthoRange.x,
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

    public void OnPointerDown(PointerEventData eventData)
    {
        this.lastDelta = Vector2.zero;
        this.axisRigidbody.velocity = Vector3.zero;
        this.axisRigidbody.angularVelocity = Vector3.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.axisRigidbody.AddTorque(new Vector3(eventData.delta.y, eventData.delta.x));
    }
}