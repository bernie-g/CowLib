// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

namespace CowLibCore.Builders
{
    public abstract class BaseFileFactory<T>
    {
        public string Name;

        protected BaseFileFactory(BehaviorPack pack, string name, T builtObject)
        {
            BuiltObject = builtObject;
            Name = name;
            Pack = pack;
        }

        public BehaviorPack Pack { get; }

        public T BuiltObject { get; }

        public abstract void SaveFile();
    }
}