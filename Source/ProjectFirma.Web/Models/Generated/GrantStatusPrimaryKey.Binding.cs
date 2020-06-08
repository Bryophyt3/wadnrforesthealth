//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GrantStatus
using CodeFirstStoreFunctions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class GrantStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GrantStatus>
    {
        public GrantStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GrantStatusPrimaryKey(GrantStatus grantStatus) : base(grantStatus){}

        public static implicit operator GrantStatusPrimaryKey(int primaryKeyValue)
        {
            return new GrantStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GrantStatusPrimaryKey(GrantStatus grantStatus)
        {
            return new GrantStatusPrimaryKey(grantStatus);
        }
    }
}