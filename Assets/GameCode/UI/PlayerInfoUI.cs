using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI:IUserInterface
{
    private Text moneyText;
    private Button addMoneyBtn;
    float money = 0;

    public PlayerInfoUI(GameManager PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        m_RootUI = UITool.FindUIGameObject("PlayerInfoUI");
        moneyText = UITool.GetUIComponent<Text>("MoneyText");
        addMoneyBtn = UITool.GetUIComponent<Button>(m_RootUI,"AddMoneyBtn");
        addMoneyBtn.onClick.AddListener(()=> 
        {
            
            moneyText.text = "金币:" + money;
            money += 5;
        }
        );
       
    }

    public void AddMoneyByClick(int moneyNum)
    {
        EventCenter.Broadcast(EnumEventType.AddMoney, moneyNum);
    }


}
