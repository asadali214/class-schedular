// <copyright file="Lecture.cs" company="APIMatic">
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
    /// Lecture.
    /// </summary>
    public class Lecture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lecture"/> class.
        /// </summary>
        public Lecture()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lecture"/> class.
        /// </summary>
        /// <param name="lectureId">lectureId.</param>
        /// <param name="time">time.</param>
        /// <param name="totalAudience">totalAudience.</param>
        public Lecture(
            string lectureId,
            string time,
            int? totalAudience = null)
        {
            this.LectureId = lectureId;
            this.Time = time;
            this.TotalAudience = totalAudience;
        }

        /// <summary>
        /// Gets or sets LectureId.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("lectureId")]
        [JsonRequired]
        public string LectureId { get; set; }

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

            return $"Lecture : ({string.Join(", ", toStringOutput)})";
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
            return obj is Lecture other &&                ((this.LectureId == null && other.LectureId == null) || (this.LectureId?.Equals(other.LectureId) == true)) &&
                ((this.Time == null && other.Time == null) || (this.Time?.Equals(other.Time) == true)) &&
                ((this.TotalAudience == null && other.TotalAudience == null) || (this.TotalAudience?.Equals(other.TotalAudience) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LectureId = {(this.LectureId == null ? "null" : this.LectureId)}");
            toStringOutput.Add($"this.Time = {(this.Time == null ? "null" : this.Time)}");
            toStringOutput.Add($"this.TotalAudience = {(this.TotalAudience == null ? "null" : this.TotalAudience.ToString())}");
        }
    }
}