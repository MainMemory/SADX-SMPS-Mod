#pragma once
#include "..\sadx-mod-loader\libmodutils\GameObject.h"

class InvincibilityMusicManager : GameObject
{
#define INVTIME 1260
private:
	InvincibilityMusicManager(ObjectMaster *obj);
	int count;
	short lastsong;
public:
	void Main();
	static void Load(ObjectMaster *obj);
};

void LoadInvincibilityMusicManager();