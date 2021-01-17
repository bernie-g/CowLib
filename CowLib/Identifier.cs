// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using CowLib.Validators;

namespace CowLib
{
    public class Identifier
    {
        public Identifier(string identifier)
        {
            IdentifierValidator.COMBINED.Validate(identifier);
            string[] parts = identifier.Split(':');
            Namespace = parts[0];
            Path = parts[1];
        }

        public Identifier(string nameSpace, string path)
        {
            IdentifierValidator.PARTS.Validate(nameSpace);
            IdentifierValidator.PARTS.Validate(path);
            Namespace = nameSpace;
            Path = path;
        }

        public string Namespace { get; }
        public string Path { get; }

        public override string ToString()
        {
            return $"{Namespace}:{Path}";
        }

        public static implicit operator string(Identifier i) => i.ToString();
        //public static implicit operator Identifier(string s) => new Identifier(s);
    }
}