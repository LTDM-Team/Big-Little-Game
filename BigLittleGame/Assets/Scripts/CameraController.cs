using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
[RequireComponent(typeof(CinemachineCameraOffset))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineCameraOffset _cameraOffset;
    private float _defaultOrthoSize;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cameraOffset = GetComponent<CinemachineCameraOffset>();

        _defaultOrthoSize = _virtualCamera.m_Lens.OrthographicSize;
    }
    private void FixedUpdate()
    {
        var size = _player.Size / 2f;
        _cameraOffset.m_Offset = new Vector3(size.x, size.y, 0);

        var targetOrthoSize = _defaultOrthoSize * (size.x + 0.5f);

        _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(_virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.fixedDeltaTime * 10f);
    }
}