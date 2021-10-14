using System;
using UnityEngine;
using BalsaCore;

namespace CloverTech
{
    // Idea for countdown inspired by https://github.com/godarklight/Balsa-IUnderstand/blob/master/IUnderstand/IUnderstandMain.cs
    public class QuickStart : MonoBehaviour
    {
        int frameCountdown = 60;
        public void Start()
        {

        }

        public void Update()
        {
            if (frameCountdown > 0)
            {
                frameCountdown--;
                if (frameCountdown == 0)
                {
                    GameLogic.IsWorkshopScene = true;
                    GameLogic.IsCareerMode = false;
                    GameLogic.Instance.StartGameWithCurrentSettings();
                    Destroy(this);
                }
            }
        }
    }
    

    [BalsaAddon]
    public class Loader
    {
        private static bool loaded = false;
        private static GameObject go;
        private static MonoBehaviour mod;

        [BalsaAddonInit]
        public static void BalsaInit()
        {

            if (!loaded)
            {
                loaded = true;
                go = new GameObject();
                mod = go.AddComponent<QuickStart>();
            }
            
        }

        [BalsaAddonInit(invokeTime = AddonInvokeTime.Flight)]
        public static void BalsaInitFlight()
        {

        }

        [BalsaAddonFinalize(invokeTime = AddonInvokeTime.Flight)]
        public static void BalsaFinalizeFlight()
        {

        }
        //Game exit
        [BalsaAddonFinalize]
        public static void BalsaFinalize()
        {
            go.DestroyGameObject();
        }

    }
}
