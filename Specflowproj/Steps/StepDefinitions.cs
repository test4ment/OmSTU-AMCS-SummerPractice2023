using Spaceship;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;


namespace Specflowproj.Steps
{
    [Binding]
    public sealed class SpaceshipMove
    {
       
       // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

       private Ship spaceship = new Ship();
       private Exception exception;

       [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
       public void Shiplocgiven(double x, double y)
       {
            this.spaceship.SetLoc(x, y);
       }

       [Given("космический корабль, положение в пространстве которого невозможно определить")]
       public void Shiplocnotgiven() { }
        
       [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
       public void Shipspeedgiven(double x, double y)
       {
            this.spaceship.SetSpeed(x, y);
       }

       [Given("скорость корабля определить невозможно")]
       public void Shipspeednotgiven() { }

       [Given("изменить положение в пространстве космического корабля невозможно")]
       public void CantMove(){
           this.spaceship.SetMovingState(false);
       }

       [When("происходит прямолинейное равномерное движение без деформации")]
       public void InvokeMove()
       {
        try{
           this.spaceship.Move();
           }
        catch(Exception e){
            this.exception = e;
           }
       }

       [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
       public void ResultLoc(double expect1, double expect2)
       {
           spaceship.GetLoc().Should().ContainInOrder(new double[] {expect1, expect2});
       }

       [Then("возникает ошибка Exception")]
       public void ResultExcept()
       {
           this.exception.Should().NotBeNull();
       }
    }
}
