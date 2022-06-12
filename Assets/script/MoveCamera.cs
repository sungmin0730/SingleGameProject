using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector2 center; // ī�޶� ������ ���ϴ� ���������� �ϱ� ���� ����
    public Vector2 size;
    float height;
    float width;
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos() // ī�޶� ������ ���ϴ� ��������
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed); // ī�޶� Ÿ���� speed �� ��ŭ �ӵ��� ���󰡰� ��

        float lx = size.x * 0.5f - width;                            // ī�޶� ���������� �������� �ϴ� �ڵ�
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x); //Mathf.Clamp(value, min, max)

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f); // -10f z�� ����
    }


}
