#pragma once
#include "..\sadx-mod-loader\libmodutils\GameObject.h"

class ShoeTempoManager : GameObject
{
#define SHOETEMPO 66
#define SHOETIME 600
private:
	ShoeTempoManager(ObjectMaster *obj);
	int count;
public:
	void Main();
	void Delete();
	static void __cdecl Load(ObjectMaster *obj);
};

void LoadShoeTempoManager();