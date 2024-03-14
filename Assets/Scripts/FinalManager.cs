using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalManager : MonoBehaviour
{
    public Text textoFinal;

    void Start()
    {
        StartCoroutine(Final());
    }

    public IEnumerator Final(){
        yield return new WaitForSeconds(4f);
        textoFinal.text = "Fin del prólogo";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Pantalla de inicio");
    }
    void Update()
    {
        
    }
}
