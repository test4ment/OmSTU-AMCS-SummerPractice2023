using System;
using Spaceship;
using FluentAssertions;
using TechTalk.SpecFlow;


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

       [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
       public void HasFuel(int amount){
           this.spaceship.SetFuel(amount);
           if (this.spaceship.GetLoc() == null){
               this.spaceship.SetLoc(0, 0);
           }
           if (this.spaceship.GetSpeed() == null){
               this.spaceship.SetSpeed(0, 0);
           }
       }

       [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
       public void FuelUsage(int amount){
           this.spaceship.SetFuelUsage(amount);
       }

       [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
       public void HasRotation(int degree){
           this.spaceship.SetRotation(degree);
       }

       [Given(@"имеет мгновенную угловую скорость (.*) град")]
       public void HasSpinSeed(int degree){
           this.spaceship.SetRotatingSpeed(degree);
       }

       [Given("космический корабль, угол наклона которого невозможно определить")]
       public void NoRotationGiven(){ }

       [Given("мгновенную угловую скорость невозможно определить")]
       public void NoSpinSpeedGiven(){ }

       [Given("невозможно изменить уголд наклона к оси OX космического корабля")]
       public void CannotSpin(){
           this.spaceship.SetSpinningState(false);
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

       [When("происходит вращение вокруг собственной оси")]
       public void InvokeSpin()
       {
        try{
           this.spaceship.Spin();
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

       [Then(@"новый объем топлива космического корабля равен (.*) ед")]
       public void ResultFuel(int expect){
           this.spaceship.GetFuel().Should().Be(expect);
       }

       [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
       public void ResultRotation(int expect){
           this.spaceship.GetRotation().Should().Be(expect);
       }
    }
}
