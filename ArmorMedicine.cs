// <copyright file="ArmorMedicine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
#pragma warning disable SA1401 // Fields should be private
namespace ArmorMedicine
{
    using System;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Loader;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class ArmorMedicine : Plugin<Config>
    {
        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static ArmorMedicine Instance;

        /// <summary>
        /// UwU.
        /// </summary>
        public bool IsAdvancedSubclassing = false;

        private Handlers.Mixed eventsPl;

        /// <inheritdoc/>
        public override string Author { get; } = "Raul125";

        /// <inheritdoc/>
        public override string Name { get; } = "ArmorMedicine";

        /// <inheritdoc/>
        public override string Prefix { get; } = "ArmorMedicine";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 3);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            this.RegisterEvents();
            this.CheckPl();
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            this.UnregisterEvents();
            base.OnDisabled();
        }

        /// <inheritdoc/>
        public override void OnReloaded()
        {
            this.CheckPl();
            base.OnReloaded();
        }

        private void CheckPl()
        {
            foreach (var pl in Loader.Plugins)
            {
                if (pl.Name == "Subclass")
                {
                    this.IsAdvancedSubclassing = true;
                }
            }
        }

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            this.eventsPl = new Handlers.Mixed();
            Instance = this;
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
            Instance = null;
        }
    }
}
