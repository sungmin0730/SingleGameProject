using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
 
    public static Dictionary<string, TalkData[]> talkDictionary = new Dictionary<string, TalkData[]>(); // 모든 이벤트 (대화)가 저장될 곳
    public PlayerMove player;

    public TextAsset csvFile = null;

    public GameObject dialogObject;
    public GameObject textObject;

    public Transform hell;
    public Transform bb;
    public Transform npc;
    public Transform nowSpeaker;

    public bool isTalking;

    int lines; //다이어로그 위치를 위해 전역변수..

    private void Awake()
    {
        SetTalkDictionary();
        startDialogue("여정의 시작");
    }

    private void Update()
    {
        if (dialogObject.activeSelf)
        {
            Vector3 dialogPos = new Vector3(nowSpeaker.position.x - 1f, nowSpeaker.position.y + 1.5f + (((lines - 1) * 0.3f) / 2f)); // 말하는 사람한테 말풍선 주기
            dialogObject.transform.position = dialogPos;
            textObject.transform.position = dialogPos;
        }
    }

    public static TalkData[] GetDialogue(string eventName)
    {
        TalkData[] talkData;
        try
        {
            Debug.Log(eventName);
            talkData = talkDictionary[eventName]; // 대사 있을 경우에만 반환
            return talkData;
        }
        catch (System.Exception n)
        {
            //Debug.Log(n);
            return null; // 없으면 null 반환
        }
    }

    public void SetTalkDictionary()
    {
        string csvText = csvFile.text.Substring(0, csvFile.text.Length - 1);// csv 파일이라 아래 한 줄 추가됌, 빼기
        string[] rows = csvText.Split('\n'); // 줄바꿈 구분으로 행수 구하기

        for (int i = 1; i < rows.Length; i++) // 첫행 넘기고 시작
        {
            string[] rowValues = rows[i].Split(','); // csv 파일이니까 쉼표로 구분
            string eventName = rowValues[0]; // 이벤트이름

            if (!(eventName == "" || eventName == "end")) // 이벤트 이름일때만 대화 저장
            {
                List<TalkData> talkDataList = new List<TalkData>();

                while (rowValues[0] != "end")
                {
                    TalkData talkData; // name과 contexts를 넣어줘야함.

                    talkData.name = rowValues[1]; // name 넣기

                    List<string> contextList = new List<string>(); // context넣기, 대사 여러개일 수 있으니까 배열
                    do
                    {
                        contextList.Add(rowValues[2]);
                        if (++i < rows.Length)
                            rowValues = rows[i].Split(',');
                    } while (rowValues[0] != "end" && rowValues[1] == ""); // 대사 더 있는지 확인하는 조건
                    talkData.contexts = contextList.ToArray();

                    talkDataList.Add(talkData); //리스트에 talkData 넣기
                }
                talkDictionary.Add(eventName, talkDataList.ToArray());
            } 
        }
    }

    void setSpeaker(string name)
    {
        if (name == "헬리아공주")
        {
            nowSpeaker = hell;
        }
        else if (name == "비비")
        {
            nowSpeaker = bb;
        }
        else
        {
            nowSpeaker = npc;
        }
    }

    public void startDialogue(string eventName) // 대화 시작하는 함수
    {
        TalkData[] talkDatas = GetDialogue(eventName);
        if (talkDatas == null)
        {
            return;
        }

        StartCoroutine("talk", talkDatas);
    }

    IEnumerator talk(TalkData[] talkDatas)
    {
        isTalking = true;
        dialogObject.SetActive(true);
        textObject.SetActive(true);

        for (int i = 0; i < talkDatas.Length; i++)
        {

            setSpeaker(talkDatas[i].name); // 말하는 사람 설정
            
            foreach (string context in talkDatas[i].contexts)
            {

                string str = context; // context 29글자마다 아랫줄로 내려야 하는데 context에 직접 할당 안돼서 str로 치환하여 사용
                
                lines = 1 + (str.Length / 30); // 대사 몇줄인지
                
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ텍스트 줄바꿔서 말풍선에 넣기ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                for (int j = 1; j < lines; j++)
                {
                    str = str.Insert((29 + (j - 1)) * j, "\n");
                }
                textObject.GetComponent<TextMesh>().text = str;
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ다이어로그 사이즈 정하기ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                float dialogXScale = 1f + (8f * (str.Length / 29f));
                float dialogYScale = 1f + ((lines - 1) * 0.3f);
                Vector3 dialogScale = new Vector3(dialogXScale, dialogYScale);
                dialogObject.transform.localScale = dialogScale;
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

                yield return new WaitForSeconds(1f + (context.Trim().Length * 0.1f)); // 기본1초 + 공백제거한 글자마다 0.1초씩 말풍선 보여주고 넘기기
            }
        }

        isTalking = false;
        dialogObject.SetActive(false);
        textObject.SetActive(false);

    }

}
