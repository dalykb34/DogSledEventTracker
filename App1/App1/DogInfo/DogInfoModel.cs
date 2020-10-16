using System;
using System.Collections.Generic;
using System.Text;

namespace App1.DogInfo
{
    class DogInfoModel
    {
        public int Id { get; set; }
        public string DogName { get; set; }
        public string Age { get; set; }
        public string SledPosition { get; set; }
        public string WorksWell { get; set; }
        public string DoesntWorkWell { get; set; }
    }

    class EventInfoModel
    {
        public string Date { get; set; }
        public string EventName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string NumberOfSleds { get; set; }

    }
}
