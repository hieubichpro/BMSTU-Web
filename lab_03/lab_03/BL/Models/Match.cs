﻿namespace lab_03.BL.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int IdHome { get; set; }
        public int IdGuest { get; set; }
        public int IdLeague { get; set; }
        public int GoalHome { get; set; }
        public int GoalGuest { get; set; }
    }
}