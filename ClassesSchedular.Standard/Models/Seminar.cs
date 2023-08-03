// <copyright file="Seminar.cs" company="APIMatic">
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
    /// Seminar.
    /// </summary>
    public class Seminar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Seminar"/> class.
        /// </summary>
        public Seminar()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Seminar"/> class.
        /// </summary>
        /// <param name="seminarId">seminarId.</param>
        /// <param name="time">time.</param>
        /// <param name="totalAudience">totalAudience.</param>
        public Seminar(
            string seminarId,
            string time,
            int? totalAudience = null)
        {
            this.SeminarId = seminarId;
            this.Time = time;
            this.TotalAudience = totalAudience;
        }

        /// <summary>
        /// Gets or sets SeminarId.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("seminarId")]
        [JsonRequired]
        public string SeminarId { get; set; }

        /// <summary>
        /// Gets or sets Time.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("time")]
        [JsonRequired]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets TotalAudience.
        /// </summary>
        [JsonProperty("totalAudience", NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalAudience { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Seminar : ({string.Join(", ", toStringOutput)})";
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
            return obj is Seminar other &&                ((this.SeminarId == null && other.SeminarId == null) || (this.SeminarId?.Equals(other.SeminarId) == true)) &&
                ((this.Time == null && other.Time == null) || (this.Time?.Equals(other.Time) == true)) &&
                ((this.TotalAudience == null && other.TotalAudience == null) || (this.TotalAudience?.Equals(other.TotalAudience) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SeminarId = {(this.SeminarId == null ? "null" : this.SeminarId)}");
            toStringOutput.Add($"this.Time = {(this.Time == null ? "null" : this.Time)}");
            toStringOutput.Add($"this.TotalAudience = {(this.TotalAudience == null ? "null" : this.TotalAudience.ToString())}");
        }
    }
}