// See https://aka.ms/new-console-template for more information

using Csla;
using Csla.Configuration;
using CslaRuleTest;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");
var services = new ServiceCollection();
services.AddCsla();
var provider = services.BuildServiceProvider();
var applicationContext = provider.GetRequiredService<ApplicationContext>();

var portal = applicationContext.GetRequiredService<IDataPortal<Root>>();

var root = portal.Create();

Console.WriteLine(root);
root.Num1 = 20;
Console.WriteLine(root);
root.Num2 = 25;
Console.WriteLine(root);
root.Num3 = 30;
Console.WriteLine(root);
Console.ReadLine();