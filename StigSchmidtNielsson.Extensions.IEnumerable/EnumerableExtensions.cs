// Copyright © 2016 Stig Schmidt Nielsson & Nielsson Consulting. All rights reserved. Distributed under the terms of the MIT License, see LICENSE.txt and http://opensource.org/licenses/MIT.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StigSchmidtNielsson.Extensions.IEnumerable {
    /// <summary>
    /// Page through an IEnumerable with a given page size, using an enumerator instead of Take and Skip
    /// to ensure not risking fetching entire collection to memory before doing the paging.
    /// </summary>
    public static class EnumerableExtensions {
        public static IEnumerable<IEnumerable<T>> Page<T>(this IEnumerable<T> source, int pageSize) {
            using (var enumerator = source.GetEnumerator()) {
                while (enumerator.MoveNext()) {
                    var page = new List<T>(pageSize);
                    do {
                        page.Add(enumerator.Current);
                    } while (page.Count < pageSize && enumerator.MoveNext());
                    //var currentPage = new List<T>(pageSize) {
                    //    enumerator.Current
                    //};
                    //while (currentPage.Count < pageSize && enumerator.MoveNext()) {
                    //    currentPage.Add(enumerator.Current);
                    //}
                    yield return new ReadOnlyCollection<T>(page);
                }
            }
        }
    }
}