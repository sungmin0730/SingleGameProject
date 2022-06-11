using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPP : MonoBehaviour
{
    public Zoom zoom;
    public float moveSpeed = 1f;
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
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.up * v, ForceMode2D.Impulse);
    }
    private void Update()
    {

    }
    
}
