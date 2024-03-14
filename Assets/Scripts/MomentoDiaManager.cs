using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MomentoDiaManager : MonoBehaviour
{
    public Image momentoDia;
    public GameObject personaje;
    private Color32 momento1;
    private Color32 momento2;
    private Color32 momento3;
    private Color32 momento4;
    void Start()
    {
        momento1 = new Color32(255,255,140,50);
        momento2 = new Color32(255,138,140,50);
        momento3 = new Color32(140,45,84,70);
        momento4 = new Color32(0,0,0,70);
        momentoDia.GetComponent<Image>().color = momento1;
    }


    void Update()
    {
        if(personaje.GetComponent<ArbustoManager>().cantidadArbustos >= 2 && personaje.GetComponent<ArbustoManager>().cantidadArbustos < 4){
            momentoDia.GetComponent<Image>().color = momento2;
        }

        if(personaje.GetComponent<ArbustoManager>().cantidadArbustos >= 4 && personaje.GetComponent<ArbustoManager>().cantidadArbustos < 7){
            momentoDia.GetComponent<Image>().color = momento3;
        }

        if(personaje.GetComponent<ArbustoManager>().cantidadArbustos >= 7 && personaje.GetComponent<ArbustoManager>().cantidadArbustos < 10){
            momentoDia.GetComponent<Image>().color = momento4;
        }
    }
}
