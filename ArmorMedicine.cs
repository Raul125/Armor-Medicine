// <copyright file="ArmorMedicine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ArmorMedicine
{
    using System;

    using Exiled.API.Enums;
    using Exiled.API.Features;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class ArmorMedicine : Plugin<Config>
    {
        private static ArmorMedicine singleton = new ArmorMedicine();

        private Handlers.Player eventsPl;

        private ArmorMedicine()
        {
        }

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static ArmorMedicine Instance => singleton;

        /// <inheritdoc/>
        public override string Author { get; } = "Raul125";

        /// <inheritdoc/>
        public override string Name { get; } = "ArmorMedicine";

        /// <inheritdoc/>
        public override string Prefix { get; } = "ArmorMedicine";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 1);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(2, 8, 0);

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Lower;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            base.OnEnabled();

            this.RegisterEvents();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            base.OnDisabled();

            this.UnregisterEvents();
        }

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            this.eventsPl = new Handlers.Player();
            Exiled.Events.Handlers.Player.MedicalItemUsed += this.eventsPl.OnUsedMedicalItem;
            Exiled.Events.Handlers.Player.UsingMedicalItem += this.eventsPl.OnUsingMedicalItem;
            Exiled.Events.Handlers.Player.ChangingRole += this.eventsPl.OnChangingRole;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.MedicalItemUsed -= this.eventsPl.OnUsedMedicalItem;
            Exiled.Events.Handlers.Player.UsingMedicalItem -= this.eventsPl.OnUsingMedicalItem;
            Exiled.Events.Handlers.Player.ChangingRole -= this.eventsPl.OnChangingRole;
            this.eventsPl = null;
        }
    }
}
