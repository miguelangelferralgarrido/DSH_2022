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
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {

        actions.Add("Siguiente",siguiente);
        actions.Add("Menu",volver);
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
