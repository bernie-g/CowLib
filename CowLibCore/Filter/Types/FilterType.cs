// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

namespace CowLibCore.Filter.Types
{
    public class FilterType<T>
    {
        public static implicit operator FilterType<T>(int filter)
        {
            return new FilterType<T>();
        }

        public static implicit operator int(FilterType<T> filter)
        {
            return 0;
        }
    }

    public class Filters
    {
        public static FilterType<int> Singleton = new FilterType<int>();
    }
}