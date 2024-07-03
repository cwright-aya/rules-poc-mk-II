using ConsoleApp2;
using RulesEngine.Actions;
using RulesEngine.Models;

public class MyCustomAction : ActionBase
{

    public MyCustomAction()
    { }

    private string[] fields = typeof(JobImport).GetProperties().Select(prop=>prop.Name).ToArray();

    public override ValueTask<object> Run(ActionContext context, RuleParameter[] ruleParameters)
    {
        var output = ruleParameters[1].Value as JobImport;
        foreach (var field in fields)
        {
            var prop = typeof(JobImport).GetProperty(field);
            if (context.TryGetContext(field, out object customInput))
            {
                prop.SetValue(output, customInput);
            }
        }
        return new ValueTask<object>(output);
    }

}
