using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace Umbraco.Core.Models.Rdbms
{
    [TableName("umbracoUserPickerStartNode")]
    [PrimaryKey("id", autoIncrement = true)]
    [ExplicitColumns]
    public class UserPickerStartNodeDto : IEquatable<UserPickerStartNodeDto>
    {
        [Column("id")]
        [PrimaryKeyColumn(Name = "PK_userPickerStartNode")]
        public int Id { get; set; }

        [Column("userId")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [ForeignKey(typeof(UserDto))]
        public int UserId { get; set; }

        [Column("startNode")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [ForeignKey(typeof(NodeDto))]
        public int StartNode { get; set; }

        [Column("startNodeType")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [Index(IndexTypes.UniqueNonClustered, ForColumns = "startNodeType, startNode, userId", Name = "IX_umbracoUserPickerStartNode_startNodeType")]
        public int StartNodeType { get; set; }

        public enum StartNodeTypeValue
        {
            Content = 1,
            Media = 2
        }

        public bool Equals(UserPickerStartNodeDto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserPickerStartNodeDto) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(UserPickerStartNodeDto left, UserPickerStartNodeDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserPickerStartNodeDto left, UserPickerStartNodeDto right)
        {
            return !Equals(left, right);
        }
    }
}