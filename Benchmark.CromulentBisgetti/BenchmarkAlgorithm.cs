using BenchmarkDotNet.Attributes;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using System.Collections.Generic;

namespace Benchmark.CromulentBisgetti
{
    [MemoryDiagnoser]
    public class BenchmarkAlgorithm
    {
        private List<int> _Algorithm;
        private List<Item> _Items;
        private List<Container> _Containers;

        [Params(1, 5, 10)]
        public int QuantityItems;

        [Params(5, 10, 20)]
        public int VariationItems;

        [Params(10, 20, 50)]
        public int VariationContainers;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _Algorithm = new List<int>
            {
                (int)AlgorithmType.EB_AFIT
            };

            _Items = new List<Item>(VariationItems);

            for (int i = 0; i < VariationItems; i++)
            {
                if (i % 6 == 0)
                    _Items.Add(new Item(i, 5, 10, 5, QuantityItems));
                if (i % 6 == 1)
                    _Items.Add(new Item(i, 2, 5, 3, QuantityItems));
                if (i % 6 == 2)
                    _Items.Add(new Item(i, 5, 5, 5, QuantityItems));
                if (i % 6 == 3)
                    _Items.Add(new Item(i, 8, 5, 3, QuantityItems));
                if (i % 6 == 4)
                    _Items.Add(new Item(i, 10, 6, 8, QuantityItems));
                if (i % 6 == 5)
                    _Items.Add(new Item(i, 3, 6, 9, QuantityItems));
            }

            _Containers = new List<Container>(VariationContainers);
            for (int i = 0; i < VariationContainers; i++)
            {
                if (i % 6 == 0)
                    _Containers.Add(new Container(i, 50, 30, 20));
                if (i % 6 == 1)
                    _Containers.Add(new Container(i, 50, 15, 15));
                if (i % 6 == 2)
                    _Containers.Add(new Container(i, 50, 15, 10));
                if (i % 6 == 3)
                    _Containers.Add(new Container(i, 20, 5, 5));
                if (i % 6 == 4)
                    _Containers.Add(new Container(i, 20, 10, 10));
                if (i % 6 == 5)
                    _Containers.Add(new Container(i, 80, 50, 30));
            }
        }

        [Benchmark]
        public void ExecutionTime()
        {
            PackingService.Pack(_Containers, _Items, _Algorithm);
        }
    }
}
