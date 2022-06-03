using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown; // 드랍다운 변수 선언
    public Toggle fullscreenBtn;
    List<Resolution> resolutions = new List<Resolution>(); // 지원하는 해상도를 넣기위한 리스트 만들기
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

        resolutionDropdown.options.Clear(); // 드랍다운안에 있는 목록삭제

        int optionNum = 0;

        foreach(Resolution item in resolutions) // 해상도를 가져온 개수만큼 반복하고 드랍다운안에 각각 해상도 텍스트값을 넣기
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz"; //드랍다운 텍스트에 넣는값
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height) 
            {
                resolutionDropdown.value = optionNum;
            }
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue(); // 새로고침

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
