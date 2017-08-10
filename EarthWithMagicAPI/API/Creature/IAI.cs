﻿using EarthWithMagicAPI.API.Stuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Used to abstract AI combat.
    /// </summary>
    public interface IAI
    {
        /// <summary>
        /// Your turn in combat.
        /// </summary>
        /// <param name="encounter">The current encounter.</param>
        /// <param name="creature">The monk this method must control.</param>
        void YourTurn(Encounter encounter, ICreature creature);
    }
}