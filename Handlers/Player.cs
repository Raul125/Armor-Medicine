// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ArmorMedicine.Handlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using static ArmorMedicine;

    /// <summary>
    /// Handles player events.
    /// </summary>
    internal sealed class Player
    {
        /// <inheritdoc cref="Handlers.Player.OnUsedMedicalItem(UsedMedicalItemEventArgs)"/>
        public void OnUsedMedicalItem(UsedMedicalItemEventArgs ev)
        {
            switch (ev.Item)
            {
                case ItemType.Painkillers:
                    {
                        if (Instance.Config.Painkillers != 0)
                        {
                            if (!Instance.Config.WillDecay)
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Painkillers;

                                ev.Player.ReferenceHub.playerStats.artificialHpDecay = 0;
                            }
                            else
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Painkillers;
                            }
                        }

                        return;
                    }

                case ItemType.Adrenaline:
                    {
                        if (Instance.Config.Adrenaline != 0)
                        {
                            if (!Instance.Config.WillDecay)
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Adrenaline;

                                ev.Player.ReferenceHub.playerStats.artificialHpDecay = 0;
                            }
                            else
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Adrenaline;
                            }
                        }

                        return;
                    }

                case ItemType.Medkit:
                    {
                        if (Instance.Config.Medkit != 0)
                        {
                            if (!Instance.Config.WillDecay)
                            {
                                ev.Player.ArtificialHealth += Instance.Config.Medkit;

                                ev.Player.ReferenceHub.playerStats.artificialHpDecay = 0;
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

                                ev.Player.ReferenceHub.playerStats.artificialHpDecay = 0;
                            }
                            else
                            {
                                ev.Player.ArtificialHealth += Instance.Config.SCP207;
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

                                ev.Player.ReferenceHub.playerStats.artificialHpDecay = 0;
                            }
                            else
                            {
                                ev.Player.ArtificialHealth += Instance.Config.SCP500;
                            }
                        }

                        return;
                    }
            }
        }

        /// <inheritdoc cref="Handlers.Player.OnUsedMedicalItem(UsedMedicalItemEventArgs)"/>
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player.ReferenceHub.playerStats.artificialHpDecay == 0)
            {
                ev.Player.ReferenceHub.playerStats.artificialHpDecay = 0.75f;
            }
        }
    }
}
