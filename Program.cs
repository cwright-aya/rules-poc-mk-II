using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RulesEngine.Models;
using RulesEngine.Extensions;
using ConsoleApp2;

namespace RulesEngineConsoleApp
{

    class Program
    {
        static async Task Main(string[] args)
        {
            var input = new JobImport
            {
                Title = "Nurse 4x10 temp",
                FacilityId = 1234,
                EmploymentType = 4,
                StartDate = new DateTime(2020, 1, 1)
            };

            var output = new OutputModel();
            var rules = new List<MyRule>();
            rules.Add(new()
            {
                Name = "SetIsNursing",
                Expression = "input.Title.Contains(\"Nurse\")",
                Operations = new List<MyRuleOperation> {
                    new(){Property="IsNurseJob", Value="true" }
                }
            });

            rules.Add(new()
            {
                Name = "SetEmploymentTypeForFacility1234",
                Expression = "input.FacilityId == 1234",
                Operations = new List<MyRuleOperation> {
                    new(){Property="EmploymentType", Value="5" }
                }
            });
   

            var result = await new RulesEngineInterop().Execute(rules, input);

            Console.WriteLine($"Input Title: {input.Title}");
            Console.WriteLine($"Output Nickname: {output.Nickname}");
        }
    }
}
