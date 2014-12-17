﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Href.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    /// Represents a CREST href object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Href<T> {
        /// <summary>
        /// Initializes a new instance of the <see cref="Href{T}"/> class.
        /// </summary>
        public Href() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Href{T}"/> class.
        /// </summary>
        /// <param name="href">The href.</param>
        public Href(string href) {
            Uri = href;
        }


        /// <summary>
        /// The href object
        /// </summary>
        /// <value>The URI.</value>
        [DataMember(Name = "href")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public T Type { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Href{T}"/>.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Href<T>(string s) {
            return new Href<T>(s);
        }

        /// <summary>
        /// Returns the href as a string
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() {
            return Type.ToString();
        }
    }
}