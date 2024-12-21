using Core.Domains.MediaFiles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domains.User
{
    public class Driver : _Base<int>
    {
        // add length to the string
        [MaxLength(11)]
        public string TCNumber { get; set; }
        //====================================================================================================
        [MaxLength(25)]
        public string FirstName { get; set; }
        //====================================================================================================
        [MaxLength(25)]
        public string LastName { get; set; }
        //====================================================================================================
        public string Password { get; set; }
        //====================================================================================================
        public int Age { get; set; }
        //====================================================================================================
        public List<MediaFile> MediaFiles { get; set; }
        //====================================================================================================

        #region Relationships

        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //====================================================================================================
        [ForeignKey(nameof(MediaFileId))]
        public int MediaFileId { get; set; }
        public MediaFile MediaFile { get; set; }
        //====================================================================================================

        #endregion
    }
}
