using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public GameObject magicgu;
    public Transform boss1;
    public Transform playerTransform;
    // Start is called before the first frame update

    Vector2 pos;
    Vector3 direction;
    private void Awake()
    {


    }
    public void skill()
    {
        Invoke("spawn1", 0);
        Invoke("spawn2", 1f);
        Invoke("spawn3", 2f);

    }

    void spawn1()
    {
        pos = boss1.position;
        GameObject magic = Instantiate(magicgu, new Vector2(pos.x, pos.y + 7), transform.rotation);
    }
    void spawn2()
    {
        pos = boss1.position;
        GameObject magic = Instantiate(magicgu, new Vector2(pos.x, pos.y + 5), Quaternion.Euler(0f, 0f, 0f));
    }
    void spawn3()
    {
        pos = boss1.position;
        GameObject magic = Instantiate(magicgu, new Vector2(pos.x, pos.y + 3), Quaternion.Euler(0f, 0f, 0f));
    }
}
