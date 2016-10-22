// Copyright © 2016 Stig Schmidt Nielsson & Nielsson Consulting. All rights reserved. Distributed under the terms of the MIT License, see LICENSE.txt and http://opensource.org/licenses/MIT.

using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace StigSchmidtNielsson.Extensions.IEnumerable.Tests {
    public class EnumerableExtensionsTests {
        [Test]
        public void PageOnEmptyWorks() {
            var items = new int[0];
            items.Page(2).ShouldBeEmpty("Paging on empty collection should give empty result.");
        }

        [Test]
        public void PageOn1ElementWorks() {
            var items = new[] {1};
            var pages = items.Page(2).ToArray();
            pages.Length.ShouldBe(1, "A collection with 1 element should have one page of size 2");
            pages[0].ToArray().Length.ShouldBe(1, "The page should have 1 element.");
        }

        [Test]
        public void PageOn3ElementsWorks() {
            var items = new[] {1, 2, 3};
            var pages = items.Page(2).ToArray();
            pages.Length.ShouldBe(2, "A collection with 3 element should have two pages of size 2.");
            pages[0].ToArray().Length.ShouldBe(2, "The first page should be have 2 elements.");
            pages[1].ToArray().Length.ShouldBe(1, "The second page should have 1 element.");
        }
    }
}