using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.Iterator.Aggregates;
using DesignPatterns.Iterator.Iterators;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class IteratorTests
    {
        private readonly ITestOutputHelper _output;
        private readonly NumberAggregate _numberAggregate = new NumberAggregate { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        public IteratorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Even Number Enumerator")]
        public void EvenNumberEnumerator_Test()
        {
            var iterator = new EvenNumberEnumerator(_numberAggregate.ToList());

            iterator.Reset();
            while (iterator.MoveNext())
            {
                Assert.Equal(0, iterator.Current % 2);
            }

            iterator.Reset();
            iterator.MoveNext();
            Assert.Equal(0, iterator.Current);
        }

        [Fact(DisplayName = "Positive Case - Odd Number Enumerator")]
        public void OddNumberEnumerator_Test()
        {
            var iterator = new OddNumberEnumerator(_numberAggregate.ToList());

            iterator.Reset();
            while (iterator.MoveNext())
            {
                Assert.NotEqual(0, iterator.Current % 2);
            }

            iterator.Reset();
            iterator.MoveNext();
            Assert.Equal(1, iterator.Current);
        }

        [Fact(DisplayName = "Positive Case - Prime Number Enumerator")]
        public void PrimeNumberEnumerator_Test()
        {
            var iterator = new PrimeNumberEnumerator(_numberAggregate.ToList());
            var primes = new List<int> { 2, 3, 5, 7, 11, 13 };

            iterator.Reset();
            while (iterator.MoveNext())
            {
                Assert.Contains(primes, x => x == iterator.Current);
            }

            iterator.Reset();
            iterator.MoveNext();
            Assert.Equal(2, iterator.Current);
        }

        [Fact(DisplayName = "Positive Case - Print Even Numbers Only")]
        public void PrintEvenNumbersOnly_Test()
        {
            _numberAggregate.EnumeratorType = EnumeratorType.EvenNumber;

            Assert.Equal(0, _numberAggregate.First());
            Assert.Equal(14, _numberAggregate.Last());

            foreach (var num in _numberAggregate)
            {
                Assert.Equal(0, num % 2);
            }

            _output.WriteLine("Even Numbers: {0}",
                string.Join(" ", _numberAggregate));
        }

        [Fact(DisplayName = "Positive Case - Print Odd Numbers Only")]
        public void PrintOddNumbersOnly_Test()
        {
            _numberAggregate.EnumeratorType = EnumeratorType.OddNumber;

            Assert.Equal(1, _numberAggregate.First());
            Assert.Equal(13, _numberAggregate.Last());

            foreach (var num in _numberAggregate)
            {
                Assert.NotEqual(0, num % 2);
            }

            _output.WriteLine("Odd Numbers: {0}",
                string.Join(" ", _numberAggregate));
        }

        [Fact(DisplayName = "Positive Case - Print Prime Numbers Only")]
        public void PrintPrimeNumbersOnly_Test()
        {
            _numberAggregate.EnumeratorType = EnumeratorType.PrimeNumber;

            Assert.Equal(2, _numberAggregate.First());
            Assert.Equal(13, _numberAggregate.Last());

            _output.WriteLine("Prime Numbers: {0}",
                string.Join(" ", _numberAggregate));
        }

        [Fact(DisplayName = "Positive Case - Traverse Tree Depth First")]
        public void TreeDepthFirst_Test()
        {
            var root = new TreeNode<int>(1)
            {
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };
            root.EnumeratorType = EnumeratorType.DepthFirst;

            Assert.Equal(1, root.First());
            Assert.Equal(7, root.Last());

            _output.WriteLine("Tree Depth First: {0}",
                string.Join(" ", root));
        }

        [Fact(DisplayName = "Positive Case - Traverse Tree Breadth First")]
        public void TreeBreadthFirst_Test()
        {
            var root = new TreeNode<int>(1)
            {
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };

            root.EnumeratorType = EnumeratorType.BreadthFirst;

            Assert.Equal(1, root.First());
            Assert.Equal(10, root.Last());

            _output.WriteLine("Tree Breadth First: {0}",
                string.Join(" ", root));
        }

        private string ToXml(object value)
        {
            var xsSubmit = new XmlSerializer(value.GetType());
            using (var sww = new StringWriter())
            {
                var xmlSettings = new XmlWriterSettings
                {
                    Indent = true
                };
                using (var writer = XmlWriter.Create(sww, xmlSettings))
                {
                    xsSubmit.Serialize(writer, value);
                    return sww.ToString(); // Your XML
                }
            }
        }
    }
}
