using System;
using System.Threading.Tasks;

namespace DiscordStreamBot.Discord
{
    public interface IDiscordService
    {
        Task StartBot(IServiceProvider services = null);
    }
}