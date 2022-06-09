using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPP : MonoBehaviour
{
    public Zoom zoom;
    public float moveSpeed = 1f;
    bool follow = false;
    // Start is called before the first frame update
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
    }
    private void Update()
    {
        Zoomin();
    }
    public void Zoomin()
    {
        if (follow == true)
        {
            zoom.targetposition = new Vector3(zoom.target.transform.position.x, zoom.target.transform.position.y, 0f);
            transform.position = Vector3.MoveTowards(transform.position, zoom.targetposition, zoom.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "abc")
        {
            follow = true;
            Debug.Log("테스트");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "abc")
        {
            follow = false;
            Debug.Log("테스트");
        }
    }
}
