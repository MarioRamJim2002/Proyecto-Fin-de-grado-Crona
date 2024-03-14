using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OllaManager : MonoBehaviour
{
    public Text textoCocinar;
    public MainCharacter personaje;
    public GameObject menuCocina;
    private bool puedeCocinar;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colision){
        if(colision.gameObject.tag == "Player"){
            textoCocinar.text = "Pulsa E para cocinar";
            puedeCocinar = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){  
        puedeCocinar = false;
        textoCocinar.text = "";
    }
    void Update(){
        if(puedeCocinar){
            if(gameObject.activeSelf){
                if(Input.GetKeyDown("e")){
                    if(personaje.GetComponent<MenusManager>().isShowingAlgo == false)
                    personaje.GetComponent<MenusManager>().CargarCocina();
                    menuCocina.SetActive(true);
                    personaje.GetComponent<MenusManager>().isShowingCocina = true;
                    personaje.GetComponent<MenusManager>().isShowingAlgo = true;
                }
            }
        }
    }
}
