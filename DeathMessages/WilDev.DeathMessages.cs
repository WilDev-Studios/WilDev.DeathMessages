using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Players.Life.Events;
using System.Threading.Tasks;
using OpenMod.Unturned.Users;
using System.Numerics;
using OpenMod.Unturned.Locations;
using SDG.Unturned;

[assembly: PluginMetadata("WilDev.DeathMessages", DisplayName = "WilDev Studios' Death Messages")]
namespace WilDev.DeathMessages
{
    public class DeathMessagesPlugin : OpenModUnturnedPlugin
    {
        private readonly ILogger<DeathMessagesPlugin> m_Logger;

        public DeathMessagesPlugin(
            ILogger<DeathMessagesPlugin> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Logger = logger;
        }

        protected override UniTask OnLoadAsync()
        {
            m_Logger.LogInformation("+==========================================================+");
            m_Logger.LogInformation("| WILDEV.DEATHMESSAGES plugin has been loaded!             |");
            m_Logger.LogInformation("| Made with <3 by WildKadeGaming @ WilDev Studios          |");
            m_Logger.LogInformation("| WilDev Discord: https://discord.com/invite/4Ggybyy87d    |");
            m_Logger.LogInformation("+==========================================================+");

            return UniTask.CompletedTask;
        }

        protected override UniTask OnUnloadAsync()
        {
            m_Logger.LogInformation("+==========================================================+");
            m_Logger.LogInformation("| WILDEV.DEATHMESSAGES plugin has been unloaded!           |");
            m_Logger.LogInformation("| Made with <3 by WildKadeGaming @ WilDev Studios          |");
            m_Logger.LogInformation("| WilDev Discord: https://discord.com/invite/4Ggybyy87d    |");
            m_Logger.LogInformation("+==========================================================+");

            return UniTask.CompletedTask;
        }
    }

    public class PlayerDeathEvent : IEventListener<UnturnedPlayerDeathEvent>
    {
        private readonly IUnturnedUserDirectory m_UnturnedUserDirectory;
        private readonly IUnturnedLocationDirectory m_UnturnedLocationDirectory;
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly IConfiguration m_Configuration;
        private readonly ILogger<PlayerDeathEvent> m_Logger;

        public PlayerDeathEvent(
            IUnturnedUserDirectory unturnedUserDirectory,
            IUnturnedLocationDirectory unturnedLocationDirectory,
            IStringLocalizer stringLocalizer,
            IConfiguration configuration,
            ILogger<PlayerDeathEvent> logger
            )
        {
            m_UnturnedUserDirectory = unturnedUserDirectory;
            m_UnturnedLocationDirectory = unturnedLocationDirectory;
            m_StringLocalizer = stringLocalizer;
            m_Configuration = configuration;
            m_Logger = logger;
        }

        public Task HandleEventAsync(object sender, UnturnedPlayerDeathEvent @event)
        {
            if (m_Configuration.GetSection("Enabled").Get<bool>())
            {
                UnturnedUser unturnedUser = m_UnturnedUserDirectory.FindUser(@event.Player.SteamId);
                if (unturnedUser == null)
                {
                    return Task.CompletedTask;
                }

                UnturnedUser instigatorUser = m_UnturnedUserDirectory.FindUser(@event.Instigator);

                Vector3 playerPosition = unturnedUser.Player.Transform.Position;
                UnturnedLocation location = m_UnturnedLocationDirectory.GetNearestLocation(playerPosition);

                string deathCauseRaw = @event.DeathCause.ToString().ToLower();
                string deathCause = char.ToUpper(deathCauseRaw[0]) + deathCauseRaw.Substring(1);

                string instigatorName = instigatorUser?.DisplayName ?? "Unknown";
                string weaponName = instigatorUser?.Player.Player.equipment?.asset?.itemName ?? "None";
                float distance = instigatorUser != null ? Vector3.Distance(instigatorUser.Player.Transform.Position, playerPosition) : 0;
                string locationName = location?.ToString() ?? "Unknown";

                ChatManager.serverSendMessage(m_StringLocalizer[$"Deaths:{deathCause}", new
                {
                    Player = unturnedUser.DisplayName,
                    Instigator = instigatorName,
                    Weapon = weaponName,
                    Distance = distance,
                    Location = locationName
                }], UnityEngine.Color.green, null, null, EChatMode.GLOBAL, m_Configuration.GetSection("Death-Message-Image-URL").Get<string>(), true);
            }
            else
            {
                m_Logger.LogInformation("Plugin disabled. Event not fired.");
            }

            return Task.CompletedTask;
        }

    }
}
