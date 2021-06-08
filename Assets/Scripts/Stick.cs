using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stick : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary)//dokunma ile hareket
            {
                float distance = (touch.position.x / 108 - 5f) - transform.position.x;//pozisyonlar arası farka göre hareketin devamlılığı

                if (distance < 0.1f)//oyuncu çubuğunun hareketi
                {
                    distance = -1;
                    Vector3 currentpos = transform.position;
                    currentpos.x += distance * speed * Time.deltaTime;
                    transform.position = currentpos;
                }
                else if (distance > 0.1f)//zıt yönlü hareket
                {
                    distance = 1;
                    Vector3 currentpos = transform.position;
                    currentpos.x += distance * speed * Time.deltaTime;
                    transform.position = currentpos;
                }
            }
        }
    }
}
