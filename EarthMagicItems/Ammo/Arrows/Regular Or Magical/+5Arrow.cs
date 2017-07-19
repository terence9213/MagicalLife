﻿using EarthWithMagicAPI.API.Interfaces.Items;
using EarthMagicDynamicMarket;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndFantasyLands.API.Items.Ammo.Arrows
{
    /// <summary>
    /// A slightly better arrow than the +4 arrow.
    /// </summary>
    public class _5Arrow : IAmmo
    {
        private Dice.Die _Uses = new Dice.Die(5, 7, 0);
        private bool _QuestItem = false;
        private int _Level = 10;
        private Guid _ID = new Guid();
        private string _Name = "Arrow +5";
        private int _ChanceToHit = 32;

        private List<string> _Lore = new List<string> { };
        private List<string> _OtherInfo = new List<string> { "Does 1d8 +5 piercing damage.", "This arrow COULD be used 7 times." };

        public _5Arrow()
        {

        }

        public Damage AttackDamage
        {
            get
            {
                return new Damage(new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0), new Dice.Die(1, 8, 3), new Dice.Die(0, 0, 0), new Dice.Die(0, 0, 0));
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
