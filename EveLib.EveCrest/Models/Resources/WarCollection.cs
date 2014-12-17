﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="WarCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Represents a CREST collection of wars
    /// </summary>
    [DataContract]
    public sealed class WarCollection : CollectionResource<WarCollection> {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarCollection"/> class.
        /// </summary>
        public WarCollection() {
            Version = "application/vnd.ccp.eve.WarsCollection-v1+json";
        }

        /// <summary>
        /// A list of wars
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<LinkedEntity<War>> Items { get; set; }
    }
}