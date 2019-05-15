using DesignPatterns.Composite.Abstractions;
using DesignPatterns.Composite.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class CompositeTests
    {
        private readonly ITestOutputHelper _output;

        public CompositeTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Agent Pay Out")]
        public void AgentPayOut_Test()
        {
            var parties = new AgentGroup
            {
                Name = "Root",
                Members = new List<IParty>
                {
                    new Agent { Name = "Arman", Rate = 0.4m},
                    new AgentGroup {
                        Name = "LA Office",
                        Rate = 0.4m,
                        Members = {
                            new Agent { Name = "Mike", Rate = 0.1m },
                            new Agent { Name = "John", Rate = 0.2m },
                            new AgentGroup
                            {
                                Name = "LA Office #2",
                                Rate = 0.7m,
                                Members = {
                                    new Agent { Name = "Bob", Rate = 0.5m },
                                    new Agent { Name = "Samantha", Rate = 0.5m }
                                }
                            }
                        }
                    },
                    new AgentGroup {
                        Name = "Beverly Hills Office",
                        Rate = 0.1m,
                        Members = {
                            new Agent { Name = "Anna", Rate = 0.5m },
                            new Agent { Name = "James", Rate = 0.5m },
                        }
                    },
                    new Agent { Name = "Aria", Rate = 0.1m}
                }
            };
            parties.PayOutAmount = 1000.00m;

            Assert.Equal(1000.00m, parties.Members.Sum(x => x.PayOutAmount));

            _output.WriteLine(parties.Stats());
        }

        [Fact(DisplayName = "Negative Case - Validate Agent Rate")]
        public void AgentPayOut_Validate_Agent_Rate_Test()
        {
            var parties = new AgentGroup
            {
                Name = "Root",
                Members = new List<IParty>
                {
                    new Agent { Name = "Arman", Rate = 1.1m}
                }
            };

            var ex = Assert.Throws<ValidationException>(() => parties.Validate());
            Assert.Equal("Arman => The value of rate cannot exceed 1.0 (100%).", ex.Message);
        }

        [Fact(DisplayName = "Negative Case - Validate Agent Group Rate")]
        public void AgentPayOut_Validate_AgentGroup_Rate_Test()
        {
            var parties = new AgentGroup
            {
                Name = "Root",
                Members = new List<IParty>
                {
                    new Agent { Name = "Arman", Rate = 0.4m},
                    new AgentGroup {
                        Name = "LA Office",
                        Rate = 0.4m,
                        Members = {
                            new Agent { Name = "Mike", Rate = 0.3m },
                            new Agent { Name = "John", Rate = 0.2m },
                            new AgentGroup
                            {
                                Name = "LA Office #2",
                                Rate = 0.7m,
                                Members = {
                                    new Agent { Name = "Bob", Rate = 0.5m },
                                    new Agent { Name = "Samantha", Rate = 0.5m }
                                }
                            }
                        }
                    },
                    new AgentGroup {
                        Name = "Beverly Hills Office",
                        Rate = 0.1m,
                        Members = {
                            new Agent { Name = "Anna", Rate = 0.5m },
                            new Agent { Name = "James", Rate = 0.5m },
                        }
                    },
                    new Agent { Name = "Aria", Rate = 0.1m}
                }
            };

            var ex = Assert.Throws<ValidationException>(() => parties.Validate());
            Assert.Equal("LA Office => the sum of parties' rates cannot exceed 1.0 (100%).", ex.Message);
        }
    }
}
