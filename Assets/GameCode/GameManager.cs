using UnityEngine;
using System.Collections;

public class GameManager
{
	//------------------------------------------------------------------------
	// Singleton模版
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)			
				_instance = new GameManager();
			return _instance;
		}
	}

	// 場景狀態控制
	private bool m_bGameOver = false;
	
	// 遊戲系統
	private AchievementSystem m_AchievementSystem = null;// 成就系統
	// 界面
    private PlayerInfoUI playerInfoUI = null;
		
	private GameManager()
	{}

	// 初始P-BaseDefense遊戲相關設定
	public void Initinal()
	{
		// 場景狀態控制
		m_bGameOver = false;
		// 遊戲系統
		//m_GameEventSystem = new GameEventSystem(this);	// 遊戲事件系統
		//m_CampSystem = new CampSystem(this);			// 兵營系統
		//m_StageSystem = new StageSystem(this);			// 關卡系統
		//m_CharacterSystem = new CharacterSystem(this); 	// 角色管理系統
		//m_ApSystem = new APSystem(this);				// 行動力系統
		m_AchievementSystem = new AchievementSystem(this); // 成就系統
		// 界面
		
        playerInfoUI = new PlayerInfoUI(this);

		// 注入到其它系統
		//EnemyAI.SetStageSystem( m_StageSystem );

		// 載入存檔
		//LoadData();

		// 註冊遊戲事件系統
		ResigerGameEvent();
	}

	// 註冊遊戲事件系統
	private void ResigerGameEvent()
	{
		// 事件註冊
		

	}

	// 釋放遊戲系統
	public void Release()
	{
		// 遊戲系統
		
		m_AchievementSystem.Release();
		// 界面
		
		UITool.ReleaseCanvas();

		// 存檔
		SaveData();
	}

	// 更新
	public void Update()
	{
		// 玩家輸入
		InputProcess();

		// 遊戲系統更新
		
		m_AchievementSystem.Update();

		// 玩家界面更新
		
        playerInfoUI.Update();
	}

	// 玩家輸入
	private void InputProcess()
	{
		//这里用来控制回车，菜单栏之类的控制吧
	}
	
	// 遊戲狀態
	public bool ThisGameIsOver()
	{
		return m_bGameOver;
	}

	// 換回主選單
	public void ChangeToMainMenu()
	{
		m_bGameOver = true;
	}

	

	

	// 顯示關卡
	public void ShowNowStageLv( int Lv)
	{
		//m_GameStateInfoUI.ShowNowStageLv(Lv);
	}

	//  遊戲訊息
	public void ShowGameMsg( string Msg)
	{
		//m_GameStateInfoUI.ShowMsg( Msg );
	}

	// 顯示Heart
	public void ShowHeart(int Value)
	{
		//m_GameStateInfoUI.ShowHeart( Value);
		//ShowGameMsg("陣營被攻擊");
	}

	// 顯示暫停
	public void GamePause()
	{
		//if( m_GamePauseUI.IsVisible()==false)
		//	m_GamePauseUI.ShowGamePause( m_AchievementSystem.CreateSaveData() );
		//else
		//	m_GamePauseUI.Hide();
	}

	// 存檔
	private void SaveData()
	{
		AchievementSaveData SaveData = m_AchievementSystem.CreateSaveData();
		SaveData.SaveData();
	}

	// 取回存檔
	private AchievementSaveData LoadData()
	{
		AchievementSaveData OldData = new AchievementSaveData();
		OldData.LoadData();
		m_AchievementSystem.SetSaveData( OldData );
		return OldData;
	}
	
	

}
