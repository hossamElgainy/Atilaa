namespace AshalLms.Core.Interfaces.Specification.SpecParams
{
    public class GetAdminAnnouncementsSpecParam : BasicPaginationParam
    {
        public bool? IsActive { get; set; }
    }
}
