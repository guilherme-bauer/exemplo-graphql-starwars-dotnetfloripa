﻿namespace GraphQL.StarWars.Api.GraphQL.ViewModels
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Character[] Friends { get; set; }
        public Episodes[] AppearsIn { get; set; }
    }
}