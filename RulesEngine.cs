
using RulesEngine.Actions;
using RulesEngine.Models;
using RulesEngineConsoleApp;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class RulesEngineInterop
    {
        public async Task<JobImport> Execute(List<MyRule> rules, JobImport input)
        {
            JobImport output = input with { };
            var reSettings = new ReSettings
            {
                CustomActions = new Dictionary<string, Func<ActionBase>>
                {
                    { "MyCustomAction", () => new MyCustomAction() }
                }
            };
            var workflowRules = GetWorkflowRules(rules);
            var bre = new RulesEngine.RulesEngine(workflowRules.ToArray(), reSettings);
            var inputs = new[]
            {
                new RuleParameter("input", input),
                new RuleParameter("output", output)
            };

            await bre.ExecuteAllRulesAsync("MyObjectWorkflow", inputs);
            return output;
        }

        public List<WorkflowRules> GetWorkflowRules(List<MyRule> rules)
        {
            return new List<WorkflowRules>
            {
                new WorkflowRules
                {
                    WorkflowName = "MyObjectWorkflow",
                    Rules = rules.Select(rule=>new RulesEngine.Models.Rule()
                    {
                        RuleName = rule.Name,
                        SuccessEvent = rule.Name,
                        Expression = rule.Expression,
                        Actions = new RuleActions(){
                            OnSuccess = new ActionInfo
                            {
                                Name = "MyCustomAction",
                                Context = rule.Operations.ToDictionary(i=>i.Property, i=>i.Value as Object)
                            }
                    }
                    })
                }
            };

        }
    };

}