using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public DialogueParser DialogueParser;

    Rigidbody2D rigid;

    float moveSpeed = 3f;
    float jumpPower = 9f;

    bool isJump;

    Vector3 direct;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Interaction();
    }

    void Move()
    {
        float left = Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        float right = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        float x = left + right;

        if (x != 0)
            direct = new Vector3(x, 0);

        transform.position += new Vector3(x, 0) * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        bool j = Input.GetKeyDown(KeyCode.UpArrow);
        if (j && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    void Interaction()
    {
        Debug.DrawRay(transform.position, direct * 1f, Color.green, 0);

        if (Input.GetKeyDown(KeyCode.F) && !DialogueParser.isTalking) // Npc 상호작용
        {
            Debug.Log("상호작용 키 눌렀음");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direct, 1f, LayerMask.GetMask("Npc"));
            if (hit.collider != null)
            {
                NpcManager npc = hit.collider.gameObject.GetComponent<NpcManager>();
                DialogueParser.npc = npc.transform;

                string eventName = "NPC-" + npc.id + "-" + npc.count; // Npc 상호작용 이벤트 이름 NPC-Id-Count
                DialogueParser.startDialogue("NPC-" + npc.id + "-" + npc.count);
                
                string nextEventName = "NPC-" + npc.id + "-" + (npc.count + 1); // 다음 대사 있을때만 대화카운트 증가
                if (DialogueParser.GetDialogue(nextEventName) != null)
                {
                    npc.count++;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

}
