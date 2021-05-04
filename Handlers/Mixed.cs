// -----------------------------------------------------------------------
// <copyright file="Mixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ArmorMedicine.Handlers
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using static ArmorMedicine;

    /// <summary>
    /// Handles player events.
    /// </summary>
    internal sealed class Mixed
    {
        /// <inheritdoc cref="Handlers.Mixed.OnUsedMedicalItem(UsedMedicalItemEventArgs)"/>
        public void OnUsedMedicalItem(UsedMedicalItemEventArgs ev)
        {
            if (ev.Player == null)
            {
                return;
            }

            if (Instance.IsAdvancedSubclassing)
            {
                if (this.HasNoArmorDecayAbility(ev.Player))
                {
                    return;
                }
            }

            switch (ev.Item)
            {
                case ItemType.Medkit:
                    {
                        if (Instance.Config.Medkit != 0)
                        {
                            if (!Instance.Config.WillDecay)
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Medkit;

                                if (ev.Player.ArtificialHealthDecay != 0)
                                {
                                    ev.Player.ArtificialHealthDecay = 0;
                                }
                            }
                            else
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Medkit;
                            }
                        }

                        return;
                    }

                case ItemType.SCP207:
                    {
                        if (Instance.Config.SCP207 != 0)
                        {
                            if (!Instance.Config.WillDecay)
                            {
                                ev.Player.ArtificialHealth += Instance.Config.SCP207;

                                if (ev.Player.ArtificialHealthDecay != 0)
                                {
                                    ev.Player.ArtificialHealthDecay = 0;
                                }
                            }
                            else
                            {
                                ev.Player.ArtificialHealth += Instance.Config.SCP207;
                            }
                        }

                        return;
                    }
            }
        }

        /// <inheritdoc cref="Handlers.Mixed.OnUsingMedicalItem(UsingMedicalItemEventArgs)"/>
        public void OnUsingMedicalItem(UsingMedicalItemEventArgs ev)
        {
            if (!ev.IsAllowed)
            {
                return;
            }

            if (Instance.IsAdvancedSubclassing)
            {
                if (this.HasNoArmorDecayAbility(ev.Player))
                {
                    return;
                }
            }

            switch (ev.Item)
                {
                    case ItemType.Adrenaline:
                        {
                            if (Instance.Config.Adrenaline != 0)
                            {
                                if (!Instance.Config.WillDecay)
                                {
                                    ev.Player.ArtificialHealth += Instance.Config.Adrenaline;

                                    if (ev.Player.ArtificialHealthDecay != 0)
                                    {
                                        ev.Player.ArtificialHealthDecay = 0;
                                    }
                                }
                                else
                                {
                                    ev.Player.ArtificialHealth += Instance.Config.Adrenaline;
                                }
                            }

                            return;
                        }

                    case ItemType.SCP500:
                        {
                            if (Instance.Config.SCP500 != 0)
                            {
                                if (!Instance.Config.WillDecay)
                                {
                                    ev.Player.ArtificialHealth += Instance.Config.SCP500;

                                    if (ev.Player.ArtificialHealthDecay != 0)
                                    {
                                        ev.Player.ArtificialHealthDecay = 0;
                                    }
                                }
                                else
                                {
                                    ev.Player.ArtificialHealth += Instance.Config.SCP500;
                                }
                            }

                            return;
                        }

                    case ItemType.Painkillers:
                        {
                            if (Instance.Config.Painkillers != 0)
                            {
                                if (!Instance.Config.WillDecay)
                                {
                                    ev.Player.ArtificialHealth += Instance.Config.Painkillers;

                                    if (ev.Player.ArtificialHealthDecay != 0)
                                    {
                                        ev.Player.ArtificialHealthDecay = 0;
                                    }
                                }
                                else
                                {
                                    ev.Player.ArtificialHealth += Instance.Config.Painkillers;
                                }
                            }

                            return;
                        }
                }
        }

        /// <inheritdoc cref="Handlers.Mixed.OnChangingRole(ChangingRoleEventArgs)"/>
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player.ArtificialHealthDecay == 0)
            {
                ev.Player.ArtificialHealthDecay = 0.75f;
            }
        }

        private bool HasNoArmorDecayAbility(Player ply)
        {
            var sub = Subclass.API.GetPlayersSubclass(ply);
            if (sub == null)
            {
                return false;
            }

            if (sub.Abilities.Contains(Subclass.AbilityType.NoArmorDecay))
            {
                return true;
            }

            return false;
        }
    }
}
