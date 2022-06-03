using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown; // ����ٿ� ���� ����
    public Toggle fullscreenBtn;
    List<Resolution> resolutions = new List<Resolution>(); // �����ϴ� �ػ󵵸� �ֱ����� ����Ʈ �����
    int resolutionNum;

    void Start()
    {
        videoUI();
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void videoUI()
    {
        for(int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
                resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.options.Clear(); // ����ٿ�ȿ� �ִ� ��ϻ���

        int optionNum = 0;

        foreach(Resolution item in resolutions) // �ػ󵵸� ������ ������ŭ �ݺ��ϰ� ����ٿ�ȿ� ���� �ػ� �ؽ�Ʈ���� �ֱ�
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz"; //����ٿ� �ؽ�Ʈ�� �ִ°�
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height) 
            {
                resolutionDropdown.value = optionNum;
            }
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue(); // ���ΰ�ħ

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }
    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }
    
    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width,
            resolutions[resolutionNum].height,
            screenMode);
    }
}
