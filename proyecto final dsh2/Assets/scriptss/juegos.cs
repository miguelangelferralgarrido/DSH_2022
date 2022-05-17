using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using TMPro;
using UnityEngine.SceneManagement;

public class juegos : MonoBehaviour
{
    public ValorPais[] paises;
    private ValorPais pais;
    
    private int  numPaisActual=-1;
    private GameObject actual;
    private Vector3 v=new Vector3((float)-0.2571168,(float)0.06874365,(float)0.3922196);
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
       //Vector3 (0,0.06874365,0.1635039);
        //transform.position.y=0.06874365;
        //transform.position.z=0.1635039;
        //transform.position= v;
        nextPais();
        
        actions.Add("Siguiente",siguiente);
        actions.Add("Menu",volver);
        actions.Add("Japon",japon);
        actions.Add("China",china);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();    
        }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
            actions[speech.text].Invoke();
    }

    private void volver(){
        SceneManager.LoadScene("Menu");
    }

    private void siguiente(){
        SceneManager.LoadScene("10");
    }
    private void japon(){
       
        if(actual.CompareTag("japon")){
            Debug.Log("cagada con las actions");
           nextPais();
        }
    }
     private void china(){
       
        if(actual.CompareTag("china")){
            Debug.Log("cagada con las actions");
           nextPais();
        }
    }

    void nextPais(){
         numPaisActual++;
         Destroy(actual);
        pais=paises[ numPaisActual];
        actual=Instantiate(pais.pais,pais.pais.transform.position,Quaternion.identity);
        actual.transform.rotation=pais.pais.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
