using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour{

    public bool isShowingDialogo = false; 

    public float velocidadTexto = 0.075f;
    public GameObject cuadroDialogo;
    public Text textoConversacion;
    public Image imagenPersonaje;
    public Sprite imagenDialogo;
    public bool skip = false;

    public Animator animator;

    public Text textoMision;

    public Text textoVida;
    public Text textoExperiencia;
    public Text textoNivel;

    public Text statsNivel;
    public Text statsVida;
    public Text statsExp;
    public Text statsAtaque;
    public Text statsDefensa;
    public Text statsVelocidad;


    public MenusManager menusManager;
    public ControladorDatos controladorDatos;

    public int vidaTotal = 21;
    public int vidaActual = 1; 

    public double expSiguienteNivel = 100; 
    public double expActual = 0;
    public int nivel = 1;

    public int ataque = 5;
    public int defensa = 4;
    public int velocidad = 9;

    private float velocidadMovimiento = 4f;

    public GameObject[] arbustos;
    public Sprite arbustoRecogido;
    void Start(){
        
        cuadroDialogo.SetActive(false);

        statsAtaque.text = "Ataque: "+ataque;
        statsDefensa.text = "Defensa: "+defensa;
        statsVelocidad.text = "Velocidad: "+velocidad;
        statsExp.text = "Exp: "+expActual+"/"+expSiguienteNivel;
        statsVida.text = "Vida: "+vidaActual+"/"+vidaTotal;

        controladorDatos = ControladorDatos.Instance;
        menusManager = GetComponent<MenusManager>(); 

        if(controladorDatos.tieneInfo){
            
            ataque = controladorDatos.persAtaque;
            defensa = controladorDatos.persDefensa;
            velocidad = controladorDatos.persVelocidad;
            nivel = controladorDatos.persNivel;
            expActual = controladorDatos.persExpActual;
            expSiguienteNivel = controladorDatos.persExpMaxima;
            vidaActual = controladorDatos.persVidaActual;
            vidaTotal = controladorDatos.persVidaMaxima;
            textoVida.text = vidaActual+"/"+vidaTotal;
            textoExperiencia.text = expActual+"/"+expSiguienteNivel;
            textoNivel.text = "Nivel " + nivel;
            transform.position = new Vector3(controladorDatos.x, controladorDatos.y, 0);

            for(int i=0;i<arbustos.Length;i++){
                if(controladorDatos.arbustos[i] == false){
                    arbustos[i].GetComponent<SpriteRenderer>().sprite = arbustoRecogido;
                }
            }

            menusManager.mision = controladorDatos.mision;

            if(menusManager.mision == 0){
                textoMision.text = "Mision principal: \n Comete un bol de bayas para saciarte";
            }
            if(menusManager.mision == 1){
                textoMision.text = "Mision principal \n Encuentra un lugar en el que poder pasar la noche calidamente";
            }

        }else{
            StartCoroutine(MostrarDialogo("(No se donde estoy ahora mismo, pero debería buscar algo de comer, estoy hambriento)",imagenDialogo,"Mision principal: \n Comete un bol de bayas para saciarte"));
        }
    }

    public IEnumerator MostrarDialogo(string textoDialogo, Sprite imagenDialogo, string misionActual){

        menusManager.menu.SetActive(false);
        menusManager.inventario.SetActive(false);
        menusManager.stats.SetActive(false);
        menusManager.cocina.SetActive(false);

        isShowingDialogo = true;
        menusManager.isShowingAlgo = true;

        cuadroDialogo.SetActive(true);

        imagenPersonaje.sprite = imagenDialogo;

        foreach(char caracter in textoDialogo){
            if(skip == true){
                if(misionActual != "NC"){
                    textoMision.text = misionActual;
                }
                cuadroDialogo.SetActive(false);       
                menusManager.isShowingAlgo = false; 
                isShowingDialogo = false;
                skip = false;
                textoConversacion.text = "";
                yield break;
            }
            textoConversacion.text = textoConversacion.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }
                
        yield return new WaitForSeconds(2f);

        cuadroDialogo.SetActive(false);       

        menusManager.isShowingAlgo = false; 
        isShowingDialogo = false;

        if(misionActual != "NC"){
            textoMision.text = misionActual;
        }
        textoConversacion.text = "";
    } 

    public void curarVida(int cantidad){

        if(vidaActual != vidaTotal){

            vidaActual += cantidad;

            if(vidaActual >= vidaTotal){

                vidaActual = vidaTotal;

            }
        }
    }

    public void recibirDaño(int daño){

        if((vidaActual -= daño) <= 0){

            vidaActual = 0;

        }else{

            vidaActual = (int)(vidaActual-(daño/daño-1));

        }
    }

    public void subirExp(double puntos){

        expActual += puntos;

        if(expActual >= expSiguienteNivel){

            expActual -= expSiguienteNivel;
            nivel += 1;
            vidaTotal += 3;
            vidaActual += 3;
            defensa += 2;
            ataque += 2;
            velocidad += 2;
            
            textoNivel.text = "Nivel " + nivel;


            expSiguienteNivel = expSiguienteNivel * 1.2; 
            expSiguienteNivel = Mathf.Round((float)expSiguienteNivel);
        

        }


    }


    void Update(){  

        statsNivel.text = "Lv "+ nivel;
        statsAtaque.text = "Ataque: "+ataque;
        statsDefensa.text = "Defensa: "+defensa;
        statsVelocidad.text = "Velocidad: "+velocidad;
        statsExp.text = "Exp: "+expActual+"/"+expSiguienteNivel;
        statsVida.text = "Vida: "+vidaActual+"/"+vidaTotal;

        textoVida.text = vidaActual+"/"+vidaTotal; 
        textoExperiencia.text = expActual+"/"+expSiguienteNivel;

        controladorDatos.cantidadSeta = menusManager.cantidadObjetos[0];
        controladorDatos.cantidadExpPeque = menusManager.cantidadObjetos[1];
        controladorDatos.cantidadBayasRojas = menusManager.cantidadObjetos[2];
        controladorDatos.cantidadBolBayas = menusManager.cantidadObjetos[3];
        controladorDatos.persVidaMaxima = vidaTotal;
        controladorDatos.persVidaActual = vidaActual;
        controladorDatos.persExpMaxima = (int)expSiguienteNivel;
        controladorDatos.persExpActual = (int)expActual;
        controladorDatos.persAtaque = ataque;
        controladorDatos.persDefensa = defensa;
        controladorDatos.persVelocidad = velocidad;
        controladorDatos.persNivel = nivel;
        controladorDatos.x = (int)transform.position.x;
        controladorDatos.y = (int)transform.position.y; 
        controladorDatos.mision = menusManager.mision;
        
        for(int i = 0; i<arbustos.Length;i++){
            if(arbustos[i].GetComponent<SpriteRenderer>().sprite == arbustoRecogido){
                controladorDatos.arbustos[i] = false;
            }else{
                controladorDatos.arbustos[i] = true;
            }
        }

        if(menusManager.isShowingAlgo == false){
        
        gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal")*velocidadMovimiento*Time.deltaTime,Input.GetAxis("Vertical")*velocidadMovimiento*Time.deltaTime,0));

        if(Input.GetAxis("Vertical")>0){
            animator.Play("Walk_up");
        }
        else
            if(Input.GetAxis("Vertical")<0){
                animator.Play("Walk_down");
            }
            else
                if(Input.GetAxis("Horizontal")>0){
                    animator.Play("Walk_right");
                }
                else
                    if(Input.GetAxis("Horizontal")<0){
                        animator.Play("Walk_left");
                    }
                    else{
                        animator.Play("Idle");
                    }
            
        }else{
            if(isShowingDialogo == true){
                if(Input.GetKeyDown(KeyCode.Space)){
                    skip = true;
                }    
            }
        }
    }
}
