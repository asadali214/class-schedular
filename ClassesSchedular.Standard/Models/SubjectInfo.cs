// <copyright file="SubjectInfo.cs" company="APIMatic">
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
    /// SubjectInfo.
    /// </summary>
    public class SubjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectInfo"/> class.
        /// </summary>
        public SubjectInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectInfo"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="time">time.</param>
        /// <param name="onlyStudents">onlyStudents.</param>
        public SubjectInfo(
            string name,
            string time,
            bool? onlyStudents = null)
        {
            this.Name = name;
            this.Time = time;
            this.OnlyStudents = onlyStudents;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Time.
        /// </summary>
        [JsonConverter(typeof(JsonStringConverter), true)]
        [JsonProperty("time")]
        [JsonRequired]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets OnlyStudents.
        /// </summary>
        [JsonProperty("onlyStudents", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OnlyStudents { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubjectInfo : ({string.Join(", ", toStringOutput)})";
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
            return obj is SubjectInfo other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Time == null && other.Time == null) || (this.Time?.Equals(other.Time) == true)) &&
                ((this.OnlyStudents == null && other.OnlyStudents == null) || (this.OnlyStudents?.Equals(other.OnlyStudents) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Time = {(this.Time == null ? "null" : this.Time)}");
            toStringOutput.Add($"this.OnlyStudents = {(this.OnlyStudents == null ? "null" : this.OnlyStudents.ToString())}");
        }
    }
}