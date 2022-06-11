using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    float zoomspeed = 10f;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        //if (camera.orthographicSize > 5)
            //Camerashake.Instance.OnCamerashake(0.1f, 1f);
    }
    void Zoomin()
    {
        if (camera.orthographicSize > 5)
            camera.orthographicSize -= zoomspeed * Time.deltaTime;
    }
  
}
