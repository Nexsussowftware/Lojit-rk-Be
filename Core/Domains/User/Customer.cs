using Core.Domains.MediaFiles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domains.User
{
    public class Customer : _Base<int>
    {
        [MaxLength(11)]
        public string TCNumber { get; set; }
        //====================================================================================================
        [MaxLength(25)]
        public string FirstName { get; set; }
        //====================================================================================================
        [MaxLength(25)]
        public string LastName { get; set; }
        //====================================================================================================
        public string Address { get; set; }
        //====================================================================================================

        #region Relationships

        [ForeignKey(nameof(MediaFileId))]
        public int MediaFileId { get; set; }
        public MediaFile MediaFile { get; set; }

        #endregion
    }
}
