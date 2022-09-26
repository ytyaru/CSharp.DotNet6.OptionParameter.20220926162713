class ATCar : Car {
    public new void Accelerator(int gear = -1) {
        if (6 == this.Gear) { this.Gear = 0; }
        this.Gear++;
        base.Accelerator();
    }
}
