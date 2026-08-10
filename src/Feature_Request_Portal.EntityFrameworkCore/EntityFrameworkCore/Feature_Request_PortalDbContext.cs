using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Feature_Request_Portal.Authors;
using Feature_Request_Portal.Books;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Feature_Request_Portal.FeatureRequests;
using Feature_Request_Portal.Votes;
using Feature_Request_Portal.Comments;

namespace Feature_Request_Portal.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class Feature_Request_PortalDbContext :
    AbpDbContext<Feature_Request_PortalDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<FeatureRequest> FeatureRequests { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public Feature_Request_PortalDbContext(DbContextOptions<Feature_Request_PortalDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        builder.Entity<Author>(b =>
        {
            b.ToTable(Feature_Request_PortalConsts.DbTablePrefix + "Authors",
                Feature_Request_PortalConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(AuthorConsts.MaxNameLength);
            b.Property(x => x.ShortBio).HasMaxLength(AuthorConsts.MaxShortBioLength);
        });

        builder.Entity<Book>(b =>
        {
            b.ToTable(Feature_Request_PortalConsts.DbTablePrefix + "Books",
                Feature_Request_PortalConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
        });

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(Feature_Request_PortalConsts.DbTablePrefix + "YourEntities", Feature_Request_PortalConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<FeatureRequest>(b =>
        {
            b.ToTable(Feature_Request_PortalConsts.DbTablePrefix + "FeatureRequests", Feature_Request_PortalConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props (CreationTime, CreatorId etc.)
            b.Property(x => x.Title).IsRequired().HasMaxLength(FeatureRequestConsts.MaxTitleLength);
            b.Property(x => x.Description).HasMaxLength(FeatureRequestConsts.MaxDescriptionLength);
            b.HasMany(x => x.Votes).WithOne().HasForeignKey(x => x.FeatureRequestId);
            b.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.FeatureRequestId);
        });

        builder.Entity<Vote>(b =>
        {
            b.ToTable(Feature_Request_PortalConsts.DbTablePrefix + "Votes", Feature_Request_PortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => new { x.FeatureRequestId, x.CreatorId }).IsUnique();
        });

        builder.Entity<Comment>(b =>
        {
            b.ToTable(Feature_Request_PortalConsts.DbTablePrefix + "Comments", Feature_Request_PortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Text).IsRequired().HasMaxLength(CommentConsts.MaxTextLength);
        });

    }
}
