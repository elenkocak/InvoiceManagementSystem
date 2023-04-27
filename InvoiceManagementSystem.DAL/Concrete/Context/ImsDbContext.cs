﻿using InvoiceManagementSystem.Core.Entities.Concrete;
using InvoiceManagementSystem.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InvoiceManagementSystem.DAL.Concrete.Context
{
    public class ImsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;Database=InvoiceManagmentSystem;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<UserApartment> UserApartments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<UserBill> UserBills { get; set; }
        public DbSet<OperationClaim> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserSecurityHistory> UserSecurityHistories { get; set; }
        public DbSet<RoleGroupPermissions> RoleGroupsPermissions { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
    }
}
