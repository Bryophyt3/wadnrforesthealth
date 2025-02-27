//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Grant]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    // Table [dbo].[Grant] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[Grant]")]
    public partial class Grant : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Grant()
        {
            this.GrantFileResources = new HashSet<GrantFileResource>();
            this.GrantModifications = new HashSet<GrantModification>();
            this.GrantNotes = new HashSet<GrantNote>();
            this.GrantNoteInternals = new HashSet<GrantNoteInternal>();
            this.Invoices = new HashSet<Invoice>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Grant(int grantID, string grantNumber, DateTime? startDate, DateTime? endDate, string conditionsAndRequirements, string complianceNotes, string cFDANumber, string grantName, int? grantTypeID, string shortName, int grantStatusID, int organizationID) : this()
        {
            this.GrantID = grantID;
            this.GrantNumber = grantNumber;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ConditionsAndRequirements = conditionsAndRequirements;
            this.ComplianceNotes = complianceNotes;
            this.CFDANumber = cFDANumber;
            this.GrantName = grantName;
            this.GrantTypeID = grantTypeID;
            this.ShortName = shortName;
            this.GrantStatusID = grantStatusID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Grant(string grantName, int grantStatusID, int organizationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GrantID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GrantName = grantName;
            this.GrantStatusID = grantStatusID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Grant(string grantName, GrantStatus grantStatus, Organization organization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GrantID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GrantName = grantName;
            this.GrantStatusID = grantStatus.GrantStatusID;
            this.GrantStatus = grantStatus;
            grantStatus.Grants.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.Grants.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Grant CreateNewBlank(GrantStatus grantStatus, Organization organization)
        {
            return new Grant(default(string), grantStatus, organization);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return GrantFileResources.Any() || GrantModifications.Any() || GrantNotes.Any() || GrantNoteInternals.Any() || Invoices.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(GrantFileResources.Any())
            {
                dependentObjects.Add(typeof(GrantFileResource).Name);
            }

            if(GrantModifications.Any())
            {
                dependentObjects.Add(typeof(GrantModification).Name);
            }

            if(GrantNotes.Any())
            {
                dependentObjects.Add(typeof(GrantNote).Name);
            }

            if(GrantNoteInternals.Any())
            {
                dependentObjects.Add(typeof(GrantNoteInternal).Name);
            }

            if(Invoices.Any())
            {
                dependentObjects.Add(typeof(Invoice).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Grant).Name, typeof(GrantFileResource).Name, typeof(GrantModification).Name, typeof(GrantNote).Name, typeof(GrantNoteInternal).Name, typeof(Invoice).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.Grants.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in GrantFileResources.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GrantModifications.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GrantNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GrantNoteInternals.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in Invoices.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int GrantID { get; set; }
        public string GrantNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ConditionsAndRequirements { get; set; }
        public string ComplianceNotes { get; set; }
        public string CFDANumber { get; set; }
        public string GrantName { get; set; }
        public int? GrantTypeID { get; set; }
        public string ShortName { get; set; }
        public int GrantStatusID { get; set; }
        public int OrganizationID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GrantID; } set { GrantID = value; } }

        public virtual ICollection<GrantFileResource> GrantFileResources { get; set; }
        public virtual ICollection<GrantModification> GrantModifications { get; set; }
        public virtual ICollection<GrantNote> GrantNotes { get; set; }
        public virtual ICollection<GrantNoteInternal> GrantNoteInternals { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual GrantType GrantType { get; set; }
        public virtual GrantStatus GrantStatus { get; set; }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int GrantNumber = 30;
            public const int CFDANumber = 10;
            public const int GrantName = 64;
            public const int ShortName = 64;
        }
    }
}