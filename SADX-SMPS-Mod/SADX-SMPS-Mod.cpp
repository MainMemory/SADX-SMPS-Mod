// SADX-SMPS-Mod.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "..\mod-loader-common\ModLoaderCommon\IniFile.hpp"
#include "SADXModLoader.h"
#include "ShoeTempoManager.h"
using std::string;
using std::unordered_map;

BOOL(*PlaySong)(short song);
BOOL(*StopSong)();
BOOL(*PauseSong)();
BOOL(*ResumeSong)();
BOOL(*SetSongTempo)(unsigned int pct);

short MusicChoices[125];

DataPointer(void *, WMPMusicInfo, 0x3ABDF9C);
DataPointer(int, CurrentSong, 0x912698);
int PlayMusicFile_r(const char *filename, int loop)
{
	if (!WMPMusicInfo) return 0;
	if (MusicChoices[CurrentSong] != -1)
		return PlaySong(MusicChoices[CurrentSong]);
	else
		return 0;
}

void WMPRestartMusic_r() {}

int pausecnt;
void(*PauseSound_ml)();
void PauseSound_r()
{
	pausecnt++;
	PauseSong();
	PauseSound_ml();
}

void(*ResumeSound_ml)();
void ResumeSound_r()
{
	if (--pausecnt <= 0)
	{
		ResumeSong();
		ResumeSound_ml();
		pausecnt = 0;
	}
}

void(*WMPClose_ml)(int);
void WMPClose_r(int a1)
{
	if (a1)
		WMPClose_ml(a1);
	else
		StopSong();
	pausecnt = 0;
}

const string SADXMusicList[125] = {
	"advamy",
	"advbig",
	"adve102",
	"advknkls",
	"advmiles",
	"advsonic",
	"amy",
	"big",
	"bossall",
	"bosse101",
	"bossevnt",
	"bosstrgt",
	"casino1",
	"casino2",
	"casino3",
	"casino4",
	"chao",
	"chaogoal",
	"chaohall",
	"chaorace",
	"chaos",
	"chaos_6",
	"chaos_p1",
	"chaos_p2",
	"charactr",
	"circuit",
	"continue",
	"e102",
	"ecoast1",
	"ecoast2",
	"ecoast3",
	"egcarer1",
	"egcarer2",
	"eggman",
	"eggmbl23",
	"eggrobo",
	"evtbgm00",
	"evtbgm01",
	"evtbgm02",
	"evtbgm03",
	"evtbgm04",
	"evtbgm05",
	"finaleg1",
	"finaleg2",
	"fishget",
	"fishing",
	"fishmiss",
	"hammer",
	"highway1",
	"highway2",
	"highway3",
	"hurryup",
	"icecap1",
	"icecap2",
	"icecap3",
	"invncibl",
	"item1",
	"jingle_1",
	"jingle_2",
	"jingle_3",
	"jingle_4",
	"jingle_5",
	"KNUCKLES",
	"lstwrld1",
	"lstwrld2",
	"lstwrld3",
	"mainthem",
	"mstcln",
	"nights_a",
	"nights_k",
	"nights_s",
	"one_up",
	"option",
	"redmntn1",
	"redmntn2",
	"rndclear",
	"s_square",
	"sandhill",
	"scramble",
	"shelter1",
	"shelter2",
	"skydeck1",
	"skydeck2",
	"sonic",
	"sonic_cd",
	"speedup",
	"sprsonic",
	"ssracing",
	"tails",
	"theamy",
	"thebig",
	"thee102",
	"theknkls",
	"themiles",
	"thesonic",
	"tical",
	"timer",
	"titl_egg",
	"titl_mr1",
	"titl_mr2",
	"titl_ss",
	"title",
	"title2",
	"trial",
	"twnklpk1",
	"twnklpk2",
	"twnklpk3",
	"wndyvly1",
	"wndyvly2",
	"wndyvly3",
	"MSTART_44",
	"MCLEAR_44",
	"chao_k_net_fine",
	"chao_g_iede",
	"chao_r_e",
	"c_btl_cv",
	"chao_r_gate_open",
	"chao_g_born_h2",
	"chao_g_born_d2",
	"chao_g_born_c",
	"chao_g_born_h",
	"chao_g_born_d",
	"chao_g_dead",
	"chao_g_dance",
	"chao_k_m"
};

const string SMPSMusicList[] = {
	"S3Title",
	"AngelIsland1",
	"AngelIsland2",
	"Hydrocity1",
	"Hydrocity2",
	"MarbleGarden1",
	"MarbleGarden2",
	"CarnivalNight1",
	"CarnivalNight2",
	"FlyingBattery1",
	"FlyingBattery2",
	"IceCap1",
	"IceCap2",
	"LaunchBase1",
	"LaunchBase2",
	"MushroomHill1",
	"MushroomHill2",
	"Sandopolis1",
	"Sandopolis2",
	"LavaReef1",
	"LavaReef2",
	"SkySanctuary",
	"DeathEgg1",
	"DeathEgg2",
	"SKMidboss",
	"Boss",
	"Doomsday",
	"MagneticOrbs",
	"SpecialStage",
	"SlotMachine",
	"GumballMachine",
	"S3Knuckles",
	"AzureLake",
	"BalloonPark",
	"DesertPalace",
	"ChromeGadget",
	"EndlessMine",
	"GameOver",
	"Continue",
	"ActClear",
	"S31Up",
	"ChaosEmerald",
	"S3Invincibility",
	"CompetitionMenu",
	"S3Midboss",
	"LevelSelect",
	"FinalBoss",
	"Drowning",
	"S3AllClear",
	"S3Credits",
	"SKKnuckles",
	"SKTitle",
	"SK1Up",
	"SKInvincibility",
	"SKAllClear",
	"SKCredits",
	"S3CCredits",
	"S3Continue",
	"SKTitle0525",
	"SKAllClear0525",
	"SKCredits0525",
	"GreenGrove1",
	"GreenGrove2",
	"RustyRuin1",
	"RustyRuin2",
	"VolcanoValley2",
	"VolcanoValley1",
	"SpringStadium1",
	"SpringStadium2",
	"DiamondDust1",
	"DiamondDust2",
	"GeneGadget1",
	"GeneGadget2",
	"PanicPuppet2",
	"FinalFight",
	"S3DEnding",
	"S3DSpecialStage",
	"PanicPuppet1",
	"S3DBoss2",
	"S3DBoss1",
	"S3DIntro",
	"S3DCredits",
	"S3DInvincibility",
	"S3DMenu",
	"S4E1Boss",
	"GreenHill",
	"Labyrinth",
	"Marble",
	"StarLight",
	"SpringYard",
	"ScrapBrain",
	"S1Invincibility",
	"S11Up",
	"S1SpecialStage",
	"S1Title",
	"S1Ending",
	"S1Boss",
	"FinalZone",
	"S1ActClear",
	"S1GameOver",
	"S1Continue",
	"S1Credits",
	"S1Drowning",
	"S1ChaosEmerald",
	"CasinoNight2P",
	"EmeraldHill",
	"Metropolis",
	"CasinoNight",
	"MysticCave",
	"MysticCave2P",
	"AquaticRuin",
	"S2DeathEgg",
	"S2SpecialStage",
	"S2Options",
	"S2Ending",
	"S2FinalBoss",
	"ChemicalPlant",
	"S2Boss",
	"SkyChase",
	"OilOcean",
	"WingFortress",
	"EmeraldHill2P",
	"S22PResults",
	"S2SuperSonic",
	"HillTop",
	"S2Title",
	"S2Invincibility",
	"S2HiddenPalace",
	"S2Credits",
	"CasinoNight2PBeta",
	"EmeraldHillBeta",
	"MetropolisBeta",
	"CasinoNightBeta",
	"MysticCaveBeta",
	"MysticCave2PBeta",
	"AquaticRuinBeta",
	"S2DeathEggBeta",
	"S2SpecialStageBeta",
	"S2OptionsBeta",
	"S2FinalBossBeta",
	"ChemicalPlantBeta",
	"S2BossBeta",
	"SkyChaseBeta",
	"OilOceanBeta",
	"WingFortressBeta",
	"EmeraldHill2PBeta",
	"S22PResultsBeta",
	"S2SuperSonicBeta",
	"HillTopBeta",
	"S3DSpecialStageBeta",
	"CarnivalNight1PC",
	"CarnivalNight2PC",
	"IceCap1PC",
	"IceCap2PC",
	"LaunchBase1PC",
	"LaunchBase2PC",
	"KnucklesPC",
	"CompetitionMenuPC",
	"UnusedPC",
	"CreditsPC",
	"S3InvincibilityPC"
};

unordered_map<string, short> songmap;

inline void *GetJumpAddress(void *address)
{
	return (void*)(*(int32_t*)((int8_t*)address + 1) + (uint32_t)address + 5);
}

extern "C"
{
	__declspec(dllexport) void Init(const char *path, const HelperFunctions &helperFunctions)
	{
		char pathbuf[MAX_PATH];
		strcpy_s(pathbuf, path);
		strcat_s(pathbuf, "\\SMPSOUT.dll");
		HMODULE handle = LoadLibraryA(pathbuf);
		if (!handle)
		{
			PrintDebug("SADX-SMPS-Mod: Could not load SMPSOUT.dll!\n");
			return;
		}
		((BOOL(*)())GetProcAddress(handle, "InitializeDriver"))();
		((void(*)(double))GetProcAddress(handle, "SetVolume"))(0.5);
		PlaySong = (decltype(PlaySong))GetProcAddress(handle, "PlaySong");
		StopSong = (decltype(StopSong))GetProcAddress(handle, "StopSong");
		PauseSong = (decltype(PauseSong))GetProcAddress(handle, "PauseSong");
		ResumeSong = (decltype(ResumeSong))GetProcAddress(handle, "ResumeSong");
		SetSongTempo = (decltype(SetSongTempo))GetProcAddress(handle, "SetSongTempo");
		for (size_t i = 0; i < LengthOfArray(SMPSMusicList); i++)
			songmap[SMPSMusicList[i]] = (short)i;
		strcpy_s(pathbuf, path);
		strcat_s(pathbuf, "\\config.ini");
		const IniFile *cfg = new IniFile(pathbuf);
		const IniGroup *grp = cfg->getGroup("");
		for (size_t i = 0; i < LengthOfArray(SADXMusicList); i++)
			if (grp->hasKeyNonEmpty(SADXMusicList[i]))
				MusicChoices[i] = songmap[grp->getString(SADXMusicList[i])];
			else
				MusicChoices[i] = -1;
		delete cfg;
		WriteCall((void*)0x42544C, PlayMusicFile_r);
		WriteJump((void *)0x40CF50, WMPRestartMusic_r);
		PauseSound_ml = (decltype(PauseSound_ml))GetJumpAddress((void *)0x40D060);
		WriteJump((void *)0x40D060, PauseSound_r);
		ResumeSound_ml = (decltype(ResumeSound_ml))GetJumpAddress((void *)0x40D0A0);
		WriteJump((void *)0x40D0A0, ResumeSound_r);
		WMPClose_ml = (decltype(WMPClose_ml))GetJumpAddress((void *)0x40CFF0);
		WriteJump((void *)0x40CFF0, WMPClose_r);
		WriteCall((void*)0x441DD8, LoadShoeTempoManager);
	}

	__declspec(dllexport) ModInfo SADXModInfo = { ModLoaderVer };
}