using Core.Domains.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domains.Vehicles
{
    public class Vehicle : _Base<int>
    {
        public string PlateNumber { get; set; }
        //====================================================================================================
        public string Model { get; set; }
        //====================================================================================================
        public string Year { get; set; }
        //====================================================================================================
        public string ImageUrl { get; set; }
        //====================================================================================================

        #region Relationships

        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        #endregion
    }
}
