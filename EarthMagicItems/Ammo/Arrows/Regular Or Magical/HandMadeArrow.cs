﻿using System;
using System.Collections.Generic;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthMagicDynamicMarket;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows
{
    /// <summary>
    /// The worst arrow.
    /// </summary>
    public class HandMadeArrow : IAmmo
    {
        private Dice.Die _Uses = new Dice.Die(1, 2, 0);
        private bool _QuestItem = false;
        private int _Level = 1;
        private Guid _ID = new Guid();
        private string _Name = "Handmade Arrow";
        private int _ChanceToHit = 10;

        private List<string> _Lore = new List<string> { };
        private List<string> _OtherInfo = new List<string> { "Does 1d6 piercing damage.", "If you are lucky, you get to use this arrow twice" };

        public HandMadeArrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 6, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
            }
        }

        public Dice.Die Uses
        {
            get
            {
                return this._Uses;
            }

            set
            {
                this._Uses = value;
            }
        }

        public bool QuestItem
        {
            get
            {
                return this._QuestItem;
            }

            set
            {
                this._QuestItem = value;
            }
        }

        public int Value
        {
            get
            {
                return Pricer.GetPrice(this);
            }
        }

        public int Level
        {
            get
            {
                return this._Level;
            }

            set
            {
                this._Level = value;
            }
        }

        public Guid ID
        {
            get
            {
                return this._ID;
            }

            set
            {
                this._ID = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }

            set
            {
                this._Name = value;
            }
        }

        public List<string> Lore
        {
            get
            {
                return this._Lore;
            }

            set
            {
                this._Lore = value;
            }
        }

        public List<string> OtherInformation
        {
            get
            {
                return this._OtherInfo;
            }

            set
            {
                this._OtherInfo = value;
            }
        }

        public int ChanceToHit
        {
            get
            {
                return this._ChanceToHit;
            }

            set
            {
                this._ChanceToHit = value;
            }
        }

        public event EventHandler<IItem> ItemSold;
        public event EventHandler<IItem> ItemBought;
        public event EventHandler<IItem> ItemDropped;
        public event EventHandler<IItem> ItemPickedUp;
        public event EventHandler<IItem> ItemLost;
        public event EventHandler<IItem> ItemThrown;
        public event EventHandler<IItem> ItemDestroyed;
        public event EventHandler<IItem> ItemEquipped;
    }
}
