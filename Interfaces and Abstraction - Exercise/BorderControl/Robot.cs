using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model
        {
            get => this.model;
            private set { this.model = value; }
        }

        public string Id
        {
            get => this.id;
            set { this.id = value; }
        }

    }
}