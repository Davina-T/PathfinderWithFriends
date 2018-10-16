using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Statics
{
    public class FeatListData
    {

        public string Name { get; set; }

        public string Description { get; set; }


        public FeatListData Clone()
        {
            return new FeatListData()
            {
                Name = Name,
                Description = Description
            };

        }

    }

    
}
