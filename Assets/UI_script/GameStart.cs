using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour
{
    private bool click = false; // Ŭ�� ���� ����

    void Update()
    {
        if (click) // Ŭ���� true �� ��� �Ʒ� ������ �̵�
        {
            SceneManager.LoadScene(""); // �̵��� �� �� �̸� �ֱ�
        }
    }
    public void OnPointerDown(PointerEventData eventData) // �ش� ��ư�� ��������
    {
        click = false;
    }

    public void OnPointerUp(PointerEventData eventData) // �ش� ��ư�� �����ٰ� ������
    {
        click = true;
    }
}
