using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour {

    //로컬 값 저장을 하기 위해 이름 값을 받아온다. 즉, 이름이 키 값이 된다.
    public string upgradeName;

    [HideInInspector]
    //한번 업그레이드 할 때 마다의 데미지 증가량
    public long addDamageUpgrade;
    //초기 사용자 업그레이드 비용
    public long startGoldDamageUpgrade = 1;

    [HideInInspector]
    //지금 업그레이드 가격
    public long currentCost = 1;
    //초기 시작 업그레이드 가격
    public long startCurrentCost = 1;

    [HideInInspector]
    public int clickLevel = 1;
    public float upgradePow = 1.07f;
    public float costPow = 3.14f;

    private void Start()
    {
        DataController.Instance.LoadPlayerUpgradeInfo(this);
        UpdateUI();
    }

    //사용자 클릭 업그레이드
    public void PlayerClickUpgrade()
    {
        if (DataController.Instance.Gold >= currentCost)
        {
            DataController.Instance.Gold -= currentCost;
            clickLevel++;
            //한번 업그레이드 할 때 마다의 데미지 증가량
            DataController.Instance.PlayerDamage += addDamageUpgrade;
            UpdateUpgrade();
            UpdateUI();
            DataController.Instance.SavePlayerUpgradeInfo(this);
        }
    }

    public void UpdateUpgrade()
    {
        //사용자 클릭 데미지 증가량
        addDamageUpgrade = startGoldDamageUpgrade * (long)Mathf.Pow(upgradePow, clickLevel);
        //레벨에 따른 현재 가격
        currentCost = startCurrentCost * (long)Mathf.Pow(costPow, clickLevel);
    }

    public void UpdateUI()
    {
        //레벨에 따라 업그레이드 가격
        UIManager.Instance.PlayerUiUpgrade(currentCost, 1);
        //사용자 클릭 최대 대미지
        UIManager.Instance.PlayerUiUpgrade(DataController.Instance.PlayerDamage, 2);
    }

}
