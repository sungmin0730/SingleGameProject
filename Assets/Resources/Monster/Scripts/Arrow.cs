using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine("StartDead");
    }

    IEnumerator StartDead()
    {
        Color c = sprite.color;

        float alpha = 1f;
        while (alpha > 0f)
        {
            sprite.color = new Color(c.r, c.g, c.b, alpha -= 0.01f);
            yield return new WaitForSeconds(0.03f);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
}
