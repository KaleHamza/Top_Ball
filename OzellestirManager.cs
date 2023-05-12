using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kutuphane;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using TMPro;

public class OzellestirManager : MonoBehaviour
{   
    public TextMeshProUGUI[] TextObjeler;
    public Text[] PuanTextleri;
    public Text ParaText;
    BellekYonetimi _BellekYonetimi = new BellekYonetimi();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public Button[] TopButon;
    public Button[] PlatformButon;
    public Button[] AnaPanelButonlar;
    public GameObject[] AnaPaneller;
    public GameObject[] CheckImageforBalls;
    public GameObject[] CheckImageforPlatforms;
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    //public List<ItemBilgileri> _ItemBilgileriDeneme = new List<ItemBilgileri>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    int TopIndexi = -1;

    [Header("Anahtarlar")]
    bool paraMenuAnahtar=true;
    int TopCheckindex;
    int PlatformCheckindex;
    void Start()
    {   
      
        _BellekYonetimi.KontrolEtveTanimla();
        ParaText.text = _BellekYonetimi.VeriOku_i("Puan").ToString();
        _VeriYonetim.IlkKurulumItemOlusturma(_ItemBilgileri);
        _VeriYonetim.Load();
        _ItemBilgileri = _VeriYonetim.ListeyiAktar();

        TopCheckindex = _BellekYonetimi.VeriOku_i("AktifTop");
        CheckImageforBalls[TopCheckindex].SetActive(true);
        PlatformCheckindex = _BellekYonetimi.VeriOku_i("AktifPlatform")-6;
        TopButon[1].interactable= false;
        TopButon[0].interactable= false;
        _VeriYonetim.Dil_Load();
        DilKontrol();
        
    }

    void Update()
    {
        if(paraMenuAnahtar)
        {
            ParaText.text = _BellekYonetimi.VeriOku_i("Puan").ToString();
            paraMenuAnahtar=!paraMenuAnahtar;
        }
    }
    public void Top_Butonlar(int TopIndex)
    {
    
        switch (TopIndex)
        {
            case 0:
                TopIndexi =0;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                TopButon[0].interactable =false;
                if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                TopButon[1].interactable =false;
                else
                TopButon[1].interactable =true;
                break;            
            case 1:
                TopIndexi =1;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu == true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }
                
                break;     
            case 2:
                TopIndexi =2;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }
                break;
            case 3:
                TopIndexi =3;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }   
                break;
            case 4:
                TopIndexi=4;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }     
                break;
            case 5:
                TopIndexi=5;
                PuanTextleri[0].text = _ItemBilgileri[TopIndex].Puan.ToString();
                if(_ItemBilgileri[TopIndex].SatinAlmaDurumu ==true)
                {
                    TopButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifTop")==TopIndexi)
                    TopButon[1].interactable =false;
                    else
                    TopButon[1].interactable= true;
                }
                else
                {
                    TopButon[0].interactable= true;
                    TopButon[1].interactable= false;
                }
                break;
        }
    }

    public void Platform_Butonlar(int PlatformIndex)
    {
        switch (PlatformIndex)
        {
            case 6:
                TopIndexi =6;
                PuanTextleri[1].text = _ItemBilgileri[PlatformIndex].Puan.ToString();
                PlatformButon[0].interactable =false;
                if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                PlatformButon[1].interactable =false;
                else
                PlatformButon[1].interactable =true;
                break;
            case 7:
            TopIndexi =7;
                PuanTextleri[1].text = _ItemBilgileri[PlatformIndex].Puan.ToString();
                if(_ItemBilgileri[PlatformIndex].SatinAlmaDurumu ==true)
                {
                    PlatformButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                    PlatformButon[1].interactable =false;
                    else
                    PlatformButon[1].interactable= true;
                }
                else
                {
                    PlatformButon[0].interactable= true;
                    PlatformButon[1].interactable= false;
                }      
                break;
            case 8:
            TopIndexi =8;
                PuanTextleri[1].text = _ItemBilgileri[PlatformIndex].Puan.ToString();
                if(_ItemBilgileri[PlatformIndex].SatinAlmaDurumu ==true)
                {
                    PlatformButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                    PlatformButon[1].interactable =false;
                    else
                    PlatformButon[1].interactable= true;
                }
                else
                {
                    PlatformButon[0].interactable= true;
                    PlatformButon[1].interactable= false;
                }  
                break;
            case 9:
            TopIndexi =9;
                PuanTextleri[1].text = _ItemBilgileri[PlatformIndex].Puan.ToString();
                if(_ItemBilgileri[PlatformIndex].SatinAlmaDurumu ==true)
                {
                    PlatformButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                    PlatformButon[1].interactable =false;
                    else
                    PlatformButon[1].interactable= true;
                }
                else
                {
                    PlatformButon[0].interactable= true;
                    PlatformButon[1].interactable= false;
                }
                if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                PlatformButon[1].interactable =false;
                break;
            case 10:
            TopIndexi =10;
                PuanTextleri[1].text = _ItemBilgileri[PlatformIndex].Puan.ToString();
                if(_ItemBilgileri[PlatformIndex].SatinAlmaDurumu ==true)
                {
                    PlatformButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                    PlatformButon[1].interactable =false;
                    else
                    PlatformButon[1].interactable= true;
                }
                else
                {
                    PlatformButon[0].interactable= true;
                    PlatformButon[1].interactable= false;
                }
                break;
            case 11:
            TopIndexi =11;
                PuanTextleri[1].text = _ItemBilgileri[PlatformIndex].Puan.ToString();
                if(_ItemBilgileri[PlatformIndex].SatinAlmaDurumu ==true)
                {
                    PlatformButon[0].interactable= false;
                    if(_BellekYonetimi.VeriOku_i("AktifPlatform")==TopIndexi)
                    PlatformButon[1].interactable =false;
                    else
                    PlatformButon[1].interactable= true;
                }
                else
                {
                    PlatformButon[0].interactable= true;
                    PlatformButon[1].interactable= false;
                }
                break;
        }
    }
    public void AnaPanel_Butonlar(string Gorev)
    {
        switch (Gorev)
        {
            case "Balls":
                AnaPaneller[0].SetActive(true);
                AnaPaneller[1].SetActive(false);
                AnaPanelButonlar[0].interactable = false;
                AnaPanelButonlar[1].interactable = true;
                TopButon[1].interactable= false;
                TopButon[0].interactable= false; 
                int a = 0;
                PuanTextleri[0].text = a.ToString();
                break;
            case "Platforms":
                
                CheckImageforPlatforms[PlatformCheckindex].SetActive(true);
                AnaPaneller[0].SetActive(false);
                AnaPaneller[1].SetActive(true);
                AnaPanelButonlar[0].interactable = true;
                AnaPanelButonlar[1].interactable = false;      
                PlatformButon[1].interactable= false;
                PlatformButon[0].interactable= false; 
                int b = 0;
                PuanTextleri[1].text = b.ToString();
                break;
        }
    }
    
     public void TopSatinAl()
    {
        if(_ItemBilgileri[TopIndexi].SatinAlmaDurumu == false)
        {
            if(_BellekYonetimi.VeriOku_i("Puan")>=_ItemBilgileri[TopIndexi].Puan )
            {
                _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i( "Puan") - _ItemBilgileri[TopIndexi].Puan);
                _ItemBilgileri[TopIndexi].SatinAlmaDurumu = true;
                _VeriYonetim.Save(_ItemBilgileri);
                paraMenuAnahtar=true;
                TopButon[1].interactable= true;
                TopButon[0].interactable= false;
            }
            
        }
        else
        TopButon[1].interactable = false;    
    }

    public void PlatformSatinAl()
    {
        if(_ItemBilgileri[TopIndexi].SatinAlmaDurumu ==false)
        {
            if(_BellekYonetimi.VeriOku_i("Puan")>=_ItemBilgileri[TopIndexi].Puan )
            {
                _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i( "Puan") - _ItemBilgileri[TopIndexi].Puan);
                _ItemBilgileri[TopIndexi].SatinAlmaDurumu = true;
                _VeriYonetim.Save(_ItemBilgileri);
                paraMenuAnahtar=true;
                PlatformButon[1].interactable= true;
                PlatformButon[0].interactable= false;
            }   
        } 
        else
        PlatformButon[1].interactable = false;  
    }
    
    public void TopKaydetme()
    {
        _BellekYonetimi.VeriKaydet_int("AktifTop", TopIndexi);
        TopButon[1].interactable= false;
        
        CheckImageforBalls[TopCheckindex].SetActive(false);
        TopCheckindex = _BellekYonetimi.VeriOku_i("AktifTop");
        CheckImageforBalls[TopCheckindex].SetActive(true);
        

    }
    
    public void PlatformKaydetme()
    {
        _BellekYonetimi.VeriKaydet_int("AktifPlatform", TopIndexi);
        PlatformButon[1].interactable = false;

        CheckImageforPlatforms[PlatformCheckindex].SetActive(false);
        PlatformCheckindex = _BellekYonetimi.VeriOku_i("AktifPlatform")-6;
        CheckImageforPlatforms[PlatformCheckindex].SetActive(true);

    }
   
   public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
   
   void DilKontrol()
    {
        string dil = _BellekYonetimi.VeriOku_s("Dil");
        if(dil == "TR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[2]._DilVerileri_TR[i].Metin;
            }
        }
        else if(dil == "EN")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[2]._DilVerileri_EN[i].Metin;
            }
        }
    }     
}
