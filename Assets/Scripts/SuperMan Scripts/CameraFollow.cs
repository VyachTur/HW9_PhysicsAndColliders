using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _cameraTargetPoint;
    [SerializeField] private float _followSpeed;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _cameraTargetPoint.position, Time.deltaTime * _followSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _cameraTargetPoint.rotation, Time.deltaTime * _rotateSpeed);
    }

    public void SwitchCameraFollow(Transform cameraFollowObject)
    {
        _cameraTargetPoint = cameraFollowObject;
    }
}