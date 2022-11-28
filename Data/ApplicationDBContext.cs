using CommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CommerceProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<User_1> User_1s { get; set; }
        public DbSet<Fundraiser_1> Fundraiser_1s { get; set; }
        public DbSet<Donor_1> Donor_1s { get; set; }
        //public DbSet<Login> Logins { get; set; }
        //public DbSet<Donor> Donors { get; set; }
        //public DbSet<DonationForm> donationForms { get; set; }
        //public DbSet<Fundraiser> Fundraisers { get; set; }
        //public DbSet<UserProfile> Profiles { get; set; }
        //public DbSet<Image> Images { get; set; }

        //public DbSet<UserModel> User { get; set; }
        //public DbSet<FundraiserModel> Fundraiser { get; set; }
        //public DbSet<DonorModel> Donor { get; set; }

    }
}
