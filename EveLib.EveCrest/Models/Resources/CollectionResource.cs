﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CollectionResource.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST collection response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCollection">The type of items in the collection</typeparam>
    [DataContract]
    public abstract class CollectionResource<T, TCollection> : CrestResource<T> where T : class, ICrestResource<T> {
        /// <summary>
        ///     The total number of items in the collection
        /// </summary>
        /// <value>The total count.</value>
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        ///     The items in the collection
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<TCollection> Items { get; set; }

        /// <summary>
        ///     The number of pages in the collection
        /// </summary>
        /// <value>The page count.</value>
        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

        /// <summary>
        ///     Gets or sets the next.
        /// </summary>
        /// <value>The next.</value>
        [DataMember(Name = "next")]
        public Href<CollectionResource<T, TCollection>> Next { get; set; }

        /// <summary>
        ///     Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        [DataMember(Name = "previous")]
        public Href<CollectionResource<T, TCollection>> Previous { get; set; }

        /// <summary>
        /// Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public virtual IEnumerable<TOut> Query<TOut>(Func<IReadOnlyList<TCollection>, IEnumerable<LinkedEntity<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(Items);
            return Crest.Load(items);
        }

        /// <summary>
        /// Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public virtual IEnumerable<TOut> Query<TOut>(Func<IReadOnlyList<TCollection>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(Items);
            return Crest.Load(items);
        }

        /// <summary>
        /// Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public TOut Query<TOut>(Func<IReadOnlyList<TCollection>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(Items);
            return Crest.Load(items);
        }

        /// <summary>
        /// Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public TOut Query<TOut>(Func<IReadOnlyList<TCollection>, LinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(Items);
            return Crest.Load(items);
        }




    }
}