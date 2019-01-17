//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FocusAreaLocationStaging]
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
    // Table [dbo].[FocusAreaLocationStaging] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FocusAreaLocationStaging]")]
    public partial class FocusAreaLocationStaging : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FocusAreaLocationStaging()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusAreaLocationStaging(int focusAreaLocationStaggingID, int focusAreaID, string featureClassName, string geoJson) : this()
        {
            this.FocusAreaLocationStaggingID = focusAreaLocationStaggingID;
            this.FocusAreaID = focusAreaID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusAreaLocationStaging(int focusAreaID, string featureClassName, string geoJson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FocusAreaLocationStaggingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FocusAreaID = focusAreaID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FocusAreaLocationStaging(FocusArea focusArea, string featureClassName, string geoJson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FocusAreaLocationStaggingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FocusAreaID = focusArea.FocusAreaID;
            this.FocusArea = focusArea;
            focusArea.FocusAreaLocationStagings.Add(this);
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FocusAreaLocationStaging CreateNewBlank(FocusArea focusArea)
        {
            return new FocusAreaLocationStaging(focusArea, default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FocusAreaLocationStaging).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.FocusAreaLocationStagings.Remove(this);
        }

        [Key]
        public int FocusAreaLocationStaggingID { get; set; }
        public int FocusAreaID { get; set; }
        public string FeatureClassName { get; set; }
        public string GeoJson { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FocusAreaLocationStaggingID; } set { FocusAreaLocationStaggingID = value; } }

        public virtual FocusArea FocusArea { get; set; }

        public static class FieldLengths
        {
            public const int FeatureClassName = 255;
        }
    }
}