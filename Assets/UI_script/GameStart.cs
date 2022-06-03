using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour
{
    private bool click = false; // 클릭 변수 생성

    void Update()
    {
        if (click) // 클릭이 true 일 경우 아래 씬으로 이동
        {
            SceneManager.LoadScene(""); // 이동할 씬 의 이름 넣기
        }
    }
    public void OnPointerDown(PointerEventData eventData) // 해당 버튼을 눌렀을때
    {
        click = false;
    }

    public void OnPointerUp(PointerEventData eventData) // 해당 버튼을 눌렀다가 뗐을때
    {
        click = true;
    }
}
