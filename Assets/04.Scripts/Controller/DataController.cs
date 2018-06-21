using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
    //데이터 관리

    //싱글톤
    private static DataController instance;
    public static DataController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataController>();
                if (instance == null)
                {
                    GameObject container = new GameObject("DataController");
                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }
    }

    //템프 변수 사용시 초기화 필수
    string temp;

    //골드
    public long Gold
    {
        get
        {
            if (!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }
            temp = PlayerPrefs.GetString("Gold");
            return long.Parse(temp);
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    //사용자 탭 이벤트 공격력
    public long PlayerDamage
    {
        get
        {
            if (!PlayerPrefs.HasKey("PlayerDamage"))
            {
                return 1;
            }
            string tmpGold = PlayerPrefs.GetString("PlayerDamage", "1");
            return long.Parse(tmpGold);
        }
        set
        {
            PlayerPrefs.SetString("PlayerDamage", value.ToString());
        }
    }


    //업그레이드 파트, 저장된 업그레이드 정보 가져오기
    public void LoadPlayerUpgradeInfo(PlayerUpgrade playerUpgrade)
    {
        //저장된 값을 가져오기 위해 key값을 받아온다.
        string key = playerUpgrade.upgradeName;
        //사용자 탭 레벨 저장
        playerUpgrade.clickLevel = PlayerPrefs.GetInt(key + "_clickLevel", 1);
        //사용자 탭 최대 공격력 증가량
        playerUpgrade.addDamageUpgrade = long.Parse(PlayerPrefs.GetString(key + "_addDamageUpgrade", playerUpgrade.startGoldDamageUpgrade.ToString()));
        //사용자 탭 최대 공격력 업그레이드 비용 저장
        playerUpgrade.currentCost = long.Parse(PlayerPrefs.GetString(key + "_cost", playerUpgrade.startCurrentCost.ToString()));
    }

    //업그레이드 파트, 정보 저장하기
    public void SavePlayerUpgradeInfo(PlayerUpgrade playerUpgrade)
    {
        string key = playerUpgrade.upgradeName;
        PlayerPrefs.SetInt(key + "_clickLevel", playerUpgrade.clickLevel);
        PlayerPrefs.SetString(key + "_addDamageUpgrade", playerUpgrade.addDamageUpgrade.ToString());
        PlayerPrefs.SetString(key + "_cost", playerUpgrade.currentCost.ToString());
    }




}
