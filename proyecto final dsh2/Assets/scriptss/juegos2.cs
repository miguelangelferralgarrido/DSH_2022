using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using TMPro;
using UnityEngine.SceneManagement;

public class juegos2 : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
	[SerializeField] int min, seg;
	[SerializeField] TextMeshProUGUI tiempo;
	private float restante;
	private bool enMarcha;

	private void Awake() {
		restante = (min * 60) + seg;
		enMarcha = true;
	}

    public GameObject padre;
    public ValorPais[] paises;
    private List<int> acertados = new List<int>();
    private ValorPais pais;
    private int ahora;
    private int p =0;
    public TextMeshProUGUI puntos;
    
    private GameObject actual;
    private Vector3 v=new Vector3((float)-0.2571168,(float)0.06874365,(float)0.3922196);
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
      
        nextPais();
        actions.Add("Siguiente",siguiente);
        actions.Add("Menu",volver);
        actions.Add("Japon",japon);
        actions.Add("China",china);
        actions.Add("Egipto",egipto);
        actions.Add("Estados unidos",estadosUnidos);
        actions.Add("Irlanda",irlanda);
        actions.Add("Pausa",pausa);
        actions.Add("Reanudar",reanudar);
        actions.Add("Reiniciar",reiniciar);
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
        nextPais();
    }

    private void pausa(){
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    private void reanudar(){
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    private void reiniciar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void japon(){
       
        if(actual.CompareTag("japon")){
            Debug.Log("cagada con las actions");
            acertados.Add(ahora);
            p=p+10;
           nextPais();
        }
    }
     private void china(){
       
        if(actual.CompareTag("china")){
            Debug.Log("cagada con las actions");
            acertados.Add(ahora);
            p=p+10;
           nextPais();
        }
        
    }
    private void egipto(){
       
        if(actual.CompareTag("egipto")){
            Debug.Log("cagada con las actions");
            acertados.Add(ahora);
            p=p+10;
           nextPais();
        }
    }
    private void estadosUnidos(){
       
        if(actual.CompareTag("estados unidos")){
            Debug.Log("cagada con las actions");
            acertados.Add(ahora);
            p=p+10;
           nextPais();
        }
    }
    private void irlanda(){
       
        if(actual.CompareTag("irlanda")){
            Debug.Log("cagada con las actions");
            acertados.Add(ahora);
            p=p+10;
           nextPais();
        }
    }

    void nextPais(){
        
        bool a=true,b;
        int rn=0;
        while(a){
            int i =0;
             rn=(int)UnityEngine.Random.Range(0,paises.Length-1);
            b=true;
            if(acertados.Count==paises.Length)
            a=false;
            else{
                if(acertados.Count!=0){
                    while(i<acertados.Count && b){
                        if(rn==acertados[i]){
                            b=false;
                        }
                        i++;
                    }
                    if(b){
                        a=false;
                    }
                }
                else a=false;
            }

        }
        if(acertados.Capacity==paises.Length){
            Debug.Log("Fin del juego");
            Destroy(actual);

        }else{
            ahora=rn;
            Destroy(actual);
            pais=paises[ rn];
            
            actual=Instantiate(pais.pais,pais.pais.transform.position,Quaternion.identity);
            actual.transform.rotation=pais.pais.transform.rotation;
            actual.transform.SetParent(padre.transform);
        }
    }
    // Update is called once per frame

    void Update()
    {
        puntos.text= p.ToString();

        if(enMarcha){
        restante -= Time.deltaTime;
		if(restante < 1){
			enMarcha = false;
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
			
		}
		int tempMin = Mathf.FloorToInt(restante / 60);
		int tempSeg = Mathf.FloorToInt(restante % 60);
		tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
		}
    }
}
