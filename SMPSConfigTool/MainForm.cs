using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace SMPSConfigTool
{
	public partial class MainForm : Form
	{
		static MainForm Instance;

		public MainForm()
		{
			InitializeComponent();
			Instance = this;
		}

		Dictionary<string, string> INI;

		static readonly string[] SADXMusicFiles = {
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

		static readonly string[] SADXMusicTitles =
		{
			"Instruction: Amy",
"Instruction: Big",
"Instruction: E-102",
"Instruction: Knuckles",
"Instruction: Tails",
"Instruction: Sonic",
"My Sweet Passion",
"Lazy Days~Livin' In Paradise",
"Egg Mobile ...Boss: Egg Hornet",
"Crazy Robo ...Boss: E-101R",
"Fight for My Own Way ...Boss: Event",
"Heartless Colleague ...Boss: E-Series Targets",
"The Dreamy Stage ...for Casinopolis",
"Dilapidated Way ...for Casinopolis",
"Blue Star ...for Casinopolis",
"Message from Nightopia",
"Theme of \"CHAO\"",
"Chao Race Goal",
"Letz Get This Party Started ...for CHAO Race Entrance",
"Join Us 4 Happy Time ...for CHAO Race",
"Boss: CHAOS ver.0, 2, 4",
"Boss: CHAOS ver.6",
"Boss: Perfect CHAOS",
"Perfect CHAOS Revival! ...Boss: Perfect CHAOS",
"Choose Your Buddy!",
"Twinkle Circuit",
"Will You Continue?",
"Theme of \"E-102g\"",
"Azure Blue World ...for Emerald Coast",
"Windy and Ripply ...for Emerald Coast",
"BIG Fishes at Emerald Coast...",
"Egg Carrier - A Song That Keeps Us On The Move",
"Calm After the Storm ...Egg Carrier -the ocean-",
"Theme of \"Dr.EGGMAN\"",
"Militant Missionary ...Boss: Egg Walker & Egg Viper",
"ZERO The Chase-master ...Boss: Eggman Robot -ZERO-",
"Event: Sadness",
"Event: Strain",
"Event: Unbound",
"Event: Good-bye!",
"Event: The Past",
"Event: Fanfare for \"Dr.EGGMAN\"",
"Mechanical Resonance ...for Final Egg",
"Crank the Heat Up!! ...for Final Egg",
"Fish Get!",
"and... Fish Hits!",
"Fish Miss!",
"Sweet Punch ...for Hedgehog Hammer",
"Run Through the Speed Highway ...for Speed Highway",
"Goin' Down!? ...for Speed Highway",
"At Dawn ...for Speed Highway",
"Danger is Imminent",
"Snowy Mountain ...for Icecap",
"Limestone Cave ...for Icecap",
"Be Cool, Be Wild and Be Groovy ...for Icecap",
"Invincible ...No Fear!",
"Item",
"Jingle A",
"Jingle B",
"Jingle C",
"Jingle D",
"Jingle E",
"Unknown from M.E.",
"Tricky Maze ...for Lost World",
"Danger! Chased by Rock ...for Lost World",
"Leading Lights ...for Lost World",
"Open your Heart -Main Theme of \"SONIC Adventure\"-",
"Mystic Ruin",
"Dream Dreams: A-Capella Ver.",
"nights_k",
"Dream Dreams: Sweet Mix in Holy Night",
"Extend",
"Funky Groove Makes U Hot!? ...for Options",
"Mt. Red: a Symbol of Thrill ...for Red Mountain",
"Red Hot Skull ...for Red Mountain",
"Round Clear",
"Welcome to Station Square!",
"Sand Hill",
"Tornado Scramble ...for Sky Chase",
"Bad Taste Aquarium ...for Hot Shelter",
"Red Barrage Area ...for Hot Shelter",
"Skydeck A Go! Go! ...for Sky Deck",
"General Offensive ...for Sky Deck",
"It Doesn't Matter",
"Palmtree Panic Zone JP",
"Hey You! It's Time to Speed Up!!! (Unused)",
"Theme of \"SUPER SONIC\"",
"Super Sonic Racing",
"Believe in Myself",
"Appearance: AMY",
"Appearance: BIG",
"Appearance: E-102",
"Appearance: KNUCKLES",
"Appearance: MILES",
"Appearance: SONIC",
"Theme of \"TIKAL\"",
"Drowning",
"Egg Carrier Transform",
"titl_mr1 (Unused)",
"titl_mr2 (Unused)",
"Trial Version Quit",
"Main Menu",
"Title Screen",
"Trial",
"Twinkle Cart ...for Twinkle Park",
"Pleasure Castle ...for Twinkle Park",
"Fakery Way ...for Twinkle Park",
"Windy Hill ...for Windy Valley",
"Tornado ...for Windy Valley",
"The Air ...for Windy Valley",
"Mission Start!",
"Mission Clear!",
"Chao: Level Up!",
"Chao: Goodbye!",
"Chao: Naming",
"Chao Race Entry",
"Chao Race Gate Open",
"Hero Chaos Chao Born 2",
"Dark Chaos Chao Born 2",
"Chaos Chao Born",
"Hero Chaos Chao Born",
"Dark Chaos Chao Born",
"Chao Died",
"Chao Dance",
"Chao: Black Market",
		};

		static readonly string[] SMPSMusicList = {
			"",
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

		static readonly List<Button> buttons = new List<Button>();

		#region Native Methods
		[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern bool InitializeDriver();
		[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern void SetVolume(double vol);
		[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern bool PlaySong(short song);
		[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern bool StopSong();
		[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern void RegisterSongStoppedCallback(Action callback);
		#endregion

		static Action SongStoppedCallback = SongStopped;

		int playingSongSelection = -1;
		Button playingButton = null;
		Random songPicker = new Random();

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (File.Exists("config.ini"))
				INI = IniFile.Load("config.ini")[string.Empty];
			else
				INI = new Dictionary<string, string>();
			InitializeDriver();
			SetVolume(0.5);
			RegisterSongStoppedCallback(SongStoppedCallback);
			tableLayoutPanel1.SuspendLayout();
			for (int tn = 0; tn < SADXMusicFiles.Length; tn++)
			{
				string file = SADXMusicFiles[tn];
				tableLayoutPanel1.Controls.Add(new Label() { Text = tn.ToString(), AutoSize = true, TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.None }, 0, tn + 1);
				tableLayoutPanel1.Controls.Add(new Label() { Text = file, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Anchor = AnchorStyles.None }, 1, tn + 1);
				tableLayoutPanel1.Controls.Add(new Label() { Text = SADXMusicTitles[tn], AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Anchor = AnchorStyles.None }, 2, tn + 1);
				ComboBox cb = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
				cb.Items.AddRange(SMPSMusicList);
				tableLayoutPanel1.Controls.Add(cb, 3, tn + 1);
				Button btn = new Button() { Enabled = false, Text = "Play" };
				tableLayoutPanel1.Controls.Add(btn, 4, tn + 1);
				buttons.Add(btn);
				if (!INI.ContainsKey(file))
				{
					INI.Add(file, "");
					cb.SelectedIndex = 0;
				}
				else
					for (int i = 0; i < SMPSMusicList.Length; i++)
						if ((INI[file] ?? "").Equals(SMPSMusicList[i], StringComparison.OrdinalIgnoreCase))
						{
							cb.SelectedIndex = i;
							if (i > 0)
								btn.Enabled = true;
							break;
						}
				if (cb.SelectedIndex == -1)
					cb.SelectedIndex = 0;
				tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				cb.SelectedIndexChanged += new EventHandler((s, ev) =>
				{
					INI[file] = SMPSMusicList[cb.SelectedIndex];
					btn.Enabled = cb.SelectedIndex > 0;
					btn.Text = playingButton == btn && playingSongSelection == cb.SelectedIndex ? "Stop" : "Play";
				});
				if (btn != null)
					btn.Click += new EventHandler((s, ev) =>
					{
						if (playingButton == btn && playingSongSelection == cb.SelectedIndex)
						{
							StopSong();
							playingButton = null;
							btn.Text = "Play";
						}
						else
						{
							PlaySong((short)(cb.SelectedIndex - 1));
							playingButton = btn;
							playingSongSelection = cb.SelectedIndex;
							foreach (Button item in buttons)
								item.Text = "Play";
							btn.Text = "Stop";
						}
					});
			}
			tableLayoutPanel1.ResumeLayout();
		}

		void SongStoppedInternal()
		{
			playingButton.Text = "Play";
			playingButton = null;
		}

		static void SongStopped()
		{
			Instance.Invoke(new Action(Instance.SongStoppedInternal));
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			IniFile.Save(new Dictionary<string, Dictionary<string, string>>() { { "", INI } }, "config.ini");
		}
	}
}