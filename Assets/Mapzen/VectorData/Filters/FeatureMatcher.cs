﻿using System;
using System.Linq;

namespace Mapzen.VectorData.Filters
{
    public class FeatureMatcher : IFeatureMatcher
    {
        public virtual bool MatchesFeature(Feature feature)
        {
            return true;
        }

        public static IFeatureMatcher AnyOf(params IFeatureMatcher[] predicates)
        {
            return new CompoundFeatureMatcher
            {
                Type = CompoundFeatureMatcher.Operator.Any,
                Matchers = predicates.ToList(),
            };
        }

        public static IFeatureMatcher AllOf(params IFeatureMatcher[] predicates)
        {
            return new CompoundFeatureMatcher
            {
                Type = CompoundFeatureMatcher.Operator.All,
                Matchers = predicates.ToList(),
            };
        }

        public static IFeatureMatcher NoneOf(params IFeatureMatcher[] predicates)
        {
            return new CompoundFeatureMatcher
            {
                Type = CompoundFeatureMatcher.Operator.None,
                Matchers = predicates.ToList(),
            };
        }

        public static IFeatureMatcher HasProperty(string property)
        {
            return new PropertyFeatureMatcher
            {
                Key = property,
            };
        }

        public static IFeatureMatcher HasPropertyWithValue(string property, params object[] values)
        {
            return new PropertyValueFeatureMatcher
            {
                Key = property,
                ValueSet = values.ToList(),
            };
        }

        public static IFeatureMatcher HasPropertyInRange(string property, IComparable min, IComparable max)
        {
            return new PropertyRangeFeatureMatcher
            {
                Key = property,
                Min = min,
                Max = max,
            };
        }
    }
}

