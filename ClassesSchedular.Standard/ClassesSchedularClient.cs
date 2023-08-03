// <copyright file="ClassesSchedularClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ClassesSchedular.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using ClassesSchedular.Standard.Controllers;
    using ClassesSchedular.Standard.Http.Client;
    using ClassesSchedular.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class ClassesSchedularClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "{customUrl}" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly Lazy<APIController> client;

        private ClassesSchedularClient(
            Environment environment,
            string customUrl,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.CustomUrl = customUrl;
            this.HttpClientConfiguration = httpClientConfiguration;

            globalConfiguration = new GlobalConfiguration.Builder()
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .Parameters(globalParameter => globalParameter
                    .Template(templateParameter => templateParameter.Setup("customUrl", this.CustomUrl)))
                .UserAgent(userAgent)
                .Build();


            this.client = new Lazy<APIController>(
                () => new APIController(globalConfiguration));
        }

        /// <summary>
        /// Gets APIController controller.
        /// </summary>
        public APIController APIController => this.client.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets CustomUrl.
        /// CustomUrl value.
        /// </summary>
        public string CustomUrl { get; }


        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the ClassesSchedularClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .CustomUrl(this.CustomUrl)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"CustomUrl = {this.CustomUrl}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> ClassesSchedularClient.</returns>
        internal static ClassesSchedularClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("CLASSES_SCHEDULAR_STANDARD_ENVIRONMENT");
            string customUrl = System.Environment.GetEnvironmentVariable("CLASSES_SCHEDULAR_STANDARD_CUSTOM_URL");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (customUrl != null)
            {
                builder.CustomUrl(customUrl);
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = ClassesSchedular.Standard.Environment.Production;
            private string customUrl = "http://localhost:3000/class/schedular";
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets CustomUrl.
            /// </summary>
            /// <param name="customUrl"> CustomUrl. </param>
            /// <returns> Builder. </returns>
            public Builder CustomUrl(string customUrl)
            {
                this.customUrl = customUrl ?? throw new ArgumentNullException(nameof(customUrl));
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Creates an object of the ClassesSchedularClient using the values provided for the builder.
            /// </summary>
            /// <returns>ClassesSchedularClient.</returns>
            public ClassesSchedularClient Build()
            {

                return new ClassesSchedularClient(
                    environment,
                    customUrl,
                    httpClientConfig.Build());
            }
        }
    }
}
