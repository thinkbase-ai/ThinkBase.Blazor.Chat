﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBase.Blazor.Chat.Extensions
{
    public static class ChatServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorChat(this IServiceCollection services)
        {
            services.AddFluentUIComponents();
            services.AddBlazorAdaptiveCards();
            return services;
        }
    }
}
