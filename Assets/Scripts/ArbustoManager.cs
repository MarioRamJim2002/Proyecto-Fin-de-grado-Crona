using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArbustoManager : MonoBehaviour
{
    public Sprite arbustoSinRecoger;
    public Sprite arbustoRecogido;
    public MainCharacter mainCharacter;
    public Text textoRecoger;
    private GameObject arbusto;
    public int cantidadArbustos;
    void Start()
    {
        if(mainCharacter.controladorDatos.tieneInfo){
            for(int i = 0;i<mainCharacter.arbustos.Length;i++){
                if(mainCharacter.controladorDatos.arbustos[i]==false){
                    cantidadArbustos+=1;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colision)
    {                   
        if(colision.gameObject.tag == "Arbusto"){
            if(colision.gameObject.GetComponent<SpriteRenderer>().sprite == arbustoSinRecoger){
                textoRecoger.text = "Pulsa E para recoger el objeto";
                arbusto = colision.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {  
        arbusto = null;
        textoRecoger.text = "";
    }
    void Update()
    {
        if(arbusto != null){
            if(Input.GetKeyDown("e")){
                textoRecoger.text = "";
                mainCharacter.menusManager.cantidadObjetos[2]+=1;
                cantidadArbustos+=1;
                mainCharacter.menusManager.CambiarInventario("O");
                arbusto.gameObject.GetComponent<SpriteRenderer>().sprite = arbustoRecogido;
            }           
        } 
    }
}
