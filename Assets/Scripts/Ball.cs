using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float mes;//mesafe
    public float ang;//açı 
    public float direction;//yön
    private int i = 0;//topa kaç kere dokunulduğu
    public static int bluegoal = 1, redgoal = 1;//takımları attığı gol sayıları
    public static bool reset = false;//bölüm sıfırlama

    public GameObject respawn;

    public Text redtext;
    public Text bluetext;

    SpriteRenderer spt;

    public GameObject target;
    public float MoveSpeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Stick")//topun oyuncunun çubuğuna dokunduktan sonraki açısal hareketi
        {
            i ++;
            mes = collision.transform.position.x - transform.position.x + 1.6f;
            ang = (mes * 100f) / 3.2f;
            ang = (ang * 1.5f) + 15f + 90;
            direction = ang +180;
            spt.color = Color.blue;
            PlayerPrefs.SetInt("Tc",i);
        }
        if (collision.transform.tag == "Enemy")//topun rakip çubuğa dokunduktan sonraki hareketi
        {
            i++;
            mes = collision.transform.position.x - transform.position.x + 1.6f;
            ang = (mes * 100f) / 3.2f;
            ang = (ang * 1.5f) + 15f + 90;
            direction = ang * -1;
            spt.color = Color.red;
            PlayerPrefs.SetInt("Tc", i);
        }
        if (collision.transform.tag == "Side")//yan duvarlardan sekme açısı
        {
            direction = direction * -1;
        }
        if (collision.transform.tag == "Barrier")//üst ve alt duvardan sekme açısı
        {
            direction = 180 - direction;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Goal")
        {
            if (spt.color == Color.blue)//mavi takım gol 
            {
                bluetext.text = bluegoal.ToString("");
                bluegoal++;
                direction = 0;
                Reset();
            }
            else if (spt.color == Color.red)//kırmızı takım gol
            {
                redtext.text = redgoal.ToString("");
                redgoal++;
                direction = 180;
                Reset();
            }
        }
    }


    void Start()
    {
        i = 0;
        spt = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("Tc", 0);
    }

    void FixedUpdate()
    {
        direction = direction % 360;//topun hareketi
        transform.rotation = Quaternion.Euler(0f, 0f, direction);
        Vector3 movement = transform.up * MoveSpeed * Time.deltaTime;
        transform.position += movement;
        if (bluegoal == 6 || redgoal == 6)//oyunun bitişi
        {
            Time.timeScale = 0;
        }
    }

    private void Reset()//topun bitiş alanına çaprtıktan sonra sıfırlama
    {
        i = 0;
        transform.position = respawn.transform.position;
        ang = 0;
        PlayerPrefs.SetInt("Tc", 0);
        reset = true;
        spt.color = Color.grey;
    }

}