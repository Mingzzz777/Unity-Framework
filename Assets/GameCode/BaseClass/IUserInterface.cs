﻿using UnityEngine;
using System.Collections;

// 遊戲使用者界面
public abstract class IUserInterface
{
	protected GameManager  m_PBDGame = null;
	protected GameObject	 	m_RootUI = null;
	private bool 				m_bActive = true;
	public IUserInterface( GameManager PBDGame )
	{
		m_PBDGame = PBDGame;
	}

	public bool IsVisible()
	{
		return m_bActive;
	}

	public virtual void Show()
	{
		m_RootUI.SetActive(true);
		m_bActive = true;
	}

	public virtual void Hide()
	{
		m_RootUI.SetActive(false);
		m_bActive = false;
	}

	public virtual void Initialize(){}
	public virtual void Release(){}
	public virtual void Update(){}

}
