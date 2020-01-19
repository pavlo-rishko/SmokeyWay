using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.PhoneNumber).HasMaxLength(12).IsRequired();

            builder.Property(e => e.PhoneNumberConfirmed);

            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

            builder.Property(e => e.EmailConfirmed);

            builder.Property(e => e.BirthDate);

            builder.Property(e => e.CommunicationLanguage).HasMaxLength(100);

            builder.Property(e => e.PasswordHash);

            builder.HasOne(e => e.Gender).WithMany(t => t.Users)
                .HasForeignKey(w => w.GenderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Role).WithMany(t => t.Users)
                .HasForeignKey(w => w.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
