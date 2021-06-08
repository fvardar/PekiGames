using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float rand;
    int q;//bitiş noktasının her vuruşta büyümesi için bir template

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(-4, 4);
        transform.position = new Vector2(rand, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        int temp = PlayerPrefs.GetInt("Tc");//çubuklara dokunukup dokunukmadığı
        if (Ball.reset)// bir oyuncu gol atarsa levelı sıfırlama
        {
            rand = Random.Range(-4, 4);
            transform.position = new Vector2(rand, transform.position.y);
            q = 0;
            transform.localScale = new Vector3(0.03f, 0.03f, 0);// bitiş noktasını sıfırlama
            Ball.reset = false;
        }
        if (temp > q)
        {
            if (temp < 21)//20den fazla büyümemesi
            {
                transform.localScale += new Vector3(0.001f, 0.001f,0);//bitiş noktasını büyütme
                q++;
            }
        }

    }
}
