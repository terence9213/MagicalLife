﻿using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.GUI.MainMenu;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Loads all internal textures.
    /// </summary>
    public class TextureLoader : IGameLoader
    {
        private int TotalJobs = -1;

        public int GetTotalOperations()
        {
            if (this.TotalJobs == -1)
            {
                this.TotalJobs = this.CalculateTotalJobs();
            }

            return this.TotalJobs;
        }

        private int CalculateTotalJobs()
        {
            List<IRequireTexture> gui = ReflectionUtil.LoadAllInterface<IRequireTexture>(Assembly.GetAssembly(typeof(MainMenuContainer)));
            List<IRequireTexture> api = ReflectionUtil.LoadAllInterface<IRequireTexture>(Assembly.GetAssembly(typeof(Tile)));

            return gui.Count + api.Count;
        }

        public void InitialStartup(ref int progress)
        {
            List<IRequireTexture> gui = ReflectionUtil.LoadAllInterface<IRequireTexture>(Assembly.GetAssembly(typeof(MainMenuContainer)));
            List<IRequireTexture> api = ReflectionUtil.LoadAllInterface<IRequireTexture>(Assembly.GetAssembly(typeof(Tile)));

            foreach (IRequireTexture item in gui)
            {
                Texture2D texture = Game1.AssetManager.Load<Texture2D>(item.GetTextureName());
                AssetManager.RegisterTexture(texture);
                progress++;
            }

            foreach (IRequireTexture item in api)
            {
                Texture2D texture = Game1.AssetManager.Load<Texture2D>(item.GetTextureName());
                AssetManager.RegisterTexture(texture);
                progress++;
            }

            progress = this.TotalJobs;
        }
    }
}