﻿namespace CustomEmbroideryOrderTracker_MVC.Models
{
    public class Design
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
        public int LocationID { get; set; }

        public string LocationName { get; set; }
    }
}
