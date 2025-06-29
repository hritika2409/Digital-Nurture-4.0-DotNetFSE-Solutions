using NUnit.Framework;
using Moq;
using CustomerCommLib;
using System;

namespace MoqHandsOnTest
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMailSender = new Mock<IMailSender>();
            _mockMailSender
                .Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
public void SendMailToCustomer_ShouldReturnTrue()
{
    Console.WriteLine("Starting test: SendMailToCustomer_ShouldReturnTrue");
    var result = _customerComm.SendMailToCustomer();
    Console.WriteLine("Result from SendMailToCustomer(): " + result);
    Assert.That(result, Is.True);
    Console.WriteLine("Test completed successfully.");
}

    }
}