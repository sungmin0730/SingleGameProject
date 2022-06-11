using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicorb : MonoBehaviour
{
    Transform boss1Transform;
    UseSkill useSkill;

    private Rigidbody2D magicguRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    void Awake()
    {
        magicguRigidbody = GetComponent<Rigidbody2D>();
        boss1Transform = GetComponent<Transform>();
        useSkill = GetComponent<UseSkill>();

        boss1Transform = GameObject.FindObjectOfType<Boss1>().transform;
        if (boss1Transform.localScale.x == 1)
        {
            left();
        }
        else
        {
            right();
        }
    }

    void right()
    {
        magicguRigidbody.velocity = Vector2.right * 15f;
        Destroy(gameObject, 3f);
    }
    void left()
    {
        magicguRigidbody.velocity = Vector2.left * 15f;
        Destroy(gameObject, 3f);
    }


    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            Debug.Log("�������� �޾ҽ��ϴ�");
            //������ �޼��� ����
        }
    }
}