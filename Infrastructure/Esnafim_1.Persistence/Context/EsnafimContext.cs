using Esnafim_1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Context
{
    public class EsnafimContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3JI920O\\SQLEXPRESS;initial Catalog=DbEsnafim1;integrated Security=true;TrustServerCertificate=true");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCategory> BusinessCategories { get; set; }
        public DbSet<BusinessCategoryRelation> BusinessCategoryRelations { get; set; }
        public DbSet<BusinessComment> BusinessComments { get; set; }
        public DbSet<BusinessEmployee> BusinessEmployees { get; set; }
        public DbSet<BusinessOwnership> BusinessOwnerships { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
