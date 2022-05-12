using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using TMPro;
using UnityEngine.SceneManagement;

public class menuprinci : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {

        actions.Add("bandera",uno);
        actions.Add("capital",dos);
        actions.Add("tipico",tres);
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
    private void uno(){
        SceneManager.LoadScene("9");

    }

    private void dos(){
    SceneManager.LoadScene("10");
    }

    private void tres(){
    SceneManager.LoadScene("11");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
