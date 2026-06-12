using Microsoft.Extensions.DependencyInjection;
using OnlineXOGame_Client.WinForms.Common;
using OnlineXOGame_Client.WinForms.Forms;
using OnlineXOGame_Client.WinForms.Forms.Testing;
using OnlineXOGame_Client.WinForms.Forms.User;
using OnlineXOGame_Client.WinForms.Forms.XOGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.WinForms.DependencyInjection {
    public static class WinFormsServiceCollectionExtensions {
        public static IServiceCollection AddWinForms (this IServiceCollection services) {
            services.AddSingleton<IFormFactory,FormFactory>();
            services.AddSingleton<SessionManager>();

            // Testing Forms
            services.AddTransient<Form1>();
            services.AddTransient<TestingHubClientForm>();

            // Auth Forms
            services.AddTransient<LoginAndSignUpForm>();

            // User Forms 
            services.AddTransient<UserProfileForm>();

            // XO Game Forms 
            services.AddTransient<GameInfoForm>();
            services.AddTransient<GamesForm>();


            return services;
        }
    }
}
