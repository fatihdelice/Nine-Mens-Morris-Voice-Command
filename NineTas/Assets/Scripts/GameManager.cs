
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject exampleImage;
    public float imageSayac = 0;

    void Start(){
        exampleImage.SetActive(false);
        
    }
    void Update(){
        exampleImage.SetActive (false);
        imageSayac += Time.deltaTime;
        if (imageSayac >= 1.5){
            exampleImage.SetActive (true);
        }
        if(imageSayac >=3.5){
            imageSayac = 0;
        }
    }
    public void BackButon()
    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("Menu Sahnesine Geçildi");
    }
    
    

}