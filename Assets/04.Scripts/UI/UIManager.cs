using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    //싱글톤
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("UIManager");
                    instance = container.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    //골드 표시할 넘버 랜더러
    [SerializeField]
    //[0] = 현재 골드 소지량, [1] = 사용자 클릭 업그레이드 비용
    private NumbersRenderer[] _numberDisplayer = null;

    //5자리수 이상일 때 앞의 4자리숫자만 잘라 보내기 위함
    private string devideTemp;

    //천 단위에서 부터 알파뱃 사용하여 999a, 1000a = 1b, 1000b, = 1c
    [SerializeField]
    private AlphabetRenderer alphabetRenderer;
    private int alphabetDevideTemp;

    [SerializeField]
    //개발용: 값이 보이게 하기위한 디스플레이
    private Text[] tempText;

    private void Update()
    {

        //현재 가지고 있는 골드 표시
        NumberRenderFunction(DataController.Instance.Gold, 0);
        
    }

    //************************************************** 현재 가지고 있는 숫자(골드, 공격력 등) 표시 *******************************************
    private void NumberRenderFunction(long goldTemp, int setDisplayer)
    {
        
        //개발용: 값이 보이게 하기위한 디스플레이
        tempText[setDisplayer].text = goldTemp.ToString();

        //a 숫자(골드, 공격력 등) 단위를 넘어가면 연산.
        if (goldTemp >= 1000)
        {
            //바이트 수를 구해서 알파뱃 단위를 결정한다.
            alphabetDevideTemp = Encoding.Default.GetByteCount(goldTemp.ToString());
            //long 형의 숫자(골드, 공격력 등)를 string으로 형변환
            devideTemp = goldTemp.ToString();
            if (alphabetDevideTemp % 3 == 0)
            {
                alphabetRenderer.Value = (alphabetDevideTemp / 3) - 1;
                devideTemp = devideTemp.Substring(0, 4);
            }
            else
            {
                alphabetRenderer.Value = (alphabetDevideTemp / 3);
                devideTemp = devideTemp.Substring(0, (alphabetDevideTemp % 3) + 1);
            }
            //골드를 보여준다.
            _numberDisplayer[setDisplayer].Value = int.Parse(devideTemp);

        }
        else
        {
            alphabetRenderer.Value = 0;
            _numberDisplayer[setDisplayer].Value = (int)goldTemp * 10;
        }
    }
    //************************************************** 현재 가지고 있는 숫자(골드, 공격력 등) 표시 [ 마침 ] *******************************************

    /// <summary>
    /// 플레이어 업그레이드에서 사용
    /// </summary>

    //************************************************** 사용자 공격력 증가 구매 비용 *******************************************
    public void PlayerUiUpgrade(long _value, int setDisplayer)
    {
        //사용자 클릭 레벨에 따라 업그레이드 가격
        NumberRenderFunction(_value, setDisplayer);
    }
    //************************************************** 사용자 공격력 증가 구매 비용 [마침] *******************************************



}
