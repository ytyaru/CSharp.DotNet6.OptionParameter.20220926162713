class Car : IAccelerator {
    private int gear;
    protected int Gear {
        get { return this.gear; }
        set { if (0<=value && value<=6) { this.gear = value; } }
    }
    public void Accelerator(int gear = -1) {
        Console.WriteLine("{0}.{1}() {2}", GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, this.Gear);
    }
}
