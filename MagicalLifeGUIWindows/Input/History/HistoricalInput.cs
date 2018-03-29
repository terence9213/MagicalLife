﻿using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.History
{
    /// <summary>
    /// Holds information about the actions of some user input.
    /// </summary>
    public class HistoricalInput
    {
        /// <summary>
        /// If this is true, the input detected deselects everything previously selected.
        /// </summary>
        public bool DeselectingAll { get; set; }

        /// <summary>
        /// If this is true, then instead of selecting and deselecting this input actually contains information about a order to a tile.
        /// </summary>
        public bool OrderedToTile { get; set; }

        public List<Selectable> Selected { get; set; } = new List<Selectable>();
        public List<Selectable> DeselectSome { get; set; } = new List<Selectable>();

        /// <summary>
        /// The location of the tile that the order was to.
        /// </summary>
        public Point3D OrderPoint { get; set; }

        public HistoricalInput(Point3D point)
        {
            this.OrderedToTile = true;
            this.OrderPoint = point;
            this.DeselectingAll = false;
        }

        public HistoricalInput(List<Selectable> selected)
        {
            this.Selected = selected;
            this.OrderedToTile = false;
            this.DeselectingAll = false;
        }

        public HistoricalInput(bool deselectAll, List<Selectable> deselectSome)
        {
            this.OrderedToTile = false;

            if (deselectAll)
            {
                this.DeselectingAll = true;
            }
            else
            {
                this.DeselectingAll = false;
                this.DeselectSome = deselectSome;
            }
        }

        public HistoricalInput(List<Selectable> selectSome, bool deselectAll)
        {
            this.OrderedToTile = false;
            this.DeselectingAll = deselectAll;
            this.Selected = selectSome;
        }
    }
}