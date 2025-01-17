﻿using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
[RequireComponent(typeof(CinemachineCameraOffset))]
public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineCameraOffset _cameraOffset;

    private float _defaultOrthoSize;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cameraOffset = GetComponent<CinemachineCameraOffset>();

        _defaultOrthoSize = _virtualCamera.m_Lens.OrthographicSize;
    }
    private void Start()
    {
        _virtualCamera.Follow = Player.Instance.transform;
    }

    private void FixedUpdate()
    {
        if (_virtualCamera.Follow == null)
            return;

        var size = Player.Instance.Size / 2f;

        OffsetCamera(size);
        ChangeZoomCamera(size);
    }

    private void OffsetCamera(Vector2 playerSize)
    {
        _cameraOffset.m_Offset = new Vector3(0, playerSize.y, 0);
    }
    private void ChangeZoomCamera(Vector2 playerSize)
    {
        var targetOrthoSize = _defaultOrthoSize * (playerSize.x + 0.5f);
        var currentOthoSize = Mathf.Lerp(_virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.fixedDeltaTime * 10f);

        _virtualCamera.m_Lens.OrthographicSize = currentOthoSize;
    }
}