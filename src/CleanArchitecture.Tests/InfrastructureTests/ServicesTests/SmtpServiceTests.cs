using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.InfrastructureTests.ServicesTests
{
    public class SmtpServiceTests : InfrastructureBaseTests
    {
        public SmtpServiceTests() { }

        [Fact(DisplayName = "should send mail")]
        public async Task ShouldSendMail()
        {
            // arrange
            var mail = new Mail("leo.hpvolpi@hotmail.com", "Welcome emails", "E-mail Teste");

            // act
            await this.smtpService.SendAsync(mail);

            // assert
            Assert.True(true);
        }
    }
}

