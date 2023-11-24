using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using System.Reflection.Emit;

namespace Mc2.CrudTest.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(b => b.Id);

        var customerEmailConverter = new ValueConverter<CustomerEmail, string>(v => v.Value,
            v => new CustomerEmail(v));
        var customerBankAccountNumberConverter = new ValueConverter<CustomerBankAccountNumber, string>(v => v.Value,
            v => new CustomerBankAccountNumber(v));

        builder
            .Property(p => p.Id)
            .HasConversion(id => id.Value, id => new CustomerId(id));
        builder
            .Property(typeof(CustomerEmail), "_email")
            .HasConversion(customerEmailConverter)
            .HasColumnName("Email")
            .HasMaxLength(200);
        builder
            .Property(typeof(CustomerBankAccountNumber), "_bankAccountNumber")
            .HasConversion(customerBankAccountNumberConverter)
            .HasColumnName("BankAccountNumber")
            .HasMaxLength(9);
        builder
            .Property(typeof(string), "_firstname")
            .HasColumnName("Firstname")
            .HasMaxLength(100);
        builder
            .Property(typeof(string), "_lastname")
            .HasColumnName("Lastname")
            .HasMaxLength(150);
        builder
            .Property(typeof(DateTime), "_dateOfBirth")
            .HasColumnName("DateOfBirth");
        builder
            .Property(typeof(string), "_phoneNumber")
            .HasColumnName("PhoneNumber")
            .HasMaxLength(15);

        builder
            .HasIndex("_email")
            .IsUnique();
        builder
            .HasIndex("_firstname", "_lastname", "_dateOfBirth")
            .IsUnique();

        builder.ToTable("Customer");
    }
}
