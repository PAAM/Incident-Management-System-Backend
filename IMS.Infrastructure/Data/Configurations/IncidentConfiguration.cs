using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Data.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IncidentNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(x => x.IncidentNumber)
                .IsUnique();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.PriorityId)
                .IsRequired();

            builder.Property(x => x.StatusId)
                .IsRequired();

            builder.Property(x => x.AreaId)
                .IsRequired();

            builder.Property(x => x.ReportedByUserId)
                .IsRequired();

            builder.Property(x => x.AssignedToUserId);


            //Relationship Priorities
            builder
                .HasOne(x => x.Priority)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);
                
            //RelationShip Status
            builder
                .HasOne(x => x.Status)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
                
            //Relationship Areas
            builder
                .HasOne(x => x.Area)
                .WithMany(x => x.Incidents)
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);
                
            //Relationship User 
            builder
                .HasOne(x => x.ReportedByUser)
                .WithMany(x => x.ReportedIncidents)
                .HasForeignKey(x => x.ReportedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.AssignedToUser)
                .WithMany(x => x.AssignedIncidents)
                .HasForeignKey(x => x.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);
                

        }
    }
}
