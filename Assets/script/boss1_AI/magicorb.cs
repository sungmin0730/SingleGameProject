using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicorb : MonoBehaviour
{
    Transform boss1Transform;
    UseSkill useSkill;
    private Transform playerTransform;
    Vector3 direction;
    float speed = 10f;
    private Rigidbody2D magicguRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        magicguRigidbody = GetComponent<Rigidbody2D>();
        boss1Transform = GetComponent<Transform>();
        useSkill = GetComponent<UseSkill>();
        
        
        boss1Transform = GameObject.FindObjectOfType<Boss1>().transform;
        direction = (playerTransform.position - gameObject.transform.position).normalized;
        
        Destroy(gameObject, 3f);
        /**if (boss1Transform.localScale.x == 1)
        {

            Debug.Log(boss1Transform.position);
        }
        else
        {

        }**/
    }

    /**void right()
    {
        magicguRigidbody.velocity = Vector2.right * 15f;
        Destroy(gameObject, 3f);
    }
    void left()
    {
        magicguRigidbody.velocity = Vector2.left * 15f;
        Destroy(gameObject, 3f);
    }**/
    private void Update()
    {
        direction = (playerTransform.position - gameObject.transform.position).normalized;
        transform.right = direction;
        magicguRigidbody.velocity = direction * speed;
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            Debug.Log("데미지를 받았습니다");
            //데미지 메서드 실행
        }
    }
}