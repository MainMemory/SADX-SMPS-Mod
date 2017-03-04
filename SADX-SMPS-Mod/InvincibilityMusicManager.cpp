#include "stdafx.h"
#include "InvincibilityMusicManager.h"

DataPointer(int, CurrentSong, 0x912698);

InvincibilityMusicManager::InvincibilityMusicManager(ObjectMaster *obj) : GameObject(obj)
{
	count = 0;
	lastsong = CurrentSong;
	CurrentSong = 55;
}

void InvincibilityMusicManager::Main()
{
	if (count++ >= INVTIME)
	{
		CurrentSong = lastsong;
		delete this;
	}
}

void InvincibilityMusicManager::Load(ObjectMaster * obj)
{
	InvincibilityMusicManager *o = new InvincibilityMusicManager(obj);
	o->Main();
}

void LoadInvincibilityMusicManager()
{
	LoadObject((LoadObj)0, 0, InvincibilityMusicManager::Load);
}