//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AgreementType]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    // Table [dbo].[AgreementType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[AgreementType]")]
    public partial class AgreementType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AgreementType()
        {
            this.Agreements = new HashSet<Agreement>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementType(int agreementTypeID, string agreementTypeAbbrev, string agreementTypeName) : this()
        {
            this.AgreementTypeID = agreementTypeID;
            this.AgreementTypeAbbrev = agreementTypeAbbrev;
            this.AgreementTypeName = agreementTypeName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AgreementType CreateNewBlank()
        {
            return new AgreementType();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Agreements.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AgreementType).Name, typeof(Agreement).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            dbContext.AgreementTypes.Remove(this);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in Agreements.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int AgreementTypeID { get; set; }
        public string AgreementTypeAbbrev { get; set; }
        public string AgreementTypeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AgreementTypeID; } set { AgreementTypeID = value; } }

        public virtual ICollection<Agreement> Agreements { get; set; }

        public static class FieldLengths
        {
            public const int AgreementTypeAbbrev = 100;
            public const int AgreementTypeName = 100;
        }
    }
}