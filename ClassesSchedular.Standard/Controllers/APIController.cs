// <copyright file="APIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ClassesSchedular.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using ClassesSchedular.Standard;
    using ClassesSchedular.Standard.Http.Client;
    using ClassesSchedular.Standard.Models.Containers;
    using ClassesSchedular.Standard.Utilities;
    using Newtonsoft.Json.Converters;
    using System.Net.Http;

    /// <summary>
    /// APIController.
    /// </summary>
    public class APIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIController"/> class.
        /// </summary>
        internal APIController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get all the classes scheduled today for the logged in teacher.
        /// </summary>
        /// <param name="teacherId">Required parameter: The unique identity string given to each teacher.</param>
        /// <returns>Returns the List of Class response from the API call.</returns>
        public List<Class> GetClasses(
                string teacherId)
            => CoreHelper.RunTask(GetClassesAsync(teacherId));

        /// <summary>
        /// Get all the classes scheduled today for the logged in teacher.
        /// </summary>
        /// <param name="teacherId">Required parameter: The unique identity string given to each teacher.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Class response from the API call.</returns>
        public async Task<List<Class>> GetClassesAsync(
                string teacherId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Class>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/today")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("teacherId", teacherId))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get all the details of the provided class.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the ClassInfo response from the API call.</returns>
        public ClassInfo GetClassInfo(
                Class body)
            => CoreHelper.RunTask(GetClassInfoAsync(body));

        /// <summary>
        /// Get all the details of the provided class.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ClassInfo response from the API call.</returns>
        public async Task<ClassInfo> GetClassInfoAsync(
                Class body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<ClassInfo>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/class/info")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ExecuteAsync(cancellationToken);
    }
}