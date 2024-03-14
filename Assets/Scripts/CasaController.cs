using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CasaController : MonoBehaviour
{
    private bool puedeEntrar = false;

    public Text textoEntrar;
    public MainCharacter personajePrincipal;
    public Image fadeOutNegro; 
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colision){
        if(colision.gameObject.tag == "Player"){
            textoEntrar.text = "Pulsa E para entrar en la casa";
            puedeEntrar = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){  
        puedeEntrar = false;
        textoEntrar.text = "";
    }

    public IEnumerator DialogoFadeOut(string dialogo, Sprite imagenDialogo, string mision){
        StartCoroutine(personajePrincipal.MostrarDialogo(dialogo,imagenDialogo,mision));
        yield return new WaitUntil(() => personajePrincipal.GetComponent<MenusManager>().isShowingAlgo == false);
        yield return new WaitForSeconds(1f);
        personajePrincipal.GetComponent<MenusManager>().isShowingAlgo = true; 
        fadeOutNegro.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        fadeOutNegro.CrossFadeAlpha(0,0f,true);
        fadeOutNegro.color = new Color(0,0,0,255);
        fadeOutNegro.CrossFadeAlpha(2,1f,true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Escena Final");
        yield break;
    }

    void Update(){
        if(gameObject.activeSelf){
            if(puedeEntrar){
                if(Input.GetKeyDown("e")){
                    if(personajePrincipal.GetComponent<MenusManager>().mision == 0){
                        StartCoroutine(personajePrincipal.MostrarDialogo("Este parece un lugar bastante cómodo para dormir, pero necesito encontrar algo de comer lo antes posible.",personajePrincipal.imagenDialogo,"NC"));
                    }   
                    if(personajePrincipal.GetComponent<MenusManager>().mision == 1){
                        StartCoroutine(DialogoFadeOut("Aprovecharé para descansar aquí por la noche, parece un sitio bastante cómodo y cálido",personajePrincipal.imagenDialogo,"NC"));
                    }
                }
            }
        }
    }
}