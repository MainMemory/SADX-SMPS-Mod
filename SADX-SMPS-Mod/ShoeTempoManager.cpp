#include "stdafx.h"
#include "ShoeTempoManager.h"

extern BOOL(*SetSongTempo)(unsigned int pct);

ShoeTempoManager::ShoeTempoManager(ObjectMaster *obj) : GameObject(obj)
{
	count = 0;
}

void ShoeTempoManager::Main()
{
	if (count++ <= SHOETIME)
		SetSongTempo(SHOETEMPO);
	else
	{
		Delete();
		delete this;
	}
}

void ShoeTempoManager::Delete()
{
	SetSongTempo(100);
}

void ShoeTempoManager::Load(ObjectMaster *obj)
{
	ShoeTempoManager *o = new ShoeTempoManager(obj);
	o->Main();
}

void LoadShoeTempoManager()
{
	LoadObject((LoadObj)0, 0, ShoeTempoManager::Load);
}
