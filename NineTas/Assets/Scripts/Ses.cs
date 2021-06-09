    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Windows.Speech;
    using TMPro;
    using UnityEngine.SceneManagement;

    public class Ses : MonoBehaviour
    {
    //Kelimeleri barındaran bir tane dizi oluşturalım.
    //Bunun sebebi çok fazla kelime olduğu için bir birine yakın olan kelimeleri yanlış anlamasıdır. Az kelime her zaman daha iyidir.
    public string[] keywords = new string[] { "geri al beyaz bir", "geri al beyaz iki", "geri al beyaz üç", "geri al beyaz dört", "geri al beyaz beş", "geri al beyaz altı", "geri al beyaz yedi", "geri al beyaz sekiz", "geri al beyaz dokuz", "geri al siyah bir", "geri al siyah iki", "geri al siyah üç", "geri al siyah dört", "geri al siyah beş", "geri al siyah altı", "geri al siyah yedi", "geri al siyah sekiz", "geri al siyah dokuz","sil beyaz bir", "sil beyaz iki", "sil beyaz üç", "sil beyaz dört", "sil beyaz beş", "sil beyaz altı", "sil beyaz yedi", "sil beyaz sekiz", "sil beyaz dokuz", "sil siyah bir",  "sil siyah iki", "sil siyah üç", "sil siyah dört", "sil siyah beş", "sil siyah altı", "sil siyah yedi", "sil siyah sekiz", "sil siyah dokuz" , "yeni oyun" ,"beyaz bir alfa bir", "beyaz bir alfa iki", "beyaz bir alfa üç", "beyaz bir alfa dört", "beyaz bir alfa beş", "beyaz bir alfa altı", "beyaz bir alfa yedi", "beyaz bir alfa sekiz", "beyaz bir beta bir", "beyaz bir beta iki",  "beyaz bir beta üç", "beyaz bir beta dört", "beyaz bir beta beş", "beyaz bir beta altı",  "beyaz bir beta yedi",  "beyaz bir beta sekiz",  "beyaz bir omega bir",  "beyaz bir omega iki", "beyaz bir omega üç", "beyaz bir omega dört", "beyaz bir omega beş", "beyaz bir omega altı", "beyaz bir omega yedi", "beyaz bir omega sekiz",  "beyaz iki alfa bir", "beyaz iki alfa iki", "beyaz iki alfa üç",  "beyaz iki alfa dört", "beyaz iki alfa beş", "beyaz iki alfa altı", "beyaz iki alfa yedi", "beyaz iki alfa sekiz", "beyaz iki beta bir", "beyaz iki beta iki", "beyaz iki beta üç", "beyaz iki beta dört", "beyaz iki beta beş", "beyaz iki beta altı", "beyaz iki beta yedi", "beyaz iki beta sekiz", "beyaz iki omega bir", "beyaz iki omega iki", "beyaz iki omega üç", "beyaz iki omega dört", "beyaz iki omega beş", "beyaz iki omega altı",  "beyaz iki omega yedi", "beyaz iki omega sekiz", "beyaz üç alfa bir", "beyaz üç alfa iki", "beyaz üç alfa üç", "beyaz üç alfa dört", "beyaz üç alfa beş", "beyaz üç alfa altı", "beyaz üç alfa yedi", "beyaz üç alfa sekiz", "beyaz üç beta bir", "beyaz üç beta iki", "beyaz üç beta üç", "beyaz üç beta dört",  "beyaz üç beta beş", "beyaz üç beta altı", "beyaz üç beta yedi", "beyaz üç beta sekiz", "beyaz üç omega bir", "beyaz üç omega iki", "beyaz üç omega üç",  "beyaz üç omega dört", "beyaz üç omega beş",  "beyaz üç omega altı", "beyaz üç omega yedi",  "beyaz üç omega sekiz",  "beyaz dört alfa bir",  "beyaz dört alfa iki", "beyaz dört alfa üç", "beyaz dört alfa dört", "beyaz dört alfa beş", "beyaz dört alfa altı", "beyaz dört alfa yedi", "beyaz dört alfa sekiz", "beyaz dört beta bir", "beyaz dört beta iki", "beyaz dört beta üç", "beyaz dört beta dört", "beyaz dört beta beş", "beyaz dört beta altı",  "beyaz dört beta yedi",  "beyaz dört beta sekiz", "beyaz dört omega bir", "beyaz dört omega iki", "beyaz dört omega üç", "beyaz dört omega dört",  "beyaz dört omega beş", "beyaz dört omega altı", "beyaz dört omega yedi", "beyaz dört omega sekiz", "beyaz beş alfa bir", "beyaz beş alfa iki", "beyaz beş alfa üç", "beyaz beş alfa dört", "beyaz beş alfa beş", "beyaz beş alfa altı", "beyaz beş alfa yedi", "beyaz beş alfa sekiz", "beyaz beş beta bir", "beyaz beş beta iki", "beyaz beş beta üç", "beyaz beş beta dört", "beyaz beş beta beş", "beyaz beş beta altı", "beyaz beş beta yedi", "beyaz beş beta sekiz", "beyaz beş omega bir", "beyaz beş omega iki", "beyaz beş omega üç", "beyaz beş omega dört", "beyaz beş omega beş", "beyaz beş omega altı", "beyaz beş omega yedi", "beyaz beş omega sekiz", "beyaz altı alfa bir", "beyaz altı alfa iki", "beyaz altı alfa üç", "beyaz altı alfa dört", "beyaz altı alfa beş", "beyaz altı alfa altı", "beyaz altı alfa yedi", "beyaz altı alfa sekiz", "beyaz altı beta bir", "beyaz altı beta iki", "beyaz altı beta üç", "beyaz altı beta dört", "beyaz altı beta beş", "beyaz altı beta altı", "beyaz altı beta yedi", "beyaz altı beta sekiz", "beyaz altı omega bir", "beyaz altı omega iki", "beyaz altı omega üç", "beyaz altı omega dört", "beyaz altı omega beş", "beyaz altı omega altı", "beyaz altı omega yedi", "beyaz altı omega sekiz", "beyaz yedi alfa bir", "beyaz yedi alfa iki", "beyaz yedi alfa üç", "beyaz yedi alfa dört", "beyaz yedi alfa beş", "beyaz yedi alfa altı",  "beyaz yedi alfa yedi", "beyaz yedi alfa sekiz", "beyaz yedi beta bir", "beyaz yedi beta iki", "beyaz yedi beta üç", "beyaz yedi beta dört", "beyaz yedi beta beş", "beyaz yedi beta altı", "beyaz yedi beta yedi", "beyaz yedi beta sekiz", "beyaz yedi omega bir", "beyaz yedi omega iki", "beyaz yedi omega üç", "beyaz yedi omega dört", "beyaz yedi omega beş", "beyaz yedi omega altı", "beyaz yedi omega yedi", "beyaz yedi omega sekiz", "beyaz sekiz alfa bir", "beyaz sekiz alfa iki", "beyaz sekiz alfa üç", "beyaz sekiz alfa dört", "beyaz sekiz alfa beş", "beyaz sekiz alfa altı", "beyaz sekiz alfa yedi", "beyaz sekiz alfa sekiz", "beyaz sekiz beta bir", "beyaz sekiz beta iki", "beyaz sekiz beta üç", "beyaz sekiz beta dört", "beyaz sekiz beta beş", "beyaz sekiz beta altı", "beyaz sekiz beta yedi", "beyaz sekiz beta sekiz", "beyaz sekiz omega bir", "beyaz sekiz omega iki", "beyaz sekiz omega üç", "beyaz sekiz omega dört", "beyaz sekiz omega beş", "beyaz sekiz omega altı", "beyaz sekiz omega yedi", "beyaz sekiz omega sekiz", "beyaz dokuz alfa bir", "beyaz dokuz alfa iki", "beyaz dokuz alfa üç", "beyaz dokuz alfa dört", "beyaz dokuz alfa beş", "beyaz dokuz alfa altı", "beyaz dokuz alfa yedi", "beyaz dokuz alfa sekiz", "beyaz dokuz beta bir", "beyaz dokuz beta iki", "beyaz dokuz beta üç", "beyaz dokuz beta dört", "beyaz dokuz beta beş", "beyaz dokuz beta altı", "beyaz dokuz beta yedi", "beyaz dokuz beta sekiz", "beyaz dokuz omega bir", "beyaz dokuz omega iki", "beyaz dokuz omega üç", "beyaz dokuz omega dört", "beyaz dokuz omega beş", "beyaz dokuz omega altı", "beyaz dokuz omega yedi", "beyaz dokuz omega sekiz", "siyah bir alfa bir", "siyah bir alfa iki", "siyah bir alfa üç", "siyah bir alfa dört", "siyah bir alfa beş", "siyah bir alfa altı", "siyah bir alfa yedi", "siyah bir alfa sekiz", "siyah bir beta bir", "siyah bir beta iki", "siyah bir beta üç", "siyah bir beta dört", "siyah bir beta beş", "siyah bir beta altı", "siyah bir beta yedi", "siyah bir beta sekiz", "siyah bir omega bir", "siyah bir omega iki", "siyah bir omega üç", "siyah bir omega dört", "siyah bir omega beş", "siyah bir omega altı", "siyah bir omega yedi", "siyah bir omega sekiz", "siyah iki alfa bir", "siyah iki alfa iki", "siyah iki alfa üç", "siyah iki alfa dört", "siyah iki alfa beş", "siyah iki alfa altı", "siyah iki alfa yedi", "siyah iki alfa sekiz", "siyah iki beta bir", "siyah iki beta iki", "siyah iki beta üç", "siyah iki beta dört", "siyah iki beta beş", "siyah iki beta altı",  "siyah iki beta yedi",  "siyah iki beta sekiz", "siyah iki omega bir", "siyah iki omega iki",  "siyah iki omega üç",  "siyah iki omega dört", "siyah iki omega beş", "siyah iki omega altı", "siyah iki omega yedi", "siyah iki omega sekiz", "siyah üç alfa bir",  "siyah üç alfa iki", "siyah üç alfa üç", "siyah üç alfa dört", "siyah üç alfa beş", "siyah üç alfa altı",  "siyah üç alfa yedi", "siyah üç alfa sekiz", "siyah üç beta bir", "siyah üç beta iki", "siyah üç beta üç", "siyah üç beta dört", "siyah üç beta beş", "siyah üç beta altı",  "siyah üç beta yedi", "siyah üç beta sekiz", "siyah üç omega bir", "siyah üç omega iki", "siyah üç omega üç", "siyah üç omega dört", "siyah üç omega beş", "siyah üç omega altı", "siyah üç omega yedi", "siyah üç omega sekiz", "siyah dört alfa bir", "siyah dört alfa iki", "siyah dört alfa üç", "siyah dört alfa dört", "siyah dört alfa beş", "siyah dört alfa altı", "siyah dört alfa yedi", "siyah dört alfa sekiz", "siyah dört beta bir",  "siyah dört beta iki", "siyah dört beta üç", "siyah dört beta dört", "siyah dört beta beş", "siyah dört beta altı", "siyah dört beta yedi",  "siyah dört beta sekiz", "siyah dört omega bir", "siyah dört omega iki", "siyah dört omega üç", "siyah dört omega dört", "siyah dört omega beş",  "siyah dört omega altı", "siyah dört omega yedi", "siyah dört omega sekiz", "siyah beş alfa bir", "siyah beş alfa iki", "siyah beş alfa üç", "siyah beş alfa dört", "siyah beş alfa beş", "siyah beş alfa altı", "siyah beş alfa yedi", "siyah beş alfa sekiz", "siyah beş beta bir", "siyah beş beta iki", "siyah beş beta üç", "siyah beş beta dört", "siyah beş beta beş", "siyah beş beta altı", "siyah beş beta yedi", "siyah beş beta sekiz", "siyah beş omega bir", "siyah beş omega iki", "siyah beş omega üç", "siyah beş omega dört", "siyah beş omega beş", "siyah beş omega altı",  "siyah beş omega yedi", "siyah beş omega sekiz", "siyah altı alfa bir", "siyah altı alfa iki", "siyah altı alfa üç", "siyah altı alfa dört", "siyah altı alfa beş", "siyah altı alfa altı", "siyah altı alfa yedi", "siyah altı alfa sekiz", "siyah altı beta bir", "siyah altı beta iki",  "siyah altı beta üç", "siyah altı beta dört", "siyah altı beta beş", "siyah altı beta altı", "siyah altı beta yedi", "siyah altı beta sekiz", "siyah altı omega bir", "siyah altı omega iki", "siyah altı omega üç", "siyah altı omega dört", "siyah altı omega beş", "siyah altı omega altı", "siyah altı omega yedi", "siyah altı omega sekiz", "siyah yedi alfa bir", "siyah yedi alfa iki", "siyah yedi alfa üç", "siyah yedi alfa dört", "siyah yedi alfa beş", "siyah yedi alfa altı", "siyah yedi alfa yedi", "siyah yedi alfa sekiz", "siyah yedi beta bir", "siyah yedi beta iki", "siyah yedi beta üç", "siyah yedi beta dört", "siyah yedi beta beş", "siyah yedi beta altı", "siyah yedi beta yedi", "siyah yedi beta sekiz", "siyah yedi omega bir", "siyah yedi omega iki", "siyah yedi omega üç", "siyah yedi omega dört", "siyah yedi omega beş", "siyah yedi omega altı", "siyah yedi omega yedi", "siyah yedi omega sekiz", "siyah sekiz alfa bir", "siyah sekiz alfa iki", "siyah sekiz alfa üç", "siyah sekiz alfa dört", "siyah sekiz alfa beş", "siyah sekiz alfa altı", "siyah sekiz alfa yedi", "siyah sekiz alfa sekiz", "siyah sekiz beta bir", "siyah sekiz beta iki", "siyah sekiz beta üç", "siyah sekiz beta dört", "siyah sekiz beta beş", "siyah sekiz beta altı", "siyah sekiz beta yedi", "siyah sekiz beta sekiz", "siyah sekiz omega bir", "siyah sekiz omega iki", "siyah sekiz omega üç", "siyah sekiz omega dört", "siyah sekiz omega beş", "siyah sekiz omega altı", "siyah sekiz omega yedi", "siyah sekiz omega sekiz", "siyah dokuz alfa bir", "siyah dokuz alfa iki", "siyah dokuz alfa üç", "siyah dokuz alfa dört", "siyah dokuz alfa beş", "siyah dokuz alfa altı", "siyah dokuz alfa yedi", "siyah dokuz alfa sekiz", "siyah dokuz beta bir", "siyah dokuz beta iki", "siyah dokuz beta üç", "siyah dokuz beta dört", "siyah dokuz beta beş", "siyah dokuz beta altı", "siyah dokuz beta yedi", "siyah dokuz beta sekiz", "siyah dokuz omega bir", "siyah dokuz omega iki", "siyah dokuz omega üç",  "siyah dokuz omega dört", "siyah dokuz omega beş", "siyah dokuz omega altı", "siyah dokuz omega yedi", "siyah dokuz omega sekiz"};
    //Konuşma seviyemizi belirtelim.
    public ConfidenceLevel confidence = ConfidenceLevel.Low;

    //Söylediklerimizi ekrana yazdırmak için text oluşturdum.
    public TMP_Text results;
    //Karakterimizi tanımlayalım.
    public GameObject beyaz_0;
    public GameObject beyaz_1;
    public GameObject beyaz_2;
    public GameObject beyaz_3;
    public GameObject beyaz_4;
    public GameObject beyaz_5;
    public GameObject beyaz_6;
    public GameObject beyaz_7;
    public GameObject beyaz_8;

    public GameObject siyah_0;
    public GameObject siyah_1;
    public GameObject siyah_2;
    public GameObject siyah_3;
    public GameObject siyah_4;
    public GameObject siyah_5;
    public GameObject siyah_6;
    public GameObject siyah_7;
    public GameObject siyah_8;
    

    //Bir tane tanıyıcı oluşturalım.
    protected PhraseRecognizer recognizer;
    //Kelimelerimizi tutan string değişkeni belirleyelim.
    protected string word = "";

    private void Start()
    {
        
        //Eğer keywords null değilse
        if (keywords != null) 
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    //Söylediğimiz kelimeyi word değişkenine atayalım.
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        //Söylediğimiz kelimeyi ekranda yazdıralım.
        results.text = "Söylediğiniz kelime: <b>" + word + "</b>";
    }

    private void Update()
    { 
        
        //Pulların x ve y posizyon değerlerini alalım.

        //Beyaz Pullar
        float beyaz_0x = beyaz_0.transform.position.x;
        float beyaz_0y = beyaz_0.transform.position.y;
        float beyaz_1x = beyaz_1.transform.position.x;
        float beyaz_1y = beyaz_1.transform.position.y;        
        float beyaz_2x = beyaz_2.transform.position.x;
        float beyaz_2y = beyaz_2.transform.position.y;       
        float beyaz_3x = beyaz_3.transform.position.x;
        float beyaz_3y = beyaz_3.transform.position.y;        
        float beyaz_4x = beyaz_4.transform.position.x;
        float beyaz_4y = beyaz_4.transform.position.y;
        float beyaz_5x = beyaz_5.transform.position.x;
        float beyaz_5y = beyaz_5.transform.position.y;
        float beyaz_6x = beyaz_6.transform.position.x;
        float beyaz_6y = beyaz_6.transform.position.y;
        float beyaz_7x = beyaz_7.transform.position.x;
        float beyaz_7y = beyaz_7.transform.position.y;
        float beyaz_8x = beyaz_8.transform.position.x;
        float beyaz_8y = beyaz_8.transform.position.y;
        
        //Siyah Pullar
        float siyah_0x = siyah_0.transform.position.x;
        float siyah_0y = siyah_0.transform.position.y;
        float siyah_1x = siyah_1.transform.position.x;
        float siyah_1y = siyah_1.transform.position.y;        
        float siyah_2x = siyah_2.transform.position.x;
        float siyah_2y = siyah_2.transform.position.y;       
        float siyah_3x = siyah_3.transform.position.x;
        float siyah_3y = siyah_3.transform.position.y;        
        float siyah_4x = siyah_4.transform.position.x;
        float siyah_4y = siyah_4.transform.position.y;
        float siyah_5x = siyah_5.transform.position.x;
        float siyah_5y = siyah_5.transform.position.y;
        float siyah_6x = siyah_6.transform.position.x;
        float siyah_6y = siyah_6.transform.position.y;
        float siyah_7x = siyah_7.transform.position.x;
        float siyah_7y = siyah_7.transform.position.y;
        float siyah_8x = siyah_8.transform.position.x;
        float siyah_8y = siyah_8.transform.position.y;
        //Kelimemizi söylediğimizde olacak şeyleri belirtelim.

        switch (word)
        {
            case "beyaz bir alfa bir":    // Beyaz bir tahta komutları başladı
                beyaz_0x=0.35f;
                beyaz_0y=3f;
                break;
            case "beyaz bir alfa iki":
                beyaz_0x=4f;
                beyaz_0y=3f;
                break;
            case "beyaz bir alfa üç":
                beyaz_0x=7.63f;
                beyaz_0y=3f;
                break;
            case "beyaz bir alfa dört":
                beyaz_0x=0.35f;
                beyaz_0y=-0.7f;
                break;
            case "beyaz bir alfa beş":
                beyaz_0x=7.63f;
                beyaz_0y=-0.7f;
                break;
            case "beyaz bir alfa altı":
                beyaz_0x=0.35f;
                beyaz_0y=-4.327f;
                break;
            case "beyaz bir alfa yedi":
                beyaz_0x=4f;
                beyaz_0y=-4.327f;
                break;
            case "beyaz bir alfa sekiz":
                beyaz_0x=7.63f;
                beyaz_0y=-4.327f;
                break;
            case "beyaz bir beta bir":
                beyaz_0x=1.561f;
                beyaz_0y=1.747f;
                break;
            case "beyaz bir beta iki":
                beyaz_0x=4f;
                beyaz_0y=1.747f;
                break;
            case "beyaz bir beta üç":
                beyaz_0x=6.44f;
                beyaz_0y=1.747f;
                break;
            case "beyaz bir beta dört":
                beyaz_0x=1.561f;
                beyaz_0y=-0.7f;
                break;
            case "beyaz bir beta beş":
                beyaz_0x=6.44f;
                beyaz_0y=-0.7f;
                break;
            case "beyaz bir beta altı":
                beyaz_0x=1.561f;
                beyaz_0y=-3.157f;
                break;
            case "beyaz bir beta yedi":
                beyaz_0x=4f;
                beyaz_0y=-3.157f;
                break;
            case "beyaz bir beta sekiz":
                beyaz_0x=6.44f;
                beyaz_0y=-3.157f;
                break;
            case "beyaz bir omega bir":
                beyaz_0x=2.76f;
                beyaz_0y=0.55f;
                break;
            case "beyaz bir omega iki":
                beyaz_0x=4f;
                beyaz_0y=0.55f;
                break;
            case "beyaz bir omega üç":
                beyaz_0x=5.2155f;
                beyaz_0y=0.55f;
                break;
            case "beyaz bir omega dört":
                beyaz_0x=2.76f;
                beyaz_0y=-0.7f;
                break;
            case "beyaz bir omega beş":
                beyaz_0x=5.215f;
                beyaz_0y=-0.7f;
                break;
            case "beyaz bir omega altı":
                beyaz_0x=2.76f;
                beyaz_0y=-1.92f;
                break;
            case "beyaz bir omega yedi":
                beyaz_0x=4f;
                beyaz_0y=-1.92f;
                break;
            case "beyaz bir omega sekiz":
                beyaz_0x=5.215f;
                beyaz_0y=-1.92f;
                break;                      // Beyaz bir tahta komutları bitti
            case "beyaz iki alfa bir":    // Beyaz iki tahta komutları başladı
                beyaz_1x=0.35f;
                beyaz_1y=3f;
                break;
            case "beyaz iki alfa iki":
                beyaz_1x=4f;
                beyaz_1y=3f;
                break;
            case "beyaz iki alfa üç":
                beyaz_1x=7.63f;
                beyaz_1y=3f;
                break;
            case "beyaz iki alfa dört":
                beyaz_1x=0.35f;
                beyaz_1y=-0.7f;
                break;
            case "beyaz iki alfa beş":
                beyaz_1x=7.63f;
                beyaz_1y=-0.7f;
                break;
            case "beyaz iki alfa altı":
                beyaz_1x=0.35f;
                beyaz_1y=-4.327f;
                break;
            case "beyaz iki alfa yedi":
                beyaz_1x=4f;
                beyaz_1y=-4.327f;
                break;
            case "beyaz iki alfa sekiz":
                beyaz_1x=7.63f;
                beyaz_1y=-4.327f;
                break;
            case "beyaz iki beta bir":
                beyaz_1x=1.561f;
                beyaz_1y=1.747f;
                break;
            case "beyaz iki beta iki":
                beyaz_1x=4f;
                beyaz_1y=1.747f;
                break;
            case "beyaz iki beta üç":
                beyaz_1x=6.44f;
                beyaz_1y=1.747f;
                break;
            case "beyaz iki beta dört":
                beyaz_1x=1.561f;
                beyaz_1y=-0.7f;
                break;
            case "beyaz iki beta beş":
                beyaz_1x=6.44f;
                beyaz_1y=-0.7f;
                break;
            case "beyaz iki beta altı":
                beyaz_1x=1.561f;
                beyaz_1y=-3.157f;
                break;
            case "beyaz iki beta yedi":
                beyaz_1x=4f;
                beyaz_1y=-3.157f;
                break;
            case "beyaz iki beta sekiz":
                beyaz_1x=6.44f;
                beyaz_1y=-3.157f;
                break;
            case "beyaz iki omega bir":
                beyaz_1x=2.76f;
                beyaz_1y=0.55f;
                break;
            case "beyaz iki omega iki":
                beyaz_1x=4f;
                beyaz_1y=0.55f;
                break;
            case "beyaz iki omega üç":
                beyaz_1x=5.2155f;
                beyaz_1y=0.55f;
                break;
            case "beyaz iki omega dört":
                beyaz_1x=2.76f;
                beyaz_1y=-0.7f;
                break;
            case "beyaz iki omega beş":
                beyaz_1x=5.215f;
                beyaz_1y=-0.7f;
                break;
            case "beyaz iki omega altı":
                beyaz_1x=2.76f;
                beyaz_1y=-1.92f;
                break;
            case "beyaz iki omega yedi":
                beyaz_1x=4f;
                beyaz_1y=-1.92f;
                break;
            case "beyaz iki omega sekiz":
                beyaz_1x=5.215f;
                beyaz_1y=-1.92f;
                break;                          // Beyaz iki tahta komutları bitti
            case "beyaz üç alfa bir":        // Beyaz üç tahta komutları başladı
                beyaz_2x=0.35f;
                beyaz_2y=3f;
                break;
            case "beyaz üç alfa iki":
                beyaz_2x=4f;
                beyaz_2y=3f;
                break;
            case "beyaz üç alfa üç":
                beyaz_2x=7.63f;
                beyaz_2y=3f;
                break;
            case "beyaz üç alfa dört":
                beyaz_2x=0.35f;
                beyaz_2y=-0.7f;
                break;
            case "beyaz üç alfa beş":
                beyaz_2x=7.63f;
                beyaz_2y=-0.7f;
                break;
            case "beyaz üç alfa altı":
                beyaz_2x=0.35f;
                beyaz_2y=-4.327f;
                break;
            case "beyaz üç alfa yedi":
                beyaz_2x=4f;
                beyaz_2y=-4.327f;
                break;
            case "beyaz üç alfa sekiz":
                beyaz_2x=7.63f;
                beyaz_2y=-4.327f;
                break;
            case "beyaz üç beta bir":
                beyaz_2x=1.561f;
                beyaz_2y=1.747f;
                break;
            case "beyaz üç beta iki":
                beyaz_2x=4f;
                beyaz_2y=1.747f;
                break;
            case "beyaz üç beta üç":
                beyaz_2x=6.44f;
                beyaz_2y=1.747f;
                break;
            case "beyaz üç beta dört":
                beyaz_2x=1.561f;
                beyaz_2y=-0.7f;
                break;
            case "beyaz üç beta beş":
                beyaz_2x=6.44f;
                beyaz_2y=-0.7f;
                break;
            case "beyaz üç beta altı":
                beyaz_2x=1.561f;
                beyaz_2y=-3.157f;
                break;
            case "beyaz üç beta yedi":
                beyaz_2x=4f;
                beyaz_2y=-3.157f;
                break;
            case "beyaz üç beta sekiz":
                beyaz_2x=6.44f;
                beyaz_2y=-3.157f;
                break;
            case "beyaz üç omega bir":
                beyaz_2x=2.76f;
                beyaz_2y=0.55f;
                break;
            case "beyaz üç omega iki":
                beyaz_2x=4f;
                beyaz_2y=0.55f;
                break;
            case "beyaz üç omega üç":
                beyaz_2x=5.2155f;
                beyaz_2y=0.55f;
                break;
            case "beyaz üç omega dört":
                beyaz_2x=2.76f;
                beyaz_2y=-0.7f;
                break;
            case "beyaz üç omega beş":
                beyaz_2x=5.215f;
                beyaz_2y=-0.7f;
                break;
            case "beyaz üç omega altı":
                beyaz_2x=2.76f;
                beyaz_2y=-1.92f;
                break;
            case "beyaz üç omega yedi":
                beyaz_2x=4f;
                beyaz_2y=-1.92f;
                break;
            case "beyaz üç omega sekiz":
                beyaz_2x=5.215f;
                beyaz_2y=-1.92f;
                break;                              // Beyaz üç tahta komutları bitti
            case "beyaz dört alfa bir":           // Beyaz dört tahta komutları başladı
                beyaz_3x=0.35f;
                beyaz_3y=3f;
                break;
            case "beyaz dört alfa iki":
                beyaz_3x=4f;
                beyaz_3y=3f;
                break;
            case "beyaz dört alfa üç":
                beyaz_3x=7.63f;
                beyaz_3y=3f;
                break;
            case "beyaz dört alfa dört":
                beyaz_3x=0.35f;
                beyaz_3y=-0.7f;
                break;
            case "beyaz dört alfa beş":
                beyaz_3x=7.63f;
                beyaz_3y=-0.7f;
                break;
            case "beyaz dört alfa altı":
                beyaz_3x=0.35f;
                beyaz_3y=-4.327f;
                break;
            case "beyaz dört alfa yedi":
                beyaz_3x=4f;
                beyaz_3y=-4.327f;
                break;
            case "beyaz dört alfa sekiz":
                beyaz_3x=7.63f;
                beyaz_3y=-4.327f;
                break;
            case "beyaz dört beta bir":
                beyaz_3x=1.561f;
                beyaz_3y=1.747f;
                break;
            case "beyaz dört beta iki":
                beyaz_3x=4f;
                beyaz_3y=1.747f;
                break;
            case "beyaz dört beta üç":
                beyaz_3x=6.44f;
                beyaz_3y=1.747f;
                break;
            case "beyaz dört beta dört":
                beyaz_3x=1.561f;
                beyaz_3y=-0.7f;
                break;
            case "beyaz dört beta beş":
                beyaz_3x=6.44f;
                beyaz_3y=-0.7f;
                break;
            case "beyaz dört beta altı":
                beyaz_3x=1.561f;
                beyaz_3y=-3.157f;
                break;
            case "beyaz dört beta yedi":
                beyaz_3x=4f;
                beyaz_3y=-3.157f;
                break;
            case "beyaz dört beta sekiz":
                beyaz_3x=6.44f;
                beyaz_3y=-3.157f;
                break;
            case "beyaz dört omega bir":
                beyaz_3x=2.76f;
                beyaz_3y=0.55f;
                break;
            case "beyaz dört omega iki":
                beyaz_3x=4f;
                beyaz_3y=0.55f;
                break;
            case "beyaz dört omega üç":
                beyaz_3x=5.2155f;
                beyaz_3y=0.55f;
                break;
            case "beyaz dört omega dört":
                beyaz_3x=2.76f;
                beyaz_3y=-0.7f;
                break;
            case "beyaz dört omega beş":
                beyaz_3x=5.215f;
                beyaz_3y=-0.7f;
                break;
            case "beyaz dört omega altı":
                beyaz_3x=2.76f;
                beyaz_3y=-1.92f;
                break;
            case "beyaz dört omega yedi":
                beyaz_3x=4f;
                beyaz_3y=-1.92f;
                break;
            case "beyaz dört omega sekiz":
                beyaz_3x=5.215f;
                beyaz_3y=-1.92f;
                break;                              // Beyaz dört tahta komutları bitti
            case "beyaz beş alfa bir":           // Beyaz beş tahta komutları başladı
                beyaz_4x=0.35f;
                beyaz_4y=3f;
                break;
            case "beyaz beş alfa iki":
                beyaz_4x=4f;
                beyaz_4y=3f;
                break;
            case "beyaz beş alfa üç":
                beyaz_4x=7.63f;
                beyaz_4y=3f;
                break;
            case "beyaz beş alfa dört":
                beyaz_4x=0.35f;
                beyaz_4y=-0.7f;
                break;
            case "beyaz beş alfa beş":
                beyaz_4x=7.63f;
                beyaz_4y=-0.7f;
                break;
            case "beyaz beş alfa altı":
                beyaz_4x=0.35f;
                beyaz_4y=-4.327f;
                break;
            case "beyaz beş alfa yedi":
                beyaz_4x=4f;
                beyaz_4y=-4.327f;
                break;
            case "beyaz beş alfa sekiz":
                beyaz_4x=7.63f;
                beyaz_4y=-4.327f;
                break;
            case "beyaz beş beta bir":
                beyaz_4x=1.561f;
                beyaz_4y=1.747f;
                break;
            case "beyaz beş beta iki":
                beyaz_4x=4f;
                beyaz_4y=1.747f;
                break;
            case "beyaz beş beta üç":
                beyaz_4x=6.44f;
                beyaz_4y=1.747f;
                break;
            case "beyaz beş beta dört":
                beyaz_4x=1.561f;
                beyaz_4y=-0.7f;
                break;
            case "beyaz beş beta beş":
                beyaz_4x=6.44f;
                beyaz_4y=-0.7f;
                break;
            case "beyaz beş beta altı":
                beyaz_4x=1.561f;
                beyaz_4y=-3.157f;
                break;
            case "beyaz beş beta yedi":
                beyaz_4x=4f;
                beyaz_4y=-3.157f;
                break;
            case "beyaz beş beta sekiz":
                beyaz_4x=6.44f;
                beyaz_4y=-3.157f;
                break;
            case "beyaz beş omega bir":
                beyaz_4x=2.76f;
                beyaz_4y=0.55f;
                break;
            case "beyaz beş omega iki":
                beyaz_4x=4f;
                beyaz_4y=0.55f;
                break;
            case "beyaz beş omega üç":
                beyaz_4x=5.2155f;
                beyaz_4y=0.55f;
                break;
            case "beyaz beş omega dört":
                beyaz_4x=2.76f;
                beyaz_4y=-0.7f;
                break;
            case "beyaz beş omega beş":
                beyaz_4x=5.215f;
                beyaz_4y=-0.7f;
                break;
            case "beyaz beş omega altı":
                beyaz_4x=2.76f;
                beyaz_4y=-1.92f;
                break;
            case "beyaz beş omega yedi":
                beyaz_4x=4f;
                beyaz_4y=-1.92f;
                break;
            case "beyaz beş omega sekiz":
                beyaz_4x=5.215f;
                beyaz_4y=-1.92f;
                break;                              // Beyaz beş tahta komutları bitti
            case "beyaz altı alfa bir":           // Beyaz altı tahta komutları başladı
                beyaz_5x=0.35f;
                beyaz_5y=3f;
                break;
            case "beyaz altı alfa iki":
                beyaz_5x=4f;
                beyaz_5y=3f;
                break;
            case "beyaz altı alfa üç":
                beyaz_5x=7.63f;
                beyaz_5y=3f;
                break;
            case "beyaz altı alfa dört":
                beyaz_5x=0.35f;
                beyaz_5y=-0.7f;
                break;
            case "beyaz altı alfa beş":
                beyaz_5x=7.63f;
                beyaz_5y=-0.7f;
                break;
            case "beyaz altı alfa altı":
                beyaz_5x=0.35f;
                beyaz_5y=-4.327f;
                break;
            case "beyaz altı alfa yedi":
                beyaz_5x=4f;
                beyaz_5y=-4.327f;
                break;
            case "beyaz altı alfa sekiz":
                beyaz_5x=7.63f;
                beyaz_5y=-4.327f;
                break;
            case "beyaz altı beta bir":
                beyaz_5x=1.561f;
                beyaz_5y=1.747f;
                break;
            case "beyaz altı beta iki":
                beyaz_5x=4f;
                beyaz_5y=1.747f;
                break;
            case "beyaz altı beta üç":
                beyaz_5x=6.44f;
                beyaz_5y=1.747f;
                break;
            case "beyaz altı beta dört":
                beyaz_5x=1.561f;
                beyaz_5y=-0.7f;
                break;
            case "beyaz altı beta beş":
                beyaz_5x=6.44f;
                beyaz_5y=-0.7f;
                break;
            case "beyaz altı beta altı":
                beyaz_5x=1.561f;
                beyaz_5y=-3.157f;
                break;
            case "beyaz altı beta yedi":
                beyaz_5x=4f;
                beyaz_5y=-3.157f;
                break;
            case "beyaz altı beta sekiz":
                beyaz_5x=6.44f;
                beyaz_5y=-3.157f;
                break;
            case "beyaz altı omega bir":
                beyaz_5x=2.76f;
                beyaz_5y=0.55f;
                break;
            case "beyaz altı omega iki":
                beyaz_5x=4f;
                beyaz_5y=0.55f;
                break;
            case "beyaz altı omega üç":
                beyaz_5x=5.2155f;
                beyaz_5y=0.55f;
                break;
            case "beyaz altı omega dört":
                beyaz_5x=2.76f;
                beyaz_5y=-0.7f;
                break;
            case "beyaz altı omega beş":
                beyaz_5x=5.215f;
                beyaz_5y=-0.7f;
                break;
            case "beyaz altı omega altı":
                beyaz_5x=2.76f;
                beyaz_5y=-1.92f;
                break;
            case "beyaz altı omega yedi":
                beyaz_5x=4f;
                beyaz_5y=-1.92f;
                break;
            case "beyaz altı omega sekiz":
                beyaz_5x=5.215f;
                beyaz_5y=-1.92f;
                break;                              // Beyaz altı tahta komutları bitti
            case "beyaz yedi alfa bir":           // Beyaz yedi tahta komutları başladı
                beyaz_6x=0.35f;
                beyaz_6y=3f;
                break;
            case "beyaz yedi alfa iki":
                beyaz_6x=4f;
                beyaz_6y=3f;
                break;
            case "beyaz yedi alfa üç":
                beyaz_6x=7.63f;
                beyaz_6y=3f;
                break;
            case "beyaz yedi alfa dört":
                beyaz_6x=0.35f;
                beyaz_6y=-0.7f;
                break;
            case "beyaz yedi alfa beş":
                beyaz_6x=7.63f;
                beyaz_6y=-0.7f;
                break;
            case "beyaz yedi alfa altı":
                beyaz_6x=0.35f;
                beyaz_6y=-4.327f;
                break;
            case "beyaz yedi alfa yedi":
                beyaz_6x=4f;
                beyaz_6y=-4.327f;
                break;
            case "beyaz yedi alfa sekiz":
                beyaz_6x=7.63f;
                beyaz_6y=-4.327f;
                break;
            case "beyaz yedi beta bir":
                beyaz_6x=1.561f;
                beyaz_6y=1.747f;
                break;
            case "beyaz yedi beta iki":
                beyaz_6x=4f;
                beyaz_6y=1.747f;
                break;
            case "beyaz yedi beta üç":
                beyaz_6x=6.44f;
                beyaz_6y=1.747f;
                break;
            case "beyaz yedi beta dört":
                beyaz_6x=1.561f;
                beyaz_6y=-0.7f;
                break;
            case "beyaz yedi beta beş":
                beyaz_6x=6.44f;
                beyaz_6y=-0.7f;
                break;
            case "beyaz yedi beta altı":
                beyaz_6x=1.561f;
                beyaz_6y=-3.157f;
                break;
            case "beyaz yedi beta yedi":
                beyaz_6x=4f;
                beyaz_6y=-3.157f;
                break;
            case "beyaz yedi beta sekiz":
                beyaz_6x=6.44f;
                beyaz_6y=-3.157f;
                break;
            case "beyaz yedi omega bir":
                beyaz_6x=2.76f;
                beyaz_6y=0.55f;
                break;
            case "beyaz yedi omega iki":
                beyaz_6x=4f;
                beyaz_6y=0.55f;
                break;
            case "beyaz yedi omega üç":
                beyaz_6x=5.2155f;
                beyaz_6y=0.55f;
                break;
            case "beyaz yedi omega dört":
                beyaz_6x=2.76f;
                beyaz_6y=-0.7f;
                break;
            case "beyaz yedi omega beş":
                beyaz_6x=5.215f;
                beyaz_6y=-0.7f;
                break;
            case "beyaz yedi omega altı":
                beyaz_6x=2.76f;
                beyaz_6y=-1.92f;
                break;
            case "beyaz yedi omega yedi":
                beyaz_6x=4f;
                beyaz_6y=-1.92f;
                break;
            case "beyaz yedi omega sekiz":
                beyaz_6x=5.215f;
                beyaz_6y=-1.92f;
                break;                              // Beyaz yedi tahta komutları bitti
            case "beyaz sekiz alfa bir":           // Beyaz sekiz tahta komutları başladı
                beyaz_7x=0.35f;
                beyaz_7y=3f;
                break;
            case "beyaz sekiz alfa iki":
                beyaz_7x=4f;
                beyaz_7y=3f;
                break;
            case "beyaz sekiz alfa üç":
                beyaz_7x=7.63f;
                beyaz_7y=3f;
                break;
            case "beyaz sekiz alfa dört":
                beyaz_7x=0.35f;
                beyaz_7y=-0.7f;
                break;
            case "beyaz sekiz alfa beş":
                beyaz_7x=7.63f;
                beyaz_7y=-0.7f;
                break;
            case "beyaz sekiz alfa altı":
                beyaz_7x=0.35f;
                beyaz_7y=-4.327f;
                break;
            case "beyaz sekiz alfa yedi":
                beyaz_7x=4f;
                beyaz_7y=-4.327f;
                break;
            case "beyaz sekiz alfa sekiz":
                beyaz_7x=7.63f;
                beyaz_7y=-4.327f;
                break;
            case "beyaz sekiz beta bir":
                beyaz_7x=1.561f;
                beyaz_7y=1.747f;
                break;
            case "beyaz sekiz beta iki":
                beyaz_7x=4f;
                beyaz_7y=1.747f;
                break;
            case "beyaz sekiz beta üç":
                beyaz_7x=6.44f;
                beyaz_7y=1.747f;
                break;
            case "beyaz sekiz beta dört":
                beyaz_7x=1.561f;
                beyaz_7y=-0.7f;
                break;
            case "beyaz sekiz beta beş":
                beyaz_7x=6.44f;
                beyaz_7y=-0.7f;
                break;
            case "beyaz sekiz beta altı":
                beyaz_7x=1.561f;
                beyaz_7y=-3.157f;
                break;
            case "beyaz sekiz beta yedi":
                beyaz_7x=4f;
                beyaz_7y=-3.157f;
                break;
            case "beyaz sekiz beta sekiz":
                beyaz_7x=6.44f;
                beyaz_7y=-3.157f;
                break;
            case "beyaz sekiz omega bir":
                beyaz_7x=2.76f;
                beyaz_7y=0.55f;
                break;
            case "beyaz sekiz omega iki":
                beyaz_7x=4f;
                beyaz_7y=0.55f;
                break;
            case "beyaz sekiz omega üç":
                beyaz_7x=5.2155f;
                beyaz_7y=0.55f;
                break;
            case "beyaz sekiz omega dört":
                beyaz_7x=2.76f;
                beyaz_7y=-0.7f;
                break;
            case "beyaz sekiz omega beş":
                beyaz_7x=5.215f;
                beyaz_7y=-0.7f;
                break;
            case "beyaz sekiz omega altı":
                beyaz_7x=2.76f;
                beyaz_7y=-1.92f;
                break;
            case "beyaz sekiz omega yedi":
                beyaz_7x=4f;
                beyaz_7y=-1.92f;
                break;
            case "beyaz sekiz omega sekiz":
                beyaz_7x=5.215f;
                beyaz_7y=-1.92f;
                break;                              // Beyaz sekiz tahta komutları bitti
            case "beyaz dokuz alfa bir":           // Beyaz dokuz tahta komutları başladı
                beyaz_8x=0.35f;
                beyaz_8y=3f;
                break;
            case "beyaz dokuz alfa iki":
                beyaz_8x=4f;
                beyaz_8y=3f;
                break;
            case "beyaz dokuz alfa üç":
                beyaz_8x=7.63f;
                beyaz_8y=3f;
                break;
            case "beyaz dokuz alfa dört":
                beyaz_8x=0.35f;
                beyaz_8y=-0.7f;
                break;
            case "beyaz dokuz alfa beş":
                beyaz_8x=7.63f;
                beyaz_8y=-0.7f;
                break;
            case "beyaz dokuz alfa altı":
                beyaz_8x=0.35f;
                beyaz_8y=-4.327f;
                break;
            case "beyaz dokuz alfa yedi":
                beyaz_8x=4f;
                beyaz_8y=-4.327f;
                break;
            case "beyaz dokuz alfa sekiz":
                beyaz_8x=7.63f;
                beyaz_8y=-4.327f;
                break;
            case "beyaz dokuz beta bir":
                beyaz_8x=1.561f;
                beyaz_8y=1.747f;
                break;
            case "beyaz dokuz beta iki":
                beyaz_8x=4f;
                beyaz_8y=1.747f;
                break;
            case "beyaz dokuz beta üç":
                beyaz_8x=6.44f;
                beyaz_8y=1.747f;
                break;
            case "beyaz dokuz beta dört":
                beyaz_8x=1.561f;
                beyaz_8y=-0.7f;
                break;
            case "beyaz dokuz beta beş":
                beyaz_8x=6.44f;
                beyaz_8y=-0.7f;
                break;
            case "beyaz dokuz beta altı":
                beyaz_8x=1.561f;
                beyaz_8y=-3.157f;
                break;
            case "beyaz dokuz beta yedi":
                beyaz_8x=4f;
                beyaz_8y=-3.157f;
                break;
            case "beyaz dokuz beta sekiz":
                beyaz_8x=6.44f;
                beyaz_8y=-3.157f;
                break;
            case "beyaz dokuz omega bir":
                beyaz_8x=2.76f;
                beyaz_8y=0.55f;
                break;
            case "beyaz dokuz omega iki":
                beyaz_8x=4f;
                beyaz_8y=0.55f;
                break;
            case "beyaz dokuz omega üç":
                beyaz_8x=5.2155f;
                beyaz_8y=0.55f;
                break;
            case "beyaz dokuz omega dört":
                beyaz_8x=2.76f;
                beyaz_8y=-0.7f;
                break;
            case "beyaz dokuz omega beş":
                beyaz_8x=5.215f;
                beyaz_8y=-0.7f;
                break;
            case "beyaz dokuz omega altı":
                beyaz_8x=2.76f;
                beyaz_8y=-1.92f;
                break;
            case "beyaz dokuz omega yedi":
                beyaz_8x=4f;
                beyaz_8y=-1.92f;
                break;
            case "beyaz dokuz omega sekiz":
                beyaz_8x=5.215f;
                beyaz_8y=-1.92f;
                break;                              // Beyaz dokuz tahta komutları bitti
            case "siyah bir alfa bir":            // Siyah bir tahta komutları başladı
                siyah_0x=0.35f;
                siyah_0y=3f;
                break;
            case "siyah bir alfa iki":
                siyah_0x=4f;
                siyah_0y=3f;
                break;
            case "siyah bir alfa üç":
                siyah_0x=7.63f;
                siyah_0y=3f;
                break;
            case "siyah bir alfa dört":
                siyah_0x=0.35f;
                siyah_0y=-0.7f;
                break;
            case "siyah bir alfa beş":
                siyah_0x=7.63f;
                siyah_0y=-0.7f;
                break;
            case "siyah bir alfa altı":
                siyah_0x=0.35f;
                siyah_0y=-4.327f;
                break;
            case "siyah bir alfa yedi":
                siyah_0x=4f;
                siyah_0y=-4.327f;
                break;
            case "siyah bir alfa sekiz":
                siyah_0x=7.63f;
                siyah_0y=-4.327f;
                break;
            case "siyah bir beta bir":
                siyah_0x=1.561f;
                siyah_0y=1.747f;
                break;
            case "siyah bir beta iki":
                siyah_0x=4f;
                siyah_0y=1.747f;
                break;
            case "siyah bir beta üç":
                siyah_0x=6.44f;
                siyah_0y=1.747f;
                break;
            case "siyah bir beta dört":
                siyah_0x=1.561f;
                siyah_0y=-0.7f;
                break;
            case "siyah bir beta beş":
                siyah_0x=6.44f;
                siyah_0y=-0.7f;
                break;
            case "siyah bir beta altı":
                siyah_0x=1.561f;
                siyah_0y=-3.157f;
                break;
            case "siyah bir beta yedi":
                siyah_0x=4f;
                siyah_0y=-3.157f;
                break;
            case "siyah bir beta sekiz":
                siyah_0x=6.44f;
                siyah_0y=-3.157f;
                break;
            case "siyah bir omega bir":
                siyah_0x=2.76f;
                siyah_0y=0.55f;
                break;
            case "siyah bir omega iki":
                siyah_0x=4f;
                siyah_0y=0.55f;
                break;
            case "siyah bir omega üç":
                siyah_0x=5.2155f;
                siyah_0y=0.55f;
                break;
            case "siyah bir omega dört":
                siyah_0x=2.76f;
                siyah_0y=-0.7f;
                break;
            case "siyah bir omega beş":
                siyah_0x=5.215f;
                siyah_0y=-0.7f;
                break;
            case "siyah bir omega altı":
                siyah_0x=2.76f;
                siyah_0y=-1.92f;
                break;
            case "siyah bir omega yedi":
                siyah_0x=4f;
                siyah_0y=-1.92f;
                break;
            case "siyah bir omega sekiz":
                siyah_0x=5.215f;
                siyah_0y=-1.92f;
                break;
            case "siyah iki alfa bir":    // Siyah iki tahta komutları başladı
                siyah_1x=0.35f;
                siyah_1y=3f;
                break;
            case "siyah iki alfa iki":
                siyah_1x=4f;
                siyah_1y=3f;
                break;
            case "siyah iki alfa üç":
                siyah_1x=7.63f;
                siyah_1y=3f;
                break;
            case "siyah iki alfa dört":
                siyah_1x=0.35f;
                siyah_1y=-0.7f;
                break;
            case "siyah iki alfa beş":
                siyah_1x=7.63f;
                siyah_1y=-0.7f;
                break;
            case "siyah iki alfa altı":
                siyah_1x=0.35f;
                siyah_1y=-4.327f;
                break;
            case "siyah iki alfa yedi":
                siyah_1x=4f;
                siyah_1y=-4.327f;
                break;
            case "siyah iki alfa sekiz":
                siyah_1x=7.63f;
                siyah_1y=-4.327f;
                break;
            case "siyah iki beta bir":
                siyah_1x=1.561f;
                siyah_1y=1.747f;
                break;
            case "siyah iki beta iki":
                siyah_1x=4f;
                siyah_1y=1.747f;
                break;
            case "siyah iki beta üç":
                siyah_1x=6.44f;
                siyah_1y=1.747f;
                break;
            case "siyah iki beta dört":
                siyah_1x=1.561f;
                siyah_1y=-0.7f;
                break;
            case "siyah iki beta beş":
                siyah_1x=6.44f;
                siyah_1y=-0.7f;
                break;
            case "siyah iki beta altı":
                siyah_1x=1.561f;
                siyah_1y=-3.157f;
                break;
            case "siyah iki beta yedi":
                siyah_1x=4f;
                siyah_1y=-3.157f;
                break;
            case "siyah iki beta sekiz":
                siyah_1x=6.44f;
                siyah_1y=-3.157f;
                break;
            case "siyah iki omega bir":
                siyah_1x=2.76f;
                siyah_1y=0.55f;
                break;
            case "siyah iki omega iki":
                siyah_1x=4f;
                siyah_1y=0.55f;
                break;
            case "siyah iki omega üç":
                siyah_1x=5.2155f;
                siyah_1y=0.55f;
                break;
            case "siyah iki omega dört":
                siyah_1x=2.76f;
                siyah_1y=-0.7f;
                break;
            case "siyah iki omega beş":
                siyah_1x=5.215f;
                siyah_1y=-0.7f;
                break;
            case "siyah iki omega altı":
                siyah_1x=2.76f;
                siyah_1y=-1.92f;
                break;
            case "siyah iki omega yedi":
                siyah_1x=4f;
                siyah_1y=-1.92f;
                break;
            case "siyah iki omega sekiz":
                siyah_1x=5.215f;
                siyah_1y=-1.92f;
                break;                          // Siyah iki tahta komutları bitti
            case "siyah üç alfa bir":        // Siyah üç tahta komutları başladı
                siyah_2x=0.35f;
                siyah_2y=3f;
                break;
            case "siyah üç alfa iki":
                siyah_2x=4f;
                siyah_2y=3f;
                break;
            case "siyah üç alfa üç":
                siyah_2x=7.63f;
                siyah_2y=3f;
                break;
            case "siyah üç alfa dört":
                siyah_2x=0.35f;
                siyah_2y=-0.7f;
                break;
            case "siyah üç alfa beş":
                siyah_2x=7.63f;
                siyah_2y=-0.7f;
                break;
            case "siyah üç alfa altı":
                siyah_2x=0.35f;
                siyah_2y=-4.327f;
                break;
            case "siyah üç alfa yedi":
                siyah_2x=4f;
                siyah_2y=-4.327f;
                break;
            case "siyah üç alfa sekiz":
                siyah_2x=7.63f;
                siyah_2y=-4.327f;
                break;
            case "siyah üç beta bir":
                siyah_2x=1.561f;
                siyah_2y=1.747f;
                break;
            case "siyah üç beta iki":
                siyah_2x=4f;
                siyah_2y=1.747f;
                break;
            case "siyah üç beta üç":
                siyah_2x=6.44f;
                siyah_2y=1.747f;
                break;
            case "siyah üç beta dört":
                siyah_2x=1.561f;
                siyah_2y=-0.7f;
                break;
            case "siyah üç beta beş":
                siyah_2x=6.44f;
                siyah_2y=-0.7f;
                break;
            case "siyah üç beta altı":
                siyah_2x=1.561f;
                siyah_2y=-3.157f;
                break;
            case "siyah üç beta yedi":
                siyah_2x=4f;
                siyah_2y=-3.157f;
                break;
            case "siyah üç beta sekiz":
                siyah_2x=6.44f;
                siyah_2y=-3.157f;
                break;
            case "siyah üç omega bir":
                siyah_2x=2.76f;
                siyah_2y=0.55f;
                break;
            case "siyah üç omega iki":
                siyah_2x=4f;
                siyah_2y=0.55f;
                break;
            case "siyah üç omega üç":
                siyah_2x=5.2155f;
                siyah_2y=0.55f;
                break;
            case "siyah üç omega dört":
                siyah_2x=2.76f;
                siyah_2y=-0.7f;
                break;
            case "siyah üç omega beş":
                siyah_2x=5.215f;
                siyah_2y=-0.7f;
                break;
            case "siyah üç omega altı":
                siyah_2x=2.76f;
                siyah_2y=-1.92f;
                break;
            case "siyah üç omega yedi":
                siyah_2x=4f;
                siyah_2y=-1.92f;
                break;
            case "siyah üç omega sekiz":
                siyah_2x=5.215f;
                siyah_2y=-1.92f;
                break;                              // Siyah üç tahta komutları bitti
            case "siyah dört alfa bir":           // Siyah dört tahta komutları başladı
                siyah_3x=0.35f;
                siyah_3y=3f;
                break;
            case "siyah dört alfa iki":
                siyah_3x=4f;
                siyah_3y=3f;
                break;
            case "siyah dört alfa üç":
                siyah_3x=7.63f;
                siyah_3y=3f;
                break;
            case "siyah dört alfa dört":
                siyah_3x=0.35f;
                siyah_3y=-0.7f;
                break;
            case "siyah dört alfa beş":
                siyah_3x=7.63f;
                siyah_3y=-0.7f;
                break;
            case "siyah dört alfa altı":
                siyah_3x=0.35f;
                siyah_3y=-4.327f;
                break;
            case "siyah dört alfa yedi":
                siyah_3x=4f;
                siyah_3y=-4.327f;
                break;
            case "siyah dört alfa sekiz":
                siyah_3x=7.63f;
                siyah_3y=-4.327f;
                break;
            case "siyah dört beta bir":
                siyah_3x=1.561f;
                siyah_3y=1.747f;
                break;
            case "siyah dört beta iki":
                siyah_3x=4f;
                siyah_3y=1.747f;
                break;
            case "siyah dört beta üç":
                siyah_3x=6.44f;
                siyah_3y=1.747f;
                break;
            case "siyah dört beta dört":
                siyah_3x=1.561f;
                siyah_3y=-0.7f;
                break;
            case "siyah dört beta beş":
                siyah_3x=6.44f;
                siyah_3y=-0.7f;
                break;
            case "siyah dört beta altı":
                siyah_3x=1.561f;
                siyah_3y=-3.157f;
                break;
            case "siyah dört beta yedi":
                siyah_3x=4f;
                siyah_3y=-3.157f;
                break;
            case "siyah dört beta sekiz":
                siyah_3x=6.44f;
                siyah_3y=-3.157f;
                break;
            case "siyah dört omega bir":
                siyah_3x=2.76f;
                siyah_3y=0.55f;
                break;
            case "siyah dört omega iki":
                siyah_3x=4f;
                siyah_3y=0.55f;
                break;
            case "siyah dört omega üç":
                siyah_3x=5.2155f;
                siyah_3y=0.55f;
                break;
            case "siyah dört omega dört":
                siyah_3x=2.76f;
                siyah_3y=-0.7f;
                break;
            case "siyah dört omega beş":
                siyah_3x=5.215f;
                siyah_3y=-0.7f;
                break;
            case "siyah dört omega altı":
                siyah_3x=2.76f;
                siyah_3y=-1.92f;
                break;
            case "siyah dört omega yedi":
                siyah_3x=4f;
                siyah_3y=-1.92f;
                break;
            case "siyah dört omega sekiz":
                siyah_3x=5.215f;
                siyah_3y=-1.92f;
                break;                              // Siyah dört tahta komutları bitti
            case "siyah beş alfa bir":           // Siyah beş tahta komutları başladı
                siyah_4x=0.35f;
                siyah_4y=3f;
                break;
            case "siyah beş alfa iki":
                siyah_4x=4f;
                siyah_4y=3f;
                break;
            case "siyah beş alfa üç":
                siyah_4x=7.63f;
                siyah_4y=3f;
                break;
            case "siyah beş alfa dört":
                siyah_4x=0.35f;
                siyah_4y=-0.7f;
                break;
            case "siyah beş alfa beş":
                siyah_4x=7.63f;
                siyah_4y=-0.7f;
                break;
            case "siyah beş alfa altı":
                siyah_4x=0.35f;
                siyah_4y=-4.327f;
                break;
            case "siyah beş alfa yedi":
                siyah_4x=4f;
                siyah_4y=-4.327f;
                break;
            case "siyah beş alfa sekiz":
                siyah_4x=7.63f;
                siyah_4y=-4.327f;
                break;
            case "siyah beş beta bir":
                siyah_4x=1.561f;
                siyah_4y=1.747f;
                break;
            case "siyah beş beta iki":
                siyah_4x=4f;
                siyah_4y=1.747f;
                break;
            case "siyah beş beta üç":
                siyah_4x=6.44f;
                siyah_4y=1.747f;
                break;
            case "siyah beş beta dört":
                siyah_4x=1.561f;
                siyah_4y=-0.7f;
                break;
            case "siyah beş beta beş":
                siyah_4x=6.44f;
                siyah_4y=-0.7f;
                break;
            case "siyah beş beta altı":
                siyah_4x=1.561f;
                siyah_4y=-3.157f;
                break;
            case "siyah beş beta yedi":
                siyah_4x=4f;
                siyah_4y=-3.157f;
                break;
            case "siyah beş beta sekiz":
                siyah_4x=6.44f;
                siyah_4y=-3.157f;
                break;
            case "siyah beş omega bir":
                siyah_4x=2.76f;
                siyah_4y=0.55f;
                break;
            case "siyah beş omega iki":
                siyah_4x=4f;
                siyah_4y=0.55f;
                break;
            case "siyah beş omega üç":
                siyah_4x=5.2155f;
                siyah_4y=0.55f;
                break;
            case "siyah beş omega dört":
                siyah_4x=2.76f;
                siyah_4y=-0.7f;
                break;
            case "siyah beş omega beş":
                siyah_4x=5.215f;
                siyah_4y=-0.7f;
                break;
            case "siyah beş omega altı":
                siyah_4x=2.76f;
                siyah_4y=-1.92f;
                break;
            case "siyah beş omega yedi":
                siyah_4x=4f;
                siyah_4y=-1.92f;
                break;
            case "siyah beş omega sekiz":
                siyah_4x=5.215f;
                siyah_4y=-1.92f;
                break;                              // Siyah beş tahta komutları bitti
            case "siyah altı alfa bir":           // Siyah altı tahta komutları başladı
                siyah_5x=0.35f;
                siyah_5y=3f;
                break;
            case "siyah altı alfa iki":
                siyah_5x=4f;
                siyah_5y=3f;
                break;
            case "siyah altı alfa üç":
                siyah_5x=7.63f;
                siyah_5y=3f;
                break;
            case "siyah altı alfa dört":
                siyah_5x=0.35f;
                siyah_5y=-0.7f;
                break;
            case "siyah altı alfa beş":
                siyah_5x=7.63f;
                siyah_5y=-0.7f;
                break;
            case "siyah altı alfa altı":
                siyah_5x=0.35f;
                siyah_5y=-4.327f;
                break;
            case "siyah altı alfa yedi":
                siyah_5x=4f;
                siyah_5y=-4.327f;
                break;
            case "siyah altı alfa sekiz":
                siyah_5x=7.63f;
                siyah_5y=-4.327f;
                break;
            case "siyah altı beta bir":
                siyah_5x=1.561f;
                siyah_5y=1.747f;
                break;
            case "siyah altı beta iki":
                siyah_5x=4f;
                siyah_5y=1.747f;
                break;
            case "siyah altı beta üç":
                siyah_5x=6.44f;
                siyah_5y=1.747f;
                break;
            case "siyah altı beta dört":
                siyah_5x=1.561f;
                siyah_5y=-0.7f;
                break;
            case "siyah altı beta beş":
                siyah_5x=6.44f;
                siyah_5y=-0.7f;
                break;
            case "siyah altı beta altı":
                siyah_5x=1.561f;
                siyah_5y=-3.157f;
                break;
            case "siyah altı beta yedi":
                siyah_5x=4f;
                siyah_5y=-3.157f;
                break;
            case "siyah altı beta sekiz":
                siyah_5x=6.44f;
                siyah_5y=-3.157f;
                break;
            case "siyah altı omega bir":
                siyah_5x=2.76f;
                siyah_5y=0.55f;
                break;
            case "siyah altı omega iki":
                siyah_5x=4f;
                siyah_5y=0.55f;
                break;
            case "siyah altı omega üç":
                siyah_5x=5.2155f;
                siyah_5y=0.55f;
                break;
            case "siyah altı omega dört":
                siyah_5x=2.76f;
                siyah_5y=-0.7f;
                break;
            case "siyah altı omega beş":
                siyah_5x=5.215f;
                siyah_5y=-0.7f;
                break;
            case "siyah altı omega altı":
                siyah_5x=2.76f;
                siyah_5y=-1.92f;
                break;
            case "siyah altı omega yedi":
                siyah_5x=4f;
                siyah_5y=-1.92f;
                break;
            case "siyah altı omega sekiz":
                siyah_5x=5.215f;
                siyah_5y=-1.92f;
                break;                              // Siyah altı tahta komutları bitti
            case "siyah yedi alfa bir":           // Siyah yedi tahta komutları başladı
                siyah_6x=0.35f;
                siyah_6y=3f;
                break;
            case "siyah yedi alfa iki":
                siyah_6x=4f;
                siyah_6y=3f;
                break;
            case "siyah yedi alfa üç":
                siyah_6x=7.63f;
                siyah_6y=3f;
                break;
            case "siyah yedi alfa dört":
                siyah_6x=0.35f;
                siyah_6y=-0.7f;
                break;
            case "siyah yedi alfa beş":
                siyah_6x=7.63f;
                siyah_6y=-0.7f;
                break;
            case "siyah yedi alfa altı":
                siyah_6x=0.35f;
                siyah_6y=-4.327f;
                break;
            case "siyah yedi alfa yedi":
                siyah_6x=4f;
                siyah_6y=-4.327f;
                break;
            case "siyah yedi alfa sekiz":
                siyah_6x=7.63f;
                siyah_6y=-4.327f;
                break;
            case "siyah yedi beta bir":
                siyah_6x=1.561f;
                siyah_6y=1.747f;
                break;
            case "siyah yedi beta iki":
                siyah_6x=4f;
                siyah_6y=1.747f;
                break;
            case "siyah yedi beta üç":
                siyah_6x=6.44f;
                siyah_6y=1.747f;
                break;
            case "siyah yedi beta dört":
                siyah_6x=1.561f;
                siyah_6y=-0.7f;
                break;
            case "siyah yedi beta beş":
                siyah_6x=6.44f;
                siyah_6y=-0.7f;
                break;
            case "siyah yedi beta altı":
                siyah_6x=1.561f;
                siyah_6y=-3.157f;
                break;
            case "siyah yedi beta yedi":
                siyah_6x=4f;
                siyah_6y=-3.157f;
                break;
            case "siyah yedi beta sekiz":
                siyah_6x=6.44f;
                siyah_6y=-3.157f;
                break;
            case "siyah yedi omega bir":
                siyah_6x=2.76f;
                siyah_6y=0.55f;
                break;
            case "siyah yedi omega iki":
                siyah_6x=4f;
                siyah_6y=0.55f;
                break;
            case "siyah yedi omega üç":
                siyah_6x=5.2155f;
                siyah_6y=0.55f;
                break;
            case "siyah yedi omega dört":
                siyah_6x=2.76f;
                siyah_6y=-0.7f;
                break;
            case "siyah yedi omega beş":
                siyah_6x=5.215f;
                siyah_6y=-0.7f;
                break;
            case "siyah yedi omega altı":
                siyah_6x=2.76f;
                siyah_6y=-1.92f;
                break;
            case "siyah yedi omega yedi":
                siyah_6x=4f;
                siyah_6y=-1.92f;
                break;
            case "siyah yedi omega sekiz":
                siyah_6x=5.215f;
                siyah_6y=-1.92f;
                break;                              // Siyah yedi tahta komutları bitti
            case "siyah sekiz alfa bir":           // Siyah sekiz tahta komutları başladı
                siyah_7x=0.35f;
                siyah_7y=3f;
                break;
            case "siyah sekiz alfa iki":
                siyah_7x=4f;
                siyah_7y=3f;
                break;
            case "siyah sekiz alfa üç":
                siyah_7x=7.63f;
                siyah_7y=3f;
                break;
            case "siyah sekiz alfa dört":
                siyah_7x=0.35f;
                siyah_7y=-0.7f;
                break;
            case "siyah sekiz alfa beş":
                siyah_7x=7.63f;
                siyah_7y=-0.7f;
                break;
            case "siyah sekiz alfa altı":
                siyah_7x=0.35f;
                siyah_7y=-4.327f;
                break;
            case "siyah sekiz alfa yedi":
                siyah_7x=4f;
                siyah_7y=-4.327f;
                break;
            case "siyah sekiz alfa sekiz":
                siyah_7x=7.63f;
                siyah_7y=-4.327f;
                break;
            case "siyah sekiz beta bir":
                siyah_7x=1.561f;
                siyah_7y=1.747f;
                break;
            case "siyah sekiz beta iki":
                siyah_7x=4f;
                siyah_7y=1.747f;
                break;
            case "siyah sekiz beta üç":
                siyah_7x=6.44f;
                siyah_7y=1.747f;
                break;
            case "siyah sekiz beta dört":
                siyah_7x=1.561f;
                siyah_7y=-0.7f;
                break;
            case "siyah sekiz beta beş":
                siyah_7x=6.44f;
                siyah_7y=-0.7f;
                break;
            case "siyah sekiz beta altı":
                siyah_7x=1.561f;
                siyah_7y=-3.157f;
                break;
            case "siyah sekiz beta yedi":
                siyah_7x=4f;
                siyah_7y=-3.157f;
                break;
            case "siyah sekiz beta sekiz":
                siyah_7x=6.44f;
                siyah_7y=-3.157f;
                break;
            case "siyah sekiz omega bir":
                siyah_7x=2.76f;
                siyah_7y=0.55f;
                break;
            case "siyah sekiz omega iki":
                siyah_7x=4f;
                siyah_7y=0.55f;
                break;
            case "siyah sekiz omega üç":
                siyah_7x=5.2155f;
                siyah_7y=0.55f;
                break;
            case "siyah sekiz omega dört":
                siyah_7x=2.76f;
                siyah_7y=-0.7f;
                break;
            case "siyah sekiz omega beş":
                siyah_7x=5.215f;
                siyah_7y=-0.7f;
                break;
            case "siyah sekiz omega altı":
                siyah_7x=2.76f;
                siyah_7y=-1.92f;
                break;
            case "siyah sekiz omega yedi":
                siyah_7x=4f;
                siyah_7y=-1.92f;
                break;
            case "siyah sekiz omega sekiz":
                siyah_7x=5.215f;
                siyah_7y=-1.92f;
                break;                              // Siyah sekiz tahta komutları bitti
            case "siyah dokuz alfa bir":           // Siyah dokuz tahta komutları başladı
                siyah_8x=0.35f;
                siyah_8y=3f;
                break;
            case "siyah dokuz alfa iki":
                siyah_8x=4f;
                siyah_8y=3f;
                break;
            case "siyah dokuz alfa üç":
                siyah_8x=7.63f;
                siyah_8y=3f;
                break;
            case "siyah dokuz alfa dört":
                siyah_8x=0.35f;
                siyah_8y=-0.7f;
                break;
            case "siyah dokuz alfa beş":
                siyah_8x=7.63f;
                siyah_8y=-0.7f;
                break;
            case "siyah dokuz alfa altı":
                siyah_8x=0.35f;
                siyah_8y=-4.327f;
                break;
            case "siyah dokuz alfa yedi":
                siyah_8x=4f;
                siyah_8y=-4.327f;
                break;
            case "siyah dokuz alfa sekiz":
                siyah_8x=7.63f;
                siyah_8y=-4.327f;
                break;
            case "siyah dokuz beta bir":
                siyah_8x=1.561f;
                siyah_8y=1.747f;
                break;
            case "siyah dokuz beta iki":
                siyah_8x=4f;
                siyah_8y=1.747f;
                break;
            case "siyah dokuz beta üç":
                siyah_8x=6.44f;
                siyah_8y=1.747f;
                break;
            case "siyah dokuz beta dört":
                siyah_8x=1.561f;
                siyah_8y=-0.7f;
                break;
            case "siyah dokuz beta beş":
                siyah_8x=6.44f;
                siyah_8y=-0.7f;
                break;
            case "siyah dokuz beta altı":
                siyah_8x=1.561f;
                siyah_8y=-3.157f;
                break;
            case "siyah dokuz beta yedi":
                siyah_8x=4f;
                siyah_8y=-3.157f;
                break;
            case "siyah dokuz beta sekiz":
                siyah_8x=6.44f;
                siyah_8y=-3.157f;
                break;
            case "siyah dokuz omega bir":
                siyah_8x=2.76f;
                siyah_8y=0.55f;
                break;
            case "siyah dokuz omega iki":
                siyah_8x=4f;
                siyah_8y=0.55f;
                break;
            case "siyah dokuz omega üç":
                siyah_8x=5.2155f;
                siyah_8y=0.55f;
                break;
            case "siyah dokuz omega dört":
                siyah_8x=2.76f;
                siyah_8y=-0.7f;
                break;
            case "siyah dokuz omega beş":
                siyah_8x=5.215f;
                siyah_8y=-0.7f;
                break;
            case "siyah dokuz omega altı":
                siyah_8x=2.76f;
                siyah_8y=-1.92f;
                break;
            case "siyah dokuz omega yedi":
                siyah_8x=4f;
                siyah_8y=-1.92f;
                break;
            case "siyah dokuz omega sekiz":
                siyah_8x=5.215f;
                siyah_8y=-1.92f;
                break;                              // Siyah dokuz tahta komutları bitti
            case "sil beyaz bir":
               beyaz_0.SetActive(false);
                break;
            case "sil beyaz iki":
               beyaz_1.SetActive(false);
                break;
            case "sil beyaz üç":
               beyaz_2.SetActive(false);
                break;
            case "sil beyaz dört":
               beyaz_3.SetActive(false);
                break;
            case "sil beyaz beş":
               beyaz_4.SetActive(false);
                break;
            case "sil beyaz altı":
               beyaz_5.SetActive(false);
                break;
            case "sil beyaz yedi":
               beyaz_6.SetActive(false);
                break;
            case "sil beyaz sekiz":
               beyaz_7.SetActive(false);
                break;
            case "sil beyaz dokuz":
               beyaz_8.SetActive(false);
                break;
            case "sil siyah bir":
               siyah_0.SetActive(false);
                break;
            case "sil siyah iki":
               siyah_1.SetActive(false);
                break;
            case "sil siyah üç":
               siyah_2.SetActive(false);
                break;
            case "sil siyah dört":
               siyah_3.SetActive(false);
                break;
            case "sil siyah beş":
               siyah_4.SetActive(false);
                break;
            case "sil siyah altı":
               siyah_5.SetActive(false);
                break;
            case "sil siyah yedi":
               siyah_6.SetActive(false);
                break;
            case "sil siyah sekiz":
               siyah_7.SetActive(false);
                break;
            case "sil siyah dokuz":
               siyah_8.SetActive(false);
                break;
            case "yeni oyun":
               SceneManager.LoadScene("GameScene");
            /*
               beyaz_0.SetActive(true);
               beyaz_1.SetActive(true);
               beyaz_2.SetActive(true);
               beyaz_3.SetActive(true);
               beyaz_4.SetActive(true);
               beyaz_5.SetActive(true);
               beyaz_6.SetActive(true);
               beyaz_7.SetActive(true);
               beyaz_8.SetActive(true);
               siyah_0.SetActive(true);
               siyah_1.SetActive(true);
               siyah_2.SetActive(true);
               siyah_3.SetActive(true);
               siyah_4.SetActive(true);
               siyah_5.SetActive(true);
               siyah_6.SetActive(true);
               siyah_7.SetActive(true);
               siyah_8.SetActive(true);*/
                break;
            case "geri al beyaz bir":
               beyaz_0x = -8f;
               beyaz_0y = -3f;
               beyaz_0.SetActive(true);
                break;
            case "geri al beyaz iki":
               beyaz_1x = -7.08f;
               beyaz_1y = -3f;
               beyaz_1.SetActive(true);
                break;
            case "geri al beyaz üç":
               beyaz_2x = -6.17f;
               beyaz_2y = -3f;
               beyaz_2.SetActive(true);
                break;
            case "geri al beyaz dört":
               beyaz_3x = -5.259f;
               beyaz_3y = -3f;
               beyaz_3.SetActive(true);
                break;
            case "geri al beyaz beş":
               beyaz_4x = -4.344f;
               beyaz_4y = -3f;
               beyaz_4.SetActive(true);
                break;
            case "geri al beyaz altı":
               beyaz_5x = -3.4402f;
               beyaz_5y = -3f;
               beyaz_5.SetActive(true);
                break;
            case "geri al beyaz yedi":
               beyaz_6x = -2.52f;
               beyaz_6y = -3f;
               beyaz_6.SetActive(true);
                break;
            case "geri al beyaz sekiz":
               beyaz_7x = -1.606f;
               beyaz_7y = -3f;
               beyaz_7.SetActive(true);
                break;
            case "geri al beyaz dokuz":
               beyaz_8x = -0.693f;
               beyaz_8y = -3f;
               beyaz_8.SetActive(true);
                break;
            case "geri al siyah bir":
               siyah_0x = -8f;
               siyah_0y = -4.3f;
               siyah_0.SetActive(true);
                break;
            case "geri al siyah iki":
               siyah_1x = -7.08f;
               siyah_1y = -4.3f;
               siyah_1.SetActive(true);
                break;
            case "geri al siyah üç":
               siyah_2x = -6.17f;
               siyah_2y = -4.3f;
               siyah_2.SetActive(true);
                break;
            case "geri al siyah dört":
               siyah_3x = -5.259f;
               siyah_3y = -4.3f;
               siyah_3.SetActive(true);
                break;
            case "geri al siyah beş":
               siyah_4x = -4.344f;
               siyah_4y = -4.3f;
               siyah_4.SetActive(true);
                break;
            case "geri al siyah altı":
               siyah_5x = -3.4402f;
               siyah_5y = -4.3f;
               siyah_5.SetActive(true);
                break;
            case "geri al siyah yedi":
               siyah_6x = -2.52f;
               siyah_6y = -4.3f;
               siyah_6.SetActive(true);
                break;
            case "geri al siyah sekiz":
               siyah_7x = -1.606f;
               siyah_7y = -4.3f;
               siyah_7.SetActive(true);
                break;
            case "geri al siyah dokuz":
               siyah_8x = -0.693f;
               siyah_8y = -4.3f;
               siyah_8.SetActive(true);
                break;            
        }
        //Pullarımızı haraket ettirelim.
        beyaz_0.transform.position = new Vector3(beyaz_0x, beyaz_0y, 0);
        beyaz_1.transform.position = new Vector3(beyaz_1x, beyaz_1y, 0);
        beyaz_2.transform.position = new Vector3(beyaz_2x, beyaz_2y, 0);
        beyaz_3.transform.position = new Vector3(beyaz_3x, beyaz_3y, 0);
        beyaz_4.transform.position = new Vector3(beyaz_4x, beyaz_4y, 0);
        beyaz_5.transform.position = new Vector3(beyaz_5x, beyaz_5y, 0);
        beyaz_6.transform.position = new Vector3(beyaz_6x, beyaz_6y, 0);
        beyaz_7.transform.position = new Vector3(beyaz_7x, beyaz_7y, 0);
        beyaz_8.transform.position = new Vector3(beyaz_8x, beyaz_8y, 0);

        siyah_0.transform.position = new Vector3(siyah_0x, siyah_0y, 0);
        siyah_1.transform.position = new Vector3(siyah_1x, siyah_1y, 0);
        siyah_2.transform.position = new Vector3(siyah_2x, siyah_2y, 0);
        siyah_3.transform.position = new Vector3(siyah_3x, siyah_3y, 0);
        siyah_4.transform.position = new Vector3(siyah_4x, siyah_4y, 0);
        siyah_5.transform.position = new Vector3(siyah_5x, siyah_5y, 0);
        siyah_6.transform.position = new Vector3(siyah_6x, siyah_6y, 0);
        siyah_7.transform.position = new Vector3(siyah_7x, siyah_7y, 0);
        siyah_8.transform.position = new Vector3(siyah_8x, siyah_8y, 0);

    }
    //Eğer kişi uygulamayı kapattıysa tanıyıcıyı durduralım.
    private void OnApplicationQuit()
    {
        //Eğer tanıyıcı nul değilse ve çalışıyorsa
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }

    
}