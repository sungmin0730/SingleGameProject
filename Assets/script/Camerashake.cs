using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerashake : MonoBehaviour
{
    private static Camerashake instance;
    public static Camerashake Instance => instance;

    private float shakeTime;
    private float shakeIntensity;
    // Start is called before the first frame update

    public Camerashake()
    {
        instance = this; // ī�޶� ����ũ�� �ٸ������� ���� ȣ���ϱ����� instance ������ ������
    }

    public void OnCamerashake(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while(shakeTime > 0.0f)
        {
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
