using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distance;

    public GameObject target;//top
    public GameObject fin;//bitiş noktası
    public float speed;
    public int levell;//rakip levelı
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Ball");
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = target.transform.position.x - transform.position.x;
        if (levell == 1)//1.levelda rakip çubuk tamamiyle topun x düzleminde yaptığı hareketi takip edip topa vurmaya çalışıyor
        {
            if (distance > 0.3f)
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
            else if(distance< -0.3f)
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
        }
        if (levell == 2)//2.Level topun konumu + bitiş noktasının rakibe olan uzaklığına göre vuruş sabit bir açıyla vuruş
        {
            float ang = fin.transform.position.x - transform.position.x;//mesafe hesaplama
            if (ang > 0)
            {
                ang = 0.5f;
            }
            else
            {
                ang = -0.5f;
            }

            distance = distance - ang/100;
            if (distance > 0.2f)
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
            else if (distance < -0.2f)
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
        }
        if (levell == 3)//3. Levelda topun konumu + bitiş noktasının düşman çubuğuna olan uzaklığına göre değişken bir açıyla vuruş
        {
            float ang = (fin.transform.position.x - transform.position.x) / 10;//mesafe hesaplama
            distance = distance - ang;
            if (distance > 0.2f)
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
            else if (distance < -0.2f)
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
        }
        else if (levell == 4)//Level 4 topun konumu + Bitiş noktasıyla düşman noktası arasındataki tam açıyla göre hareket edip yanılma payı ile vuruş
        {
            float ang = AngleBetweenVector2(fin.transform.position.x, transform.position.x, fin.transform.position.y, transform.position.y);//açı hesaplama
            ang = (ang - 90) / 100;
            distance = distance - ang;
            if (distance > 0.2f)
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x = currentpos.x + distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
            else if (distance < -0.2f)
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x = currentpos.x + distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
        }
        else if (levell == 5)//Level  topun konumu + Bitiş noktasıyla düşman noktası arasındataki tam açıyla göre hareket edip yanılma payının en düşük hali
        {
            float ang = AngleBetweenVector2(fin.transform.position.x,transform.position.x, fin.transform.position.y, transform.position.y);//açı hesaplama
            ang = (ang - 90) / 100;
            distance = distance - ang;
            Debug.Log(ang);//hesaplanan açı sonucu çubuğun topla arasında olması gereken x mesafesi
            if (distance > 0.005f)
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x =currentpos.x + distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
            else if (distance < -0.005f)
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x = currentpos.x + distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
        }
    }

    private float AngleBetweenVector2(float x1,float x2, float y1,float y2)//açı hesaplama fonksiyonu
    {
        float angle = Mathf.Atan2(y2 - y1, x2 - x1) * 180 / Mathf.PI;
        return angle;
    }

}
