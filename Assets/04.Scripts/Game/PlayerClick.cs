using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour {
    //사용자의 탭 이벤트

    //사용자 데미지를 가져온다.
    long getPlayerDamageTemp = 0;
    public void OnClick()
    {
        //골드 증가량은 playerDamage/2 이상 playerDamage/1 이하
        getPlayerDamageTemp = DataController.Instance.PlayerDamage == 1 ? 1 : DataController.Instance.PlayerDamage / 2;
        DataController.Instance.Gold += (long)Random.Range(getPlayerDamageTemp, DataController.Instance.PlayerDamage + 1);

    }

}
