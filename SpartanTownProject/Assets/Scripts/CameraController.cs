using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target; // ī�޶� �Ѿƴٴ� ��� (�÷��̾�)
    [SerializeField] private float smoothTime = 0.3f; // �ε巴�� �̵��ϴ� �ð�
  
    private Vector3 velocity = Vector3.zero; // ���� ��ȭ�� (=���� �ӵ�)

    private void LateUpdate()
    {
        // ���� ��ǥ = TransformPoint (���� ��ǥ)
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10f));

        // ��ǥ ��ġ���� �ε巴�� �̵��� �� ����ϴ� �޼ҵ�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
