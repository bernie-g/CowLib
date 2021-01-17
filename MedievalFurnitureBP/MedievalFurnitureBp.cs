using System;
using System.IO;
using CowLibCore;
using CowLibCore.Builders;
using CowLibCore.Filter.Types;
using CowLibCore.Fragments;
using CowLibCore.Molang.ExpressionTrees;

namespace MedievalFurnitureBP
{
    internal class MedievalFurnitureBp
    {

        private static readonly int[] Version = { 1, 0, 0 };
        private static readonly int[] GameVersion = { 1, 16, 0 };
        private static readonly string ID = "mb.med-furniture";
        private static readonly string RootPath = Path.Combine(Directory.GetCurrentDirectory(), "med-furniture_BP");

        public static void Main(string[] args)
        {
            BehaviorPack pack = new BehaviorPack("Medieval-Furniture", ID, RootPath);
            pack.CreateManifest()
                .Version(Version)
                .Uuid(new Guid("87509843-7615-4e49-a0db-bb83523da5a9"))
                .MinEngineVersion(GameVersion)
                .BaseGameVersion(GameVersion)
                .Description(
                    "Medieval Furniture is a Bedrock Marketplace map with a huge assortment of medieval furniture!")
                .Authors("Gecko", "Freddy")
                .License("All Rights Reserved.")
                .Finish();

            Filter query = new Filter(() => Filters.Singleton == 3);

            pack.CreateEntity(new Identifier(ID, "candle"))
                .ApplyFragment(EntityFragments.SetFakeBlock)
                .Finish();

            pack.Save();
        }
    }
}
