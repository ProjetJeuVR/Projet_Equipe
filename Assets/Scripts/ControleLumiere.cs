using OVRSimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class ControleLumiere : MonoBehaviour
{

    public Slider sliderLumiere;
    //public PostProcessProfile lumiere;

    public GameObject lumiere;

    public FloatParameter floatChiffre;
    public FloatParameter floatstart;


    //AutoExposure exposure;

    // Start is called before the first frame update
    void Start()
    {

        lumiere.GetComponent<ColorAdjustments>().postExposure = floatChiffre;

        if (!PlayerPrefs.HasKey("choixLumiere"))
        {
            PlayerPrefs.SetFloat("choixLumiere", 0);
            Chargement();
        }
        else { Chargement(); }

    }

    public void ChangementLumiere()
    {
        //trouver comment changer le color adjustement
        //lumiere.GetComponent<PostProcessVolume>(). = sliderLumiere.value;
        lumiere.GetComponent<ColorAdjustments>().postExposure = floatChiffre;
        Sauvegarde();
    }
    private void Sauvegarde()
    {
        PlayerPrefs.SetFloat("choixLumiere", sliderLumiere.value);
    }

    private void Chargement()
    {
        sliderLumiere.value = PlayerPrefs.GetFloat("choixLumiere");
    }
}
