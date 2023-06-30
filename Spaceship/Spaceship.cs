namespace Spaceship;

public class Ship
{
    private double[] location; 
    private double[] instantSpeed;
    private bool canMove = true;

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

    public void Move(){
        if(canMove){
            try{
                this.location[0] += this.instantSpeed[0];
                this.location[1] += this.instantSpeed[1];
            }
            catch{
                throw new Exception();
            }
        }
        else throw new Exception();
    }
}
