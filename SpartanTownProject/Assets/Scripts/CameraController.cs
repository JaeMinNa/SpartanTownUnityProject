using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target; // 카메라가 쫓아다닐 대상 (플레이어)
    [SerializeField] private float smoothTime = 0.3f; // 부드럽게 이동하는 시간
  
    private Vector3 velocity = Vector3.zero; // 값의 변화량 (=현재 속도)

    private void LateUpdate()
    {
        // 월드 좌표 = TransformPoint (로컬 좌표)
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10f));

        // 목표 위치까지 부드럽게 이동할 때 사용하는 메소드
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
