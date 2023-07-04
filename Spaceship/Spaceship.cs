using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Spaceship;


public class PoolGuard : IDisposable
{
    private static bool disposed;
    private static List<Ship> _available = new List<Ship>();
    private static List<Ship> _inUse = new List<Ship>();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing)
        {
            this.Dispose();
        }

        disposed = true;
    }

    public static Ship GetObject()
    {
        lock (_available)
        {
            if (_available.Count != 0)
            {
                Ship po = _available[0];
                _inUse.Add(po);
                _available.RemoveAt(0);
                return po;
            }
            else
            {
                Ship po = new Ship();
                _inUse.Add(po);
                return po;
            }
        }
    }

    public static void ReleaseObject(Ship po)
    {
        CleanUp(po);

        lock (_available)
        {
            _available.Add(po);
            _inUse.Remove(po);
        }
    }

    protected static void CleanUp(Ship po){
        po.SetLoc(0, 0); 
        po.SetSpeed(0, 0);
        po.SetMovingState(false);
        po.SetRotation(0);
        po.SetRotatingSpeed(0);
        po.SetSpinningState(false);
        po.SetFuel(0);
        po.SetFuelUsage(0);
    }
}

public class Ship
{
    bool disposed = false;


    private double[]? location; 
    private double[]? instantSpeed;
    private bool canMove = true;
    private int? rotationDeg = null;
    private int? spinSpeed = null;
    private bool canSpin = true;
    private int fuel = 0;
    private int fuelUsage = 0;

    public Ship() {}

    public void SetLoc(double x, double y){
        this.location = new double[] {x, y};
    }

    public double[] GetLoc(){
        return this.location;
    }

    public void SetSpeed(double x, double y){
        this.instantSpeed = new double[] {x, y};
    }

    public double[] GetSpeed(){
        return this.instantSpeed;
    }

    public void SetMovingState(bool ability){
        this.canMove = ability;
    }

    public bool CanMove(){
        return this.canMove;
    }

    public void SetRotation(int degrees){
        this.rotationDeg = degrees % 360;
    }

    public int GetRotation(){
        return (int)this.rotationDeg;
    }

    public void SetRotatingSpeed(int degPerSpin){
        this.spinSpeed = degPerSpin;
        // this.spinSpeed %= 360; // Очень небольшая оптимизация
    }

    public int GetSpinSpeed(){
        return (int)this.spinSpeed;
    }

    public void SetSpinningState(bool ability){
        this.canSpin = ability;
    }

    public bool CanSpin(){
        return this.canSpin;
    }

    public void SetFuel(int amount){ // Лучше использовать дозаправку (AddFuel) 
        this.fuel = amount;
    }

    public void AddFuel(int amount){
        throw new NotImplementedException();
    }

    public int GetFuel(){
        return this.fuel;
    }

    public void SetFuelUsage(int amount){
        this.fuelUsage = amount;
    }

    public int GetFuelUsage(){
        return this.fuelUsage;
    }

    public void Spin(){
        if(this.canSpin && this.rotationDeg != null && this.spinSpeed != null){
            try{
                this.rotationDeg += this.spinSpeed % 360;
                this.rotationDeg %= 360;
            }
            catch{
                throw new Exception();
            }
        }
        else throw new Exception();
    }

    public void Move(){
        if(this.canMove && this.fuel - this.fuelUsage >= 0){
            try{
                this.location[0] += this.instantSpeed[0];
                this.location[1] += this.instantSpeed[1];
                this.fuel -= this.fuelUsage;
            }
            catch{
                throw new Exception();
            }
        }
        else throw new Exception();
    }
}
