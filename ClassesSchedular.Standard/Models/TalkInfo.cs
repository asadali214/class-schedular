// <copyright file="TalkInfo.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ClassesSchedular.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using ClassesSchedular.Standard;
    using ClassesSchedular.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// TalkInfo.
    /// </summary>
    public class TalkInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TalkInfo"/> class.
        /// </summary>
        public TalkInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TalkInfo"/> class.
        /// </summary>
        /// <param name="topic">topic.</param>
        /// <param name="time">time.</param>
        /// <param name="presidentInvited">presidentInvited.</param>
        /// <param name="externalGuestsInvited">externalGuestsInvited.</param>
        public TalkInfo(
            string topic,
            string time,
            bool? presidentInvited = null,
            bool? externalGuestsInvited = null)
        {
            this.Topic = topic;
            this.Time = time;
            this.PresidentInvited = presidentInvited;
            this.ExternalGuestsInvited = externalGuestsInvited;
        }

        /// <summary>
        /// Gets or sets Topic.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("topic")]
        [JsonRequired]
        public string Topic { get; set; }

        /// <summary>
        /// Gets or sets Time.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("time")]
        [JsonRequired]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets PresidentInvited.
        /// </summary>
        [JsonProperty("presidentInvited", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PresidentInvited { get; set; }

        /// <summary>
        /// Gets or sets ExternalGuestsInvited.
        /// </summary>
        [JsonProperty("externalGuestsInvited", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExternalGuestsInvited { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TalkInfo : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is TalkInfo other &&                ((this.Topic == null && other.Topic == null) || (this.Topic?.Equals(other.Topic) == true)) &&
                ((this.Time == null && other.Time == null) || (this.Time?.Equals(other.Time) == true)) &&
                ((this.PresidentInvited == null && other.PresidentInvited == null) || (this.PresidentInvited?.Equals(other.PresidentInvited) == true)) &&
                ((this.ExternalGuestsInvited == null && other.ExternalGuestsInvited == null) || (this.ExternalGuestsInvited?.Equals(other.ExternalGuestsInvited) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Topic = {(this.Topic == null ? "null" : this.Topic)}");
            toStringOutput.Add($"this.Time = {(this.Time == null ? "null" : this.Time)}");
            toStringOutput.Add($"this.PresidentInvited = {(this.PresidentInvited == null ? "null" : this.PresidentInvited.ToString())}");
            toStringOutput.Add($"this.ExternalGuestsInvited = {(this.ExternalGuestsInvited == null ? "null" : this.ExternalGuestsInvited.ToString())}");
        }
    }
}