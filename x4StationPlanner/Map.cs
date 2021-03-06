﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace x4StationPlanner.Maps
{
    public static class Map
    {
        const string RecipeMapPath = @"Maps\RecipeMap.json";
        const string ItemTypeMapPath = @"Maps\ItemTypeMap.json";
        const string ItemTypeSortMapPath = @"Maps\ItemTypeSortMap.json";
        const string ItemFactionMapPath = @"Maps\ItemFactionMap.json";

        public const string WorkforceRecipeName = "Workforce";

        public static readonly Dictionary<string, Dictionary<string, Recipe>> RecipeMap;
        public static readonly Dictionary<string, string> ItemTypeMap;
        public static readonly Dictionary<string, int> ItemTypeSortMap;
        public static readonly Dictionary<string, string> ItemFactionMap;
        public static readonly Dictionary<string, bool> ItemWorkforceMap;

        public static readonly Dictionary<string, Recipe> WorkforceRecipes;

        static Map()
        {
            RecipeMap = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Recipe>>>(File.ReadAllText(RecipeMapPath));
            ItemTypeMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ItemTypeMapPath));
            ItemTypeSortMap = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(ItemTypeSortMapPath));
            ItemFactionMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ItemFactionMapPath));

            ItemWorkforceMap = RecipeMap.Keys.ToDictionary(x => x, x => false);

            if (RecipeMap.ContainsKey(WorkforceRecipeName))
            {
                WorkforceRecipeFound = true;
                WorkforceRecipes = RecipeMap[WorkforceRecipeName];
            }
        }

        public static bool WorkforceRecipeFound = false;

        public static void SaveFactionSettings()
        {
            var text = JsonConvert.SerializeObject(ItemFactionMap, Formatting.Indented);
            File.WriteAllText(ItemFactionMapPath, text);
        }
    }
}
