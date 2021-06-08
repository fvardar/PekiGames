using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;//top
    public GameObject fin;//bitiş noktası
    public float speed;
    public int levell;//rakip levelı
    private bool dirRight = false;//2.level için deneme
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Ball");
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = target.transform.position.x - transform.position.x;
        if (levell == 1)//1.levelda rakip çubuk tamamiyle topun x düzleminde yaptığı hareketi takip edip topa vurmaya çalışıyor
        {
            if (distance > 0.2f)
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
            else if(distance< -0.2f)
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
            }
        }
        else if (levell == 2)//!!!!Tam olarak yapamadım fakat burda yapmayı hayal ettiğim şey rakip oyuncu topun x düzlemindeki hareketini takip ederken
            //aynı zamanda kendisi ve bitiş noktasını açıyı hesaplaması. Bu hesaplamalar sonucunda kendini x düzleminde fazladan hareket ettirmesi
        {
            float ang = AngleBetweenVector2(fin.transform.position.x,transform.position.x, fin.transform.position.y, transform.position.y);//açı hesaplama
            ang = (ang / 180) - 0.5f;//hesaplanan açı sonucu çubuğun topla arasında olması gereken x mesafesi
            if (distance > 0.2f)//çubuğun normal hareketi
            {
                distance = 1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
                    if (dirRight)
                    transform.Translate(Vector2.right * speed * Time.deltaTime);//çubuğun fazladan x eksenindeki hareketi fakat bu kısmı tam olarak yapamadım
            }
            else if (distance < -0.2f)//zıt yönlü hareket
            {
                distance = -1;
                Vector3 currentpos = transform.position;
                currentpos.x += distance * speed * Time.deltaTime;
                transform.position = currentpos;
                if (dirRight!)
                {
                    transform.Translate(-Vector2.right * speed * Time.deltaTime);
                }
            }
            if (ang > 0)//x ekseninde olması gereken fark
            {
                dirRight = false;
            }

            if (ang <= 0)
            {
                dirRight = true;
            }
        }
    }

    private float AngleBetweenVector2(float x1,float x2, float y1,float y2)//açı hesaplama fonksiyonu
    {
        float angle = Mathf.Atan2(y2 - y1, x2 - x1) * 180 / Mathf.PI;
        return angle;
    }

}
