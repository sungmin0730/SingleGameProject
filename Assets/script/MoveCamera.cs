using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector2 center; // 카메라가 나가지 못하는 영역설정을 하기 위한 변수
    public Vector2 size;
    float height;
    float width;
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos() // 카메라가 나가지 못하는 영역설정
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed); // 카메라가 타겟을 speed 값 만큼 속도로 따라가게 함

        float lx = size.x * 0.5f - width;                            // 카메라가 영역밖으로 못나가게 하는 코드
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x); //Mathf.Clamp(value, min, max)

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f); // -10f z값 고정
    }


}
