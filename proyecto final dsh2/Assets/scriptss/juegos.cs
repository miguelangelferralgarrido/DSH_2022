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
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menufinal;
    [SerializeField] private GameObject estrella1;
    [SerializeField] private GameObject estrella2;
    [SerializeField] private GameObject estrella3;
    [SerializeField] int min, seg;
	[SerializeField] TextMeshProUGUI tiempo;
    [SerializeField] TextMeshProUGUI tiempofinal;
	private float restante;
	private bool enMarcha;

    public AudioClip exito=null;
    public AudioClip error=null;

	private void Awake() {
		restante = (min * 60) + seg;
		enMarcha = true;
	}
    public GameObject padre;
    public ValorPais[] paises;
    private List<int> acertados = new List<int>();
    private ValorPais pais;

    private String NombreActual;

    private int numpista=0;

    public TextMeshProUGUI pistas;
    private int ahora;
    private int p =0;
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI puntosfinal;
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
        actions.Add("Italia",italia);
        actions.Add("Alemania",alemania);
        actions.Add("Inglaterra",inglaterra);
        actions.Add("Portugal",portugal);
        actions.Add("Mejico",mejico);
        actions.Add("España",españa);
        actions.Add("Francia",francia);
        actions.Add("Rusia",rusia);        
        actions.Add("Mongolia",mongolia);
        actions.Add("Hungria",hungria);
        actions.Add("Peru",peru);        
        actions.Add("Colombia",colombia);
        actions.Add("Ucrania",ucrania);
        actions.Add("Polonia",polonia);
        actions.Add("Grecia",grecia);
        actions.Add("Bélgica",belgica);
        actions.Add("Estados unidos",estadosUnidos);
        actions.Add("Irlanda",irlanda);
        actions.Add("Suecia",suecia);
        actions.Add("Pausa",pausa);
        actions.Add("Reanudar",reanudar);
        actions.Add("Reiniciar",reiniciar);
        actions.Add("pista",pista);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();  
           
        }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
            actions[speech.text].Invoke();
    }

    private void volver(){
        Time.timeScale = 1f;
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

 private void grecia(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("grecia")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
            AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }

  private void belgica(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("belgica")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }

   private void suecia(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("Suecia")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }

 private void polonia(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("polonia")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }

  private void peru(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("peru")){
            acertados.Add(ahora);
           AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }

  private void ucrania(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("ucrania")){
            acertados.Add(ahora);
           AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }

  private void colombia(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("colombia")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }
  private void japon(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("japon")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }    
 }
 private void mongolia(){
    if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("ulan bator")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
 }



    private void hungria(){
       if(Time.timeScale != 0f)
    { 
        if(actual.CompareTag("hungria")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
        private void alemania(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("alemania")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
        private void italia(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("italia")){
            acertados.Add(ahora);
           AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
            private void mejico(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("mexico")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
            private void españa(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("españa")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
            private void francia(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("francia")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
        private void portugal(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("portugal")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
        private void rusia(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("rusia")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
        private void inglaterra(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("inglaterra")){
            acertados.Add(ahora);
           AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
        }
     private void china(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("china")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
        
    }
    private void egipto(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("egipto")){
            acertados.Add(ahora);
            AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
    private void estadosUnidos(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("estados unidos")){
            acertados.Add(ahora);
           AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }
    private void irlanda(){
        if(Time.timeScale != 0f)
    {
        if(actual.CompareTag("irlanda")){
            acertados.Add(ahora);
           AudioSource.PlayClipAtPoint(exito,Vector3.zero,1f);
            p=p+10;
           nextPais();
        }else{
             AudioSource.PlayClipAtPoint(error,Vector3.zero,1f);
            if(p!=0)
             p=p-10;
        }
    }
    }

    private void pista(){
        restante = restante -5f;
        if(restante < 0)
            restante = 0f;
        numpista++;
        pistas.text=NombreActual.Substring(0,numpista);
    }
    void nextPais(){
        
        bool a=true,b;
        int rn=0;
        while(a){
            int i =0;
             rn=(int)UnityEngine.Random.Range(0,paises.Length);
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
        if(acertados.Count ==paises.Length){
            Debug.Log("Fin del juego");
            Time.timeScale = 0f;
            tiempofinal.text = "Tiempo restante: "+(int)restante+" seg";
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
            menufinal.SetActive(true);
            Destroy(actual);

        }else{
            ahora=rn;
            numpista=0;
            pistas.text=" ";
            Destroy(actual);
            pais=paises[ rn];
            NombreActual=pais.nombre;
            actual=Instantiate(pais.pais,pais.pais.transform.position,Quaternion.identity);
            actual.transform.rotation=pais.pais.transform.rotation;
            actual.transform.SetParent(padre.transform);
        }
    }
    // Update is called once per frame

    void Update()
    {
        puntos.text= p.ToString();
        puntosfinal.text = "Puntos: "+p.ToString();

        if(enMarcha){
        restante -= Time.deltaTime;
		if(restante < 1){
            if(acertados.Count <= 5)
                estrella1.SetActive(true);
            if(acertados.Count >5 && acertados.Count <= 10){
                estrella1.SetActive(true);
                estrella2.SetActive(true);
            }
            if(acertados.Count > 10){
                estrella1.SetActive(true);
                estrella2.SetActive(true);
                estrella3.SetActive(true);
            }    

			enMarcha = false;
            Time.timeScale = 0f;
            tiempofinal.text = "Tiempo restante: "+(int)restante+" seg";
            menufinal.SetActive(true);
			
		}
		int tempMin = Mathf.FloorToInt(restante / 60);
		int tempSeg = Mathf.FloorToInt(restante % 60);
        if(tempMin < 0 && tempSeg < 0){
            tiempo.text = string.Format("{00:00}:{01:00}", 0, 0);
        }else{
		    tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
		}
    }
}
}