using SquareEquationLib;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;


namespace Specflowproj.Steps
{
    [Binding]
    public sealed class SquareEquationStepDefinitions
    {
       
       // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

       private double[] coef {get; set;}
       private double[] result {get; set;}
       private Exception except {get; set;} 

       [Given("Квадратное уравнение с коэффициентами ({string})")]
       public void SquareEqGiven(string numbers)
       {
            this.coef = new double[3];
            string[] stringCoef = numbers.Split(", ");
            for(var i = 0; i < 3; i++){
                this.coef[i] = Double.Parse(stringCoef[i]);
            }
       }
        
       [When("вычисляются корни квадратного уравнения")]
       public void SqEqSolve()
       {
           try{
                result = SquareEquationLib.SquareEquation.Solve(coef[0], coef[1], coef[2]);
           }
           catch(ArgumentException e){
                except = e;
           }
       }

       [Then("квадратное уравнение имеет два корня ({string}) кратности один")]
       public void ResultTwoRoots(string resultstr)
       {
           Array.Sort(result);

           string[] results = resultstr.Split(", ");
           double[] expected = new double[results.Length];
           for(var i = 0; i < results.Length; i++){
                expected[i] = Double.Parse(results[i]);
            }

           result.Should().ContainInOrder(expected);
       }

       [Then("квадратное уравнение имеет один корень {string} кратности два")]
       public void ResultOneRoot(string expected)
       {
           result[0].Should().Be(Double.Parse(expected));
       }

       [Then("множество корней квадратного уравнения пустое")]
       public void ResultEmpty()
       {

            result.Length.Should().Be(0);
       }

       [Then("выбрасывается исключение ArgumentException")]
       public void ResultException()
       {
            except.Should().BeOfType<System.ArgumentException>();
       }
    }
}
