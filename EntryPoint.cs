using System;
using System.Linq;
using MonomiPark.SlimeRancher.Regions;
using SRML;
using SRML.SR;
using SRML.SR.Utils;
using SRML.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MainMenuIsland
{
	public class EntryPoint : ModEntryPoint
	{
		public override void PreLoad()
		{
			base.HarmonyInstance.PatchAll();
			SRCallbacks.OnMainMenuLoaded += delegate(MainMenuUI menu)
			{
				bool flag = EntryPoint.Art == null;
				if (flag)
				{
					GameObject gameObject = PrefabUtils.CopyPrefab(GameObject.Find("Art"));
					gameObject.transform.position = new Vector3(-75.04419f, 2.251723f, 274.5284f);
					GameObject gameObject2 = gameObject.transform.Find("Flora").gameObject;
					Object.Destroy(gameObject2.transform.Find("Missing Prefab").gameObject);
					GameObject gameObject3 = gameObject.transform.Find("Land Structure").gameObject;
					Object.Destroy(gameObject3.transform.Find("mtnSpireReef04 (4)").gameObject);
					Object.Destroy(gameObject3.transform.Find("mtnSpireReef04 (2)").gameObject);
					Object.Destroy(gameObject3.transform.Find("mtnSpireReef04 (3)").gameObject);
					Object.Destroy(gameObject3.transform.Find("mtnSpireReef04 (1)").gameObject);
					Object.Destroy(gameObject3.transform.Find("mtnSpireReef04").gameObject);
					Object.Destroy(gameObject3.transform.Find("mtnSpireReef04").gameObject);
					Object.Destroy(gameObject.transform.Find("BeatrixMainMenu").gameObject);
					Object.Destroy(gameObject.transform.Find("Vac").gameObject);
					gameObject.transform.Find("moundSand01 (4)").SetParent(gameObject3.transform);
					gameObject.transform.Find("moundSand01 (3)").SetParent(gameObject3.transform);
					gameObject.transform.Find("moundSand01 (2)").SetParent(gameObject3.transform);
					gameObject.transform.Find("moundSand01 (1)").SetParent(gameObject3.transform);
					gameObject.transform.Find("moundSand01").SetParent(gameObject3.transform);
					EntryPoint.Art = gameObject;
				}
			};
			SRCallbacks.PreSaveGameLoad += delegate(SceneContext context)
			{
				GameObject gameObject4 = GameObject.Find("zoneSEA/cellSea_Bridgeway");
				Region component = gameObject4.GetComponent<Region>();
				component.bounds = new Bounds(component.bounds.center, new Vector3(164.6486f, 239.3784f, 117.9108f));
				GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Main Nav/woodPlat01 (5)").transform.position = new Vector3(-107.1f, -30.7f, 309.9f);
				GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Constructs/woodPlat09 (1)").transform.position = new Vector3(-107.1f, -30.7f, 309.9f);
				GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Main Nav/woodPlat08").transform.position = new Vector3(-107.1f, -30.7f, 309.9f);
				GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Constructs/woodPosts01 (14)").transform.position = new Vector3(-107.1f, -30.7f, 309.9f);
				GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Constructs/woodPosts01 (13)").transform.position = new Vector3(-107.1f, -30.7f, 309.9f);
				GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Main Nav/woodPlat02 (5)").transform.position = new Vector3(-107.1f, -30.7f, 309.9f);
				GameObject gameObject5 = new GameObject("zoneMAINMENU");
				gameObject5.SetActive(false);
				GameObject gameObject6 = new GameObject("cellMainMenu_Island")
				{
					transform = 
					{
						parent = gameObject5.transform
					}
				};
				GameObject gameObject7 = Object.Instantiate<GameObject>(EntryPoint.Art, gameObject6.transform, true);
				gameObject7.name = "Sector";
				GameObject gameObject8 = new GameObject("Constructs")
				{
					transform = 
					{
						parent = gameObject7.transform
					}
				};
				GameObject gameObject9 = new GameObject("Resources")
				{
					transform = 
					{
						parent = gameObject7.transform
					}
				};
				GameObject gameObject10 = new GameObject("Slimes")
				{
					transform = 
					{
						parent = gameObject7.transform
					}
				};
				GameObject gameObject11 = new GameObject("Build Sites")
				{
					transform = 
					{
						parent = gameObject7.transform
					}
				};
				GameObject gameObject12 = new GameObject("Main Nav")
				{
					transform = 
					{
						parent = gameObject7.transform
					}
				};
				GameObject gameObject13 = Object.Instantiate<GameObject>(GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Constructs/woodTorch01"), gameObject8.transform);
				gameObject13.transform.localPosition = new Vector3(-75.7f, 1.5f, 254.5f);
				GameObject gameObject14 = GameObjectUtils.InstantiateInactive(GameObject.Find("zoneQUARRY/cellQuarry_Onsen/Sector/Resources/waterFountain01"));
				gameObject14.transform.parent = gameObject9.transform;
				gameObject14.name = "waterFountain01";
				gameObject14.transform.localPosition = new Vector3(-105.1543f, 1.866936f, 280.2657f);
				LiquidSource componentInChildren = gameObject14.GetComponentInChildren<LiquidSource>();
				componentInChildren.director = IdHandlerUtils.GlobalIdDirector;
				componentInChildren.director.persistenceDict.Add(componentInChildren, "MainMenuLiquid");
				gameObject14.SetActive(true);
				ZoneDirector zoneDirector = gameObject5.AddComponent<ZoneDirector>();
				zoneDirector.zone = Enums.MAIN_MENU;
				zoneDirector.auxItems = new ZoneDirector.AuxItemEntry[0];
				zoneDirector.cratePrefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CRATE_MOSS_01);
				IdDirector idDirector = gameObject5.AddComponent<IdDirector>();
				CellDirector cellDirector = gameObject6.AddComponent<CellDirector>();
				cellDirector.notShownOnMap = false;
				cellDirector.targetSlimeCount = 15;
				cellDirector.cullSlimesLimit = 25;
				cellDirector.minPerSpawn = 5;
				cellDirector.maxPerSpawn = 10;
				Region region = gameObject6.AddComponent<Region>();
				gameObject6.AddComponent<RegionInitializer>();
				region.cellDir = cellDirector;
				region.root = gameObject7;
				region.overrideBounds = true;
				region.setId = RegionRegistry.RegionSetId.HOME;
				Bounds bounds = default(Bounds);
				bounds.center = new Vector3(-74.0313f, 82.1235f, 272.9703f);
				bounds.extents = new Vector3(51.5053f, 90f, 33.4391f);
				bounds.size = new Vector3(103.0105f, 180f, 66.8782f);
				bounds.max = new Vector3(-22.526f, 172.1235f, 306.4094f);
				bounds.min = new Vector3(-125.5365f, -7.8765f, 239.5312f);
				Bounds bounds2 = bounds;
				region.bounds = bounds2;
				GameObject gameObject15 = new GameObject("nodeSlime")
				{
					transform = 
					{
						parent = gameObject10.transform
					}
				};
				gameObject15.transform.position = new Vector3(-96.5983f, 1.6383f, 267.9723f);
				DirectedSlimeSpawner directedSlimeSpawner = gameObject15.AddComponent<DirectedSlimeSpawner>();
				directedSlimeSpawner.spawnFX = context.fxPool.pooledObjects.Keys.First((GameObject x) => x.name == "FX Slime Spawn");
				directedSlimeSpawner.slimeSpawnFX = context.fxPool.pooledObjects.Keys.First((GameObject x) => x.name == "FX Splat");
				directedSlimeSpawner.spawnLocs = new GameObject[]
				{
					new GameObject("SpawnPoint1"),
					new GameObject("SpawnPoint2"),
					new GameObject("SpawnPoint3"),
					new GameObject("SpawnPoint4")
				};
				foreach (GameObject gameObject16 in directedSlimeSpawner.spawnLocs)
				{
					gameObject16.transform.SetParent(directedSlimeSpawner.transform, false);
				}
				directedSlimeSpawner.spawnLocs[0].transform.position = new Vector3(-96.5983f, 1.6383f, 267.9723f);
				directedSlimeSpawner.spawnLocs[1].transform.position = new Vector3(-81.8823f, 1.6383f, 260.6248f);
				directedSlimeSpawner.spawnLocs[2].transform.position = new Vector3(-60.7519f, 1.6383f, 272.7112f);
				directedSlimeSpawner.radius = 1f;
				directedSlimeSpawner.constraints = new DirectedActorSpawner.SpawnConstraint[]
				{
					new DirectedActorSpawner.SpawnConstraint
					{
						feral = false,
						maxAgitation = false,
						slimeset = new SlimeSet
						{
							members = new SlimeSet.Member[]
							{
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME),
									weight = 0.9f
								},
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.TABBY_SLIME),
									weight = 0.9f
								},
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.BOOM_SLIME),
									weight = 0.9f
								},
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROCK_SLIME),
									weight = 1.3f
								},
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.RAD_SLIME),
									weight = 0.9f
								}
							}
						},
						weight = 1f,
						window = new DirectedActorSpawner.TimeWindow
						{
							timeMode = DirectedActorSpawner.TimeMode.DAY
						}
					}
				};
				GameObject gameObject17 = Object.Instantiate<GameObject>(GameObject.Find("zoneDESERT/cellDesert_ValleyEnd/Sector/Resources/nestStony01"), gameObject9.transform);
				gameObject17.transform.position = new Vector3(-82.462f, 6.194f, 272.4793f);
				gameObject17.transform.localScale = new Vector3(1f, 1f, 1f);
				GameObject gameObject18 = gameObject17.transform.Find("nodeChicken").gameObject;
				Object.DestroyImmediate(gameObject18.GetComponent<DirectedAnimalSpawner>());
				DirectedAnimalSpawner directedAnimalSpawner = gameObject18.AddComponent<DirectedAnimalSpawner>();
				directedAnimalSpawner.radius = 0.5f;
				directedAnimalSpawner.spawnDelayFactor = 3f;
				directedAnimalSpawner.directedSpawnWeight = 1f;
				directedAnimalSpawner.constraints = new DirectedActorSpawner.SpawnConstraint[]
				{
					new DirectedActorSpawner.SpawnConstraint
					{
						feral = false,
						maxAgitation = false,
						slimeset = new SlimeSet
						{
							members = new SlimeSet.Member[]
							{
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.STONY_HEN),
									weight = 1f
								},
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.STONY_CHICK),
									weight = 1f
								},
								new SlimeSet.Member
								{
									prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROOSTER),
									weight = 0.1f
								}
							}
						},
						weight = 1f,
						window = new DirectedActorSpawner.TimeWindow
						{
							timeMode = DirectedActorSpawner.TimeMode.DAY
						}
					}
				};
				GameObject gameObject19 = Object.Instantiate<GameObject>(GameObject.Find("zoneRANCH/cellRanch_Home/Sector/Build Sites/siteGadget (10)"), gameObject11.transform);
				GadgetSite gadgetSite = gameObject19.GetComponent<GadgetSite>();
				gadgetSite.director = idDirector;
				gadgetSite.director.persistenceDict.Add(gadgetSite, "siteMainMenuGadgetSite1");
				gameObject19.transform.position = new Vector3(-38.3238f, 9.4f, 270.2451f);
				gameObject19 = Object.Instantiate<GameObject>(GameObject.Find("zoneRANCH/cellRanch_Home/Sector/Build Sites/siteGadget (10)"), gameObject11.transform);
				gadgetSite = gameObject19.GetComponent<GadgetSite>();
				gadgetSite.director = idDirector;
				gadgetSite.director.persistenceDict.Add(gadgetSite, "siteMainMenuGadgetSite2");
				gameObject19.transform.position = new Vector3(-80.70713f, 9.675907f, 294.0411f);
				gameObject19 = Object.Instantiate<GameObject>(GameObject.Find("zoneRANCH/cellRanch_Home/Sector/Build Sites/siteGadget (10)"), gameObject11.transform);
				gadgetSite = gameObject19.GetComponent<GadgetSite>();
				gadgetSite.director = idDirector;
				gadgetSite.director.persistenceDict.Add(gadgetSite, "siteMainMenuGadgetSite3");
				gameObject19.transform.position = new Vector3(-105.9634f, 1.825189f, 266.8593f);
				GameObject gameObject20 = Object.Instantiate<GameObject>(GameObject.Find("zoneSEA/cellSea_Bridgeway/Sector/Main Nav/woodPlat02"), gameObject12.transform);
				gameObject20.transform.position = new Vector3(-115.934f, 1.6924f, 272.2862f);
				gameObject20.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				Quaternion localRotation = gameObject20.transform.localRotation;
				localRotation.eulerAngles = new Vector3(0f, 340f, 0f);
				gameObject20.transform.localRotation = localRotation;
				gameObject5.SetActive(true);
			};
		}

		public static GameObject Art;
	}
}
