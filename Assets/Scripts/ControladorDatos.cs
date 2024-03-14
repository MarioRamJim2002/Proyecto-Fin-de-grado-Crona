using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]

public class DatosJuego{

    public int cantidadSetaD;
    public int cantidadExpPequeD;
    public int cantidadBayasRojasD;
    public int cantidadBolBayasD;

    public int xD;
    public int yD;

    public int persVidaMaximaD;
    public int persVidaActualD;
    public int persNivelD;
    public int persExpMaximaD;
    public int persExpActualD;
    public int persAtaqueD;
    public int persDefensaD;
    public int persVelocidadD;
    public int misionD;

    public bool[] arbustosD;

}

public class ControladorDatos : MonoBehaviour
{

    public DatosJuego datosJuego = new DatosJuego();

    public string archivoDeGuardado;

    public static ControladorDatos Instance;

    public int cantidadSeta;
    public int cantidadExpPeque;
    public int cantidadBayasRojas;
    public int cantidadBolBayas;
    public int x;
    public int y;

    public int persVidaMaxima;
    public int persVidaActual;
    public int persNivel;
    public int persExpMaxima;
    public int persExpActual;
    public int persAtaque;
    public int persDefensa;
    public int persVelocidad;
    
    public int mision;

    public bool[] arbustos;

    public bool tieneInfo = false; 
    
    private void Awake(){

        archivoDeGuardado = Application.dataPath+"/datosJuego.json";
                
        if(ControladorDatos.Instance == null){

            ControladorDatos.Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else 
        {

            Destroy(gameObject);

        }
    }

    public void cargarDatos(){

        if(File.Exists(archivoDeGuardado)){

            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego =  JsonUtility.FromJson<DatosJuego>(contenido);
            
            cantidadSeta = datosJuego.cantidadSetaD;
            cantidadExpPeque = datosJuego.cantidadExpPequeD;
            cantidadBayasRojas = datosJuego.cantidadBayasRojasD;
            cantidadBolBayas = datosJuego.cantidadBolBayasD;
            x = datosJuego.xD;
            y = datosJuego.yD;
            persVidaMaxima = datosJuego.persVidaMaximaD;
            persVidaActual = datosJuego.persVidaActualD;
            persNivel = datosJuego.persNivelD;
            persExpMaxima = datosJuego.persExpMaximaD;
            persExpActual = datosJuego.persExpActualD;
            persAtaque = datosJuego.persAtaqueD;
            persDefensa = datosJuego.persDefensaD; 
            persVelocidad = datosJuego.persVelocidadD;
            mision = datosJuego.misionD;
            arbustos = datosJuego.arbustosD;
            tieneInfo = true;
        }
    }

    public void guardarDatos(){

        DatosJuego nuevosDatos = new DatosJuego(){

            xD = Instance.x,
            yD = Instance.y,
            cantidadSetaD = Instance.cantidadSeta,
            cantidadExpPequeD = Instance.cantidadExpPeque,
            cantidadBayasRojasD = Instance.cantidadBayasRojas,
            cantidadBolBayasD = Instance.cantidadBolBayas,
            persNivelD = Instance.persNivel,
            persVidaMaximaD = Instance.persVidaMaxima,
            persVidaActualD = Instance.persVidaActual,
            persExpMaximaD = Instance.persExpMaxima,
            persExpActualD = Instance.persExpActual,
            persAtaqueD = Instance.persAtaque,
            persDefensaD = Instance.persDefensa,
            persVelocidadD = Instance.persVelocidad,
            misionD = Instance.mision,
            arbustosD = Instance.arbustos

        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

    }
}
