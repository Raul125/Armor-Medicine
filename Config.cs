// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ArmorMedicine
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether gets the bool config.
        /// </summary>
        [Description("Will AHP slowly decay or stay permament?")]
        public bool WillDecay { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Number of AHP being given per use of medical item")]
        public float Painkillers { get; private set; } = 10;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("It doesn't overrides the adrenaline hp (30), it adds more <3")]
        public float Adrenaline { get; private set; } = 0;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        public float Medkit { get; private set; } = 20;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        public float SCP207 { get; private set; } = 40;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        public float SCP500 { get; private set; } = 50;
    }
}
