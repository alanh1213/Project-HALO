using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] GameObject protectorDePantallaGO;
    [SerializeField] GameObject menuPrincipalGO;
    [SerializeField] GameObject presioneTeclaTextoGO;
    bool enProtectorDePantalla = true;
    void Update()
    {
        if(Input.anyKeyDown && enProtectorDePantalla)
        {
            //Desactivo el protector de pantalla
            presioneTeclaTextoGO.SetActive(false);
            ReproducirSonidoBoton(0, gameObject);
            GetComponent<Animator>().SetTrigger("blanco");
            enProtectorDePantalla = false;
            StartCoroutine(DesactivarProtector());
            
        }

        if(!enProtectorDePantalla)
        {
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                ReproducirSonidoVertical();
            }

            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) ||  Input.GetKeyDown(KeyCode.RightArrow))
            {
                ReproducirSonidoHorizontal();
            }
        }
        
    }

    public void ReproducirSonidoBoton(int sonido, GameObject gameObject)
    {
        UI_Audio.ReproducirSonido(sonido, gameObject);
    }
    
    public void ReproducirSonidoEnter(){
        UI_Audio.ReproducirSonido(0, gameObject);
    }

    public void ReproducirSonidoVertical(){
        UI_Audio.ReproducirSonido(1, gameObject);
    }

    public void ReproducirSonidoHorizontal(){
        UI_Audio.ReproducirSonido(2, gameObject);
    }

    public void ReproducirSonidoA(){
        UI_Audio.ReproducirSonido(3, gameObject);
    }

    public void ReproducirSonidoX(){
        UI_Audio.ReproducirSonido(4, gameObject);
    }
    IEnumerator DesactivarProtector()
    {
        yield return new WaitForSeconds(0.5f);
        protectorDePantallaGO.SetActive(false);
        menuPrincipalGO.SetActive(true);
    }

    
}



