using System.Collections.Generic;

namespace dotnetPartThree.Core.Models
{
    public class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }
        
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
        
        public virtual ICollection<Territory> Territories { get; set; }
    }
}