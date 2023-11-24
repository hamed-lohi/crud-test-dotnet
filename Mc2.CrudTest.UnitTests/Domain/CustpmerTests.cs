using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Factories;
using Shouldly;

namespace Mc2.CrudTest.UnitTests.Domain;

public class CustpmerTests
{
    public class CustomerTests
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        public void Create_Throws_InvalidEmailException(string email)
        {
            //ARRANGE

            //ACT
            var exception = Record.Exception(() => CreateCustomer(email:email));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidEmailException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123")]
        public void Create_Throws_InvalidBankAccountNumberException(string bankAccountNumber)
        {
            //ARRANGE

            //ACT
            var exception = Record.Exception(() => CreateCustomer(bankAccountNumber: bankAccountNumber));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidBankAccountNumberException>();
        }

        [Fact]
        public void Create_Customer_Success()
        {
            //ARRANGE

            //ACT
            var exception = Record.Exception(() => CreateCustomer());
            exception.ShouldBeNull();

            var customer = CreateCustomer();

            customer.ShouldNotBeNull();
            customer.Firstname.ShouldBe("Hamed");
        }


        #region ARRANGE

        private Customer CreateCustomer(string firstname = "Hamed", string lastname="Lohi", string phoneNumber = "09149012500", 
            string email = "lohi.hamed@gmail.com", string bankAccountNumber = "123456789") =>
            _factory.Create(Guid.NewGuid(), firstname, lastname, new DateTime(1990, 7, 8),
                phoneNumber, email, bankAccountNumber);

        private readonly ICustomerFactory _factory;

        public CustomerTests()
        {
            _factory = new CustomerFactory();
        }

        #endregion

    }
}