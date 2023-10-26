using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;


public class SettingsMenu : MonoBehaviour
{
    public Toggle vsyncTog;

    public VolumeProfile volumeProfile ;
    UnityEngine.Rendering.Universal.ColorAdjustments Brightness;

    public List<ResItem> resolutionsx = new List<ResItem>();
    private int selectedResolution;
    [SerializeField] private TMP_Text resolutionLabel;

    public List<QualityItem> quality = new List<QualityItem>();
    private int selectedQuality = 1;
    [SerializeField] private TMP_Text QualityLabel;

    private void Start()
    {
        //UpdateQualityLabel();
        bool foundRes = false;

        for(int i = 0; i< resolutionsx.Count; i++)
        {
            if(Screen.width == resolutionsx[i].horizontal && Screen.height == resolutionsx[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLabel();
            }
        }
        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutionsx.Add(newRes);
            selectedResolution = resolutionsx.Count - 1;

            UpdateResLabel();
        }


        //VSYNC
        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        //brightness
        if (!volumeProfile.TryGet(out Brightness)) throw new System.NullReferenceException(nameof(Brightness));
    }

    //Resolution label and button
    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutionsx.Count - 1)
        {
            selectedResolution = resolutionsx.Count - 1;
        }
        UpdateResLabel();
    }
    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutionsx[selectedResolution].horizontal.ToString() + " x " + resolutionsx[selectedResolution].vertical.ToString();

    }

    //Quality label and buttons
    public void QualityLeft()
    {
        selectedQuality--;
        if (selectedQuality < 0)
        {
            selectedQuality = 0;
        }
        UpdateQualityLabel();
    }

    public void QualityRight()
    {
        selectedQuality++;
        if (selectedQuality > quality.Count - 1)
        {
            selectedQuality = quality.Count - 1;
        }
        UpdateQualityLabel();
    }
    public void UpdateQualityLabel()
    {
        QualityLabel.text = quality[selectedQuality].quality.ToString();

    }

    public void SetResolution()
    {
        
        Screen.SetResolution(resolutionsx[selectedResolution].horizontal, resolutionsx[selectedResolution].vertical, Screen.fullScreen); ;
    }


    public void Vsync()
    {
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void SetQuality ()
    {
        QualitySettings.SetQualityLevel(selectedQuality);
      
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetBrightness(float brightnessValue)
    {
        Brightness.postExposure.value = brightnessValue;
    }

    public void ApllyChanges()
    {
        Vsync();
        //SetFullscreen();
        SetQuality();
        SetResolution();
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}

[System.Serializable]
public class QualityItem
{
    public string quality;
}