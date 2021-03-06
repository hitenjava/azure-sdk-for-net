// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.DataFactory;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A copy activity Dynamics sink.
    /// </summary>
    public partial class DynamicsSink : CopySink
    {
        /// <summary>
        /// Initializes a new instance of the DynamicsSink class.
        /// </summary>
        public DynamicsSink()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DynamicsSink class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="writeBatchSize">Write batch size. Type: integer (or
        /// Expression with resultType integer), minimum: 0.</param>
        /// <param name="writeBatchTimeout">Write batch timeout. Type: string
        /// (or Expression with resultType string), pattern:
        /// ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])).</param>
        /// <param name="sinkRetryCount">Sink retry count. Type: integer (or
        /// Expression with resultType integer).</param>
        /// <param name="sinkRetryWait">Sink retry wait. Type: string (or
        /// Expression with resultType string), pattern:
        /// ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])).</param>
        /// <param name="ignoreNullValues">The flag indicating whether ignore
        /// null values from input dataset (except key fields) during write
        /// operation. Default is false. Type: boolean (or Expression with
        /// resultType boolean).</param>
        public DynamicsSink(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), object writeBatchSize = default(object), object writeBatchTimeout = default(object), object sinkRetryCount = default(object), object sinkRetryWait = default(object), object ignoreNullValues = default(object))
            : base(additionalProperties, writeBatchSize, writeBatchTimeout, sinkRetryCount, sinkRetryWait)
        {
            IgnoreNullValues = ignoreNullValues;
            CustomInit();
        }
        /// <summary>
        /// Static constructor for DynamicsSink class.
        /// </summary>
        static DynamicsSink()
        {
            WriteBehavior = "Upsert";
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the flag indicating whether ignore null values from
        /// input dataset (except key fields) during write operation. Default
        /// is false. Type: boolean (or Expression with resultType boolean).
        /// </summary>
        [JsonProperty(PropertyName = "ignoreNullValues")]
        public object IgnoreNullValues { get; set; }

        /// <summary>
        /// The write behavior for the operation.
        /// </summary>
        [JsonProperty(PropertyName = "writeBehavior")]
        public static string WriteBehavior { get; private set; }

    }
}
